## xam-akavache-test

### Testing Akavache on Xamarin Android with a Shared PCL Library

This repo is for testing Akavache's persistence across Xamarin Android app restarts when it's being hosted in a shared library.

It uses some basic ReactiveUi wizardry for hooking up the buttons and the textbox/label. If you're not familiar with RxUi then that doesn't matter, because it has no bearing at all on the initialisation and usage of the Akavache stuff.

### Quick-start (using the Akavache global static instance):

1. Run the app (deploy and run, don't run inside a debugger, because if you relaunch it with the debugger, it'll probably clobber everything).
2. Type something in the box, and hit the "save" button (your text should appear in the label).
3. Close the app.

Remove it from the backstack, or reboot the phone, or make sure the app is completely closed some other way (don't uninstall because that wipes everything!)

1. Launch the app.
2. Hit the "read" button
3. The text you typed in previously should appear.

### Instantiating Akavache (perhaps you need IoC or because reasons)
If you're interested in instantiating an Akavache instance (IBlobCache), switch to the `instantiate-blobcache` branch and have a at the differences to `SharedAppGlobal.Init()`, and where the initial path is set (this will need to be done in your platspec project and passed down to the shared lib) in `AkavacheTest.BaseViews\BaseView.cs` class.

You can then reference the instantiated version in the shared library, and Akavache will take care of all the cache file location setup, database initialisation, etc. It also takes care of supplying an encryption provider and a task scheduler for the threading/async stuff.

Happy caching! :)
