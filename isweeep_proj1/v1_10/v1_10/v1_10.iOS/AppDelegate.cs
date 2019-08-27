using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Foundation;
using UIKit;
using UserNotifications;
using Xamarin.Forms;
using Matcha.BackgroundService.iOS;

namespace v1_10.iOS
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
            string filename = "weather_db.sqlite";
            string filelocation = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"..","Library");
            string full_path = Path.Combine(filelocation, filename);

            string settings_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"..","Library", "settings_db.sqlite");
            string lgw_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..","Library","lgweather_db.sqlite");
            string fw_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library", "fweather_db.sqlite");
            global::Xamarin.Forms.Forms.Init();
            //AiForms.Renderers.iOS.SettingsViewInit.Init();


            LoadApplication(new App(full_path,settings_path,lgw_path,fw_path));


            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // Ask the user for permission to get notifications on iOS 10.0+
                UNUserNotificationCenter.Current.RequestAuthorization(
                        UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                        (approved, error) => { });
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                // Ask the user for permission to get notifications on iOS 8.0+
                var settings = UIUserNotificationSettings.GetSettingsForTypes(
                        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                        new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }
            BackgroundAggregator.Init(this);
            return base.FinishedLaunching(app, options);
        }
    }
}
