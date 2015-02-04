# xam-akavache-test

Testing Akavache on Xamarin Android with a Shared PCL Library

This repo is for testing Akavache's persistence across Xamarin Android app restarts when it's being hosted in a shared library.

TL;DR: As long as the app is running, the caching works perfectly. However, when the app is relaunched from scratch (or, for example, the device is rebooted), the cached information is gone. 

Either the cache is being reset, or recreated, either way, all the data that was stored is gone.

This project is for attempting to repro the issue as described at

StackOverflow: http://stackoverflow.com/questions/28294496/akavache-not-persisting-cache-data-between-app-restarts
Xamarin Forums: https://forums.xamarin.com/discussion/comment/101000

Steps to reproduce: 

1. Fire up the app, type in some text and hit "Save" 
2. Hit the back button or tap the home button or something to "background" the app
3. Tap the app icon again to bring the app to the foreground.
4. Hit "Reload" to load your text. It should work.

Now, shut down the app completely (either by getting to your backstack and removing the app from there, or rebooting your device, or something). 

1. Tap the app icon to load it 
2. Hit "Reload" to load the data you cached earlier.
3. Let the exceptions flow.

