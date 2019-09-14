using v1_10.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace v1_10.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {

        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        string[][] text = {new string[] {"Home","主頁","主页"},
        //new string[]{"Record","記錄","记录"},
        //new string[]{"Weather Forecast","天氣預告","天气预告"},
        new string[]{"Intereval Timer","區間計時器","区间计时器" },
        new string[]{"Profile","個人檔案","个人档案" },
        new string[]{ "Configurations","設定","设定"},
        new string[]{"About","關於","关于" } };
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {               
                new HomeMenuItem{Id= MenuItemType.Home ,Title="Home"},
               // new HomeMenuItem{Id= MenuItemType.Record ,Title="Record"},
                //new HomeMenuItem{Id=MenuItemType.Weather,Title="Weather Forecast"},
                new HomeMenuItem {Id= MenuItemType.Interval_Timer,Title="Interval Timer"}, 
                new HomeMenuItem {Id=MenuItemType.Profile,Title="Profile"},
                new HomeMenuItem {Id=MenuItemType.Configurations,Title="Configurations"},
                new HomeMenuItem {Id = MenuItemType.About, Title="About"}
            };
            Android.Util.Log.Debug("string1", menuItems[0].Title);
            ListViewMenu.ItemsSource = menuItems;
            //ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null) return ;
                int id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
        protected override void OnAppearing()
        {
            try { updatetext(); } catch(Exception) { }
            base.OnAppearing();
        }
        public void updatetext()
        {
            try
            {
                int p = (int)new SQLiteConnection(App.settingpath).Table<settingsdata>().ToList().First().language;
                for (int i = 0; i < 5; i++)
                    menuItems[i].Title = text[i][p];
                ListViewMenu.ItemsSource = menuItems;
            }
            catch(Exception) { }
        }
        public void appearanddisappear()
        {
            OnAppearing();
            OnDisappearing();
        }
    }
}