using System;
using Android.OS;
using ReactiveUI;

namespace AkavacheTest.Views
{
	public class BaseView<T> : ReactiveActivity<T> where T : ReactiveObject
	{
	
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			ViewModel = (T)Activator.CreateInstance (typeof (T));
		}
	}
}

