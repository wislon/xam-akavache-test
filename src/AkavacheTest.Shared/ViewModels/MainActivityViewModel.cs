using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using ReactiveUI;
using Splat;

namespace AkavacheTest.Shared.ViewModels
{
    public class MainActivityViewModel : ReactiveObject
    {
        private string _textToSave;
        private string _textFromCache;

        public string TextToSave
        {
            get { return _textToSave; }
            set { this.RaiseAndSetIfChanged(ref _textToSave, value); }
        }

        public string TextFromCache
        {
            get { return _textFromCache; }
            set { this.RaiseAndSetIfChanged(ref _textFromCache, value); }
        }

        public ReactiveCommand<string> WriteStringToCache { get; set; }
        public ReactiveCommand<string> ReadStringFromCache { get; set; }

        public MainActivityViewModel()
        {
            var canStore = this.WhenAnyValue(vm => vm.TextToSave, s => !string.IsNullOrWhiteSpace(s));
            WriteStringToCache = ReactiveCommand.CreateAsyncTask(canStore, async _ => await WriteStringToCacheImpl());

            WriteStringToCache.Subscribe(returnedString => TextFromCache = returnedString);

            WriteStringToCache.ThrownExceptions.Subscribe(
                exception =>
                {
                    this.Log().ErrorException("There was an error reading/writing to cache", exception);
                    TextFromCache = string.Format("Error reading/writing to cache: {0}", exception);
                });

            var canRead = Observable.Return(true);
            ReadStringFromCache = ReactiveCommand.CreateAsyncTask(canRead, async _ => await ReadStringFromCacheImpl());
            ReadStringFromCache.Subscribe(returnedString => TextFromCache = returnedString);

            ReadStringFromCache.ThrownExceptions.Subscribe(
                exception =>
                {
                    this.Log().ErrorException("There was an error reading from the cache", exception);
                    TextFromCache = string.Format("Error reading cache: {0}", exception);
                });

        }

        private async Task<string> WriteStringToCacheImpl()
        {
            string text = _textToSave;
            await BlobCache.UserAccount.InsertObject("text", text);
            return await BlobCache.UserAccount.GetObject<string>("text");
        }

        private async Task<string> ReadStringFromCacheImpl()
        {
            return await BlobCache.UserAccount.GetObject<string>("text");
        }

    }
}