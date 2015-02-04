using AkavacheTest.Shared.ViewModels;
using AkavacheTest.Views;
using Android.App;
using Android.Widget;
using Android.OS;
using ReactiveUI;

namespace AkavacheTest
{
    [Activity(Label = "AkavacheTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseView<MainActivityViewModel>
    {
        private EditText _edTextToSave;
        private TextView _txtFromCache;
        private Button _btnWriteToCache;
        private Button _btnReadFromCache;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainActivity);

            FindAndBindUiElements();
        }

        private void FindAndBindUiElements()
        {
            _edTextToSave = FindViewById<EditText>(Resource.Id.edTextToSave);
            _txtFromCache = FindViewById<TextView>(Resource.Id.txtFromCache);
            _btnWriteToCache = FindViewById<Button>(Resource.Id.btnWriteToCache);
            _btnReadFromCache = FindViewById<Button>(Resource.Id.btnReadFromCache);

            this.Bind(ViewModel, vm => vm.TextToSave, v => v._edTextToSave.Text);
            this.OneWayBind(ViewModel, vm => vm.TextFromCache, v => v._txtFromCache.Text);
            this.BindCommand(ViewModel, vm => vm.WriteStringToCache, v => v._btnWriteToCache);
            this.BindCommand(ViewModel, vm => vm.ReadStringFromCache, v => v._btnReadFromCache);
        }
    }
}

