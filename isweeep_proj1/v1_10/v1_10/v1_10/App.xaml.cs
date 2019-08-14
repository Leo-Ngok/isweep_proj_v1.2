using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using v1_10.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace v1_10
{
    public partial class App : Application
    {

        public static string DBPATH = "";
        public static string settingpath = "";
        public static string legacyweatherDBpath = "";
        public static string futureweatherDBpath = "";
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
        public App(string dbp,string stp,string lwp,string fwp)
        {
            InitializeComponent();
            DBPATH = dbp;
            settingpath = stp;
            legacyweatherDBpath = lwp;futureweatherDBpath = fwp;
            MainPage = new MainPage();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            new Page().DisplayAlert("Note", "Are you sure you want to quit the app?", "yes", "no");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        
    }
}
