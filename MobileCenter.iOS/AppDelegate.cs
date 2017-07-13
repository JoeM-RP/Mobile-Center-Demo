using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Microsoft.Azure.Mobile.Distribute;
using UIKit;

namespace Mobile_Center.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

			#region Appearance
			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(82,151,214);
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				TextColor = UIColor.White
			});
			UINavigationBar.Appearance.TintColor = UIColor.White;

			UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
                TextColor = UIColor.Black
            }, UIControlState.Normal);
			#endregion

			global::Xamarin.Forms.Forms.Init();
            Distribute.DontCheckForUpdatesInDebug();    // Must be called before "Load Application"
            LoadApplication(new App());

#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			var result = base.FinishedLaunching(app, options);

            // Set tint for jump list
            app.KeyWindow.TintColor = UIColor.FromRGB(82, 151, 214);

			return result;
        }
    }
}
