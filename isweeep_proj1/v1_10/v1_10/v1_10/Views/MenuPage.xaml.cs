﻿using v1_10.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace v1_10.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse"},
                new HomeMenuItem{Id= MenuItemType.Home ,Title="Home"},
                new HomeMenuItem{Id= MenuItemType.Record ,Title="Record"},
                new HomeMenuItem{Id=MenuItemType.Weather,Title="Weather"},
                new HomeMenuItem {Id= MenuItemType.Interval_Timer,Title="Interval Timer"}, 
                new HomeMenuItem {Id=MenuItemType.Profile,Title="Profile"},
                new HomeMenuItem {Id=MenuItemType.Configurations,Title="Configurations"},
                new HomeMenuItem {Id = MenuItemType.About, Title="About"}
            };
            ListViewMenu.ItemsSource = menuItems;
            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null) return ;
                int id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}