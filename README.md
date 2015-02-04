## xam-akavache-test

Testing Akavache on Xamarin Android with a Shared PCL Library

This repo is for testing Akavache's persistence across Xamarin Android app restarts when it's being hosted in a shared library.

It uses some basic ReactiveUi wizardry for hooking up the buttons and the textbox/label. If you're not familiar with RxUi then that doesn't matter, because it has no bearing at all on the initialisation and usage of the Akavache stuff.

### Quick-start:

1. Run the app (deploy and run, don't run inside a debugger, because if you relaunch it with the debugger, it'll probably clobber everything).
2. Type something in the box, and hit the "save" button (your text should appear in the label).
3. Close the app.

Remove it from the backstack, or reboot the phone, or make sure the app is completely closed some other way (don't uninstall!)

1. Launch the app.
2. Hit the "read" button
3. The text you typed in previously should appear.

