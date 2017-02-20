The Face API finds human faces in photos, videos, or live streams. It also finds and tracks positions of facial landmarks such as the eyes, nose, and mouth.

The API also provides information about the state of facial features -- are the subject's eyes open? Are they smiling? With these technologies, you can edit photos and video, enhance video feeds with effects and decorations, create hands-free controls for games and apps, or react when a person winks or smiles.

The Barcode Scanner API detects barcodes in real time in any orientation. You can also detect and parse several barcodes in different formats at the same time.



Required Android API Levels
===========================

We recommend setting your app's *Target Framework* and *Target Android version* to **Android 5.0 (API Level 21)** or higher in your app project settings.

This Google Play Service SDK's requires a *Target Framework* of at least Android 4.1 (API Level 16) to compile.

You may still set a lower *Minimum Android version* (as low as Android 2.3 - API Level 9) so your app will run on older versions of Android, however you must ensure you do not use any API's at runtime that are not available on the version of Android your app is running on.




Android Manifest 
================

Some Google Play Services APIs require specific metadata, attributes, permissions or features to be declared in your *AndroidManifest.xml* file.

These can be added manually to the *AndroidManifest.xml* file, or merged in through the use of assembly level attributes.


If you want to use the Live camera feed with the Vision APIs, you will need to declare the *Camera* permission to work correctly.  You can have this automatically added to your *AndroidManifest.xml* file by including the following assembly level attribute:

```csharp
[assembly: UsesPermission (Android.Manifest.Permission.Camera)]
```



Samples
=======

You can find a Sample Application within each Google Play Services component.  The sample will demonstrate the necessary configuration and some basic API usages.






Learn More
==========

You can learn more about the various Google Play Services SDKs & APIs by visiting the official [Google APIs for Android][3] documentation


You can learn more about Google Play Services Vision by visiting the official [Mobile Vision API for Android](https://developers.google.com/vision/) documentation.



[1]: https://console.developers.google.com/ "Google Developers Console"
[2]: https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/MD5_SHA1/ "Finding your SHA-1 Fingerprints"
[3]: https://developers.google.com/android/ "Google APIs for Android"

