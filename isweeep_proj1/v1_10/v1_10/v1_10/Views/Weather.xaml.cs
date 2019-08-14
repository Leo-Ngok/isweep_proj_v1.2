using SkiaSharp;
using SQLite;
using System;
using System.Linq;
using v1_10.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
 

namespace v1_10.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class Weather : ContentPage
    {
        public Weather()
        {
            InitializeComponent();           
        }
        public static string DBPATH = "";
        
        
        public Weather(string DB_path)
        {
            DBPATH = DB_path;
            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection dbconn = new SQLiteConnection(App.settingpath);
            try
            {
                var info = dbconn.Table<settingsdata>().ToList().First();
                weatherchart.SecondaryAxis.LabelStyle.LabelFormat = "##.#" + DB_weather.tempunit(info._temp);
                List<weatherkey> showdata = new DB_weather().WeatherInfo;
                if(info._temp==temp.Fahrenheit)
                {
                    foreach (var item in showdata)
                    {
                    item.MaxTemp_level = DB_weather.celtofah(item.MaxTemp_level);
                    item.MinTemp_level = DB_weather.celtofah(item.MinTemp_level);
                    }
                }
                maxtempdata.ItemsSource = showdata;
                maxtempdata.YBindingPath = "MaxTemp_level";
                maxtempdata.XBindingPath = "date";
                mintempdata.ItemsSource = showdata;
                mintempdata.YBindingPath = "MinTemp_level";
                mintempdata.XBindingPath = "date";
            }
            catch (Exception) { }
        }
        
    }
}