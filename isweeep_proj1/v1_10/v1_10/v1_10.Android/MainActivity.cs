using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Xamarin.Forms;
using Matcha.BackgroundService.Droid;
using Xamarin.Forms.PlatformConfiguration;

namespace v1_10.Droid
{
    [Activity(Label = "v1_10", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
                StrictMode.ThreadPolicy policy =
                    new StrictMode.ThreadPolicy.Builder().PermitAll().Build();
                StrictMode.SetThreadPolicy(policy);
            
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            BackgroundAggregator.Init(this);
            string filename = "weather_db.sqlite";
            string filelocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string full_path = Path.Combine(filelocation, filename);

            string settings_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "settings_db.sqlite");
            string lgw_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "lgweather_db.sqlite");
            string fw_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "fweather_db.sqlite");
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App(full_path, settings_path,lgw_path,fw_path));
            AiForms.Renderers.Droid.SettingsViewInit.Init(); // need to write here
        }
        
    }
}