using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using v1_10.Views;
using System.Timers;
using Plugin.LocalNotifications;
using Matcha.BackgroundService;

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

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (( DateTime.Now.Second == 0) ){
                CrossLocalNotifications.Current.Show("CVD Calculator", "test_notification");
            }
        }

        public App(string dbp,string stp,string lwp,string fwp)
        {
            InitializeComponent();
            DBPATH = dbp;
            settingpath = stp;
            legacyweatherDBpath = lwp; futureweatherDBpath = fwp;
            MainPage = new MainPage();
        }
        protected override void OnStart()
        {
            //for more information, visit https://winstongubantes.blogspot.com/2018/09/backgrounding-with-xamarinforms-easy-way.html
            BackgroundAggregatorService.Add(() => new v1_10.Models.Periodicgetweatherinfo(1));
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
        
    }
}
