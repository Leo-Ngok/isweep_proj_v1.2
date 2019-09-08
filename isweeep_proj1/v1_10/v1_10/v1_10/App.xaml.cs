using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using v1_10.Views;
using System.Timers;
using Plugin.LocalNotifications;
using Matcha.BackgroundService;
using MOWeatherCore;
using SQLite;
using v1_10.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace v1_10
{
    public partial class App : Application
    {

        public static string DBPATH = "";
        public static string settingpath = "";
        public static string legacyweatherDBpath = "";
        public static string futureweatherDBpath = "";
        Timer timer = new Timer(1000);
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
                       
        }
        public App(string dbp,string stp,string lwp,string fwp)
        {
            SQLiteConnection conn = new SQLiteConnection(settingpath);
            conn.CreateTable<settingsdata>();
            if(conn.Table<settingsdata>().ToList().Count == 0)
            {
                conn.Insert(new settingsdata() {
                    language=Language.trad_chi,
                    bp=bp.mmHg,
                    oalert=true,
                    walert=true,
                    height=height.Meter,
                    weight=weight.Kilogram,
                    _temp=temp.Celsius
                });
            }
            InitializeComponent();
            DBPATH = dbp;
            settingpath = stp;
            legacyweatherDBpath = lwp; futureweatherDBpath = fwp;
            MainPage = new MainPage();
        }
        protected override void OnStart()
        {
            //for more information, visit https://winstongubantes.blogspot.com/2018/09/backgrounding-with-xamarinforms-easy-way.html
            BackgroundAggregatorService.Add(() => new Periodicgetweatherinfo(1));
            BackgroundAggregatorService.StartBackgroundService();
            // Handle when your app starts
        }

        protected override void OnSleep()
        {           
            // Handle when your app sleeps
            //Application.Current.Properties["SleepDate"] = DateTime.Now.ToString("0");
            //Current.Properties ["FirstName"]=_backgroundPage.
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        //please copy the codes below
       

        
    }
}
