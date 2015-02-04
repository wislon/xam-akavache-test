using System;
using AkavacheTest.Shared;
using Android.OS;
using ReactiveUI;

namespace AkavacheTest.Views
{
    public class BaseView<T> : ReactiveActivity<T> where T : ReactiveObject
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string pathToCacheDbFile = System.IO.Path.Combine(GetExternalFilesDir(null).AbsolutePath, "cache.db");
            SharedAppGlobal.Init(pathToCacheDbFile);

            ViewModel = (T)Activator.CreateInstance(typeof(T));
        }
    }
}

