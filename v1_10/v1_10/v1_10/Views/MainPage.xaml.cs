using v1_10.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace v1_10.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            
            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
            
        }
        public MainPage(bool loadlang)
        {
            Navigation.PushModalAsync(new startpage());
        }
        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new Personal_Information()));
                        break;
                    case (int)MenuItemType.Configurations:
                        MenuPages.Add(id, new NavigationPage(new Configs()));
                        break;
                    case (int)MenuItemType.Interval_Timer:
                        MenuPages.Add(id, new NavigationPage(new Interval_Timer()));
                        break;
                    case (int)MenuItemType.Record:
                        MenuPages.Add(id, new NavigationPage(new Record()));
                        break;
                    case (int)MenuItemType.Weather:
                        MenuPages.Add(id, new NavigationPage(new Weather()));
                        break;
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new Home()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(0);

                IsPresented = false;
            }
        }
    }
}