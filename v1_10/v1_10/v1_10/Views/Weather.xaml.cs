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
        Language lang;
        string[] weathertext = new string[3] { "Weather", "天氣", "天气" };
        string[] temptitle = new string[3] {"Temperature of the next 5 days",
        "未來五天溫度","未来五天温度"};
        string[] tempyaxis = new string[3] { "Temperature", "溫度", "温度" };
        string[] tempxaxis = new string[3] { "Date", "日期", "日期" };
        string[] humyaxis = new string[3] { "Humidity", "濕度", "湿度" };
        string[] humtitle = new string[3] { "Humidity of the next 5 days",
            "未來五天濕度", "未来五天湿度" };

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
            var info = dbconn.Table<settingsdata>().ToList().First();
            lang = info.language;
            try
            {
                weatherchart.SecondaryAxis.LabelStyle.LabelFormat = "##.#" +
                    DB_weather.tempunit(info._temp);
                List<weatherDB> showdata = new SQLiteConnection(App.futureweatherDBpath)
                    .Table<weatherDB>().ToList();
                if (info._temp == temp.Fahrenheit)
                {
                    foreach (var item in showdata)
                    {
                        item.maxtemp = DB_weather.celtofah(item.maxtemp);
                        item.mintemp = DB_weather.celtofah(item.mintemp);
                    }
                }
                maxtempdata.ItemsSource = showdata;
                maxtempdata.YBindingPath = "maxtemp";
                maxtempdata.XBindingPath = "date";
                mintempdata.ItemsSource = showdata;

                mintempdata.YBindingPath = "mintemp";
                mintempdata.XBindingPath = "date";
            }
            catch(Exception){ }
            int p = (int)lang;
            Title = weathertext[p];
            weatherchart.Title.Text = temptitle[p];
            weatherchart.SecondaryAxis.Title.Text = tempyaxis[p];
            weatherchart.PrimaryAxis.Title.Text = tempxaxis[p];
            humchart.Title.Text = humtitle[p];
            humchart.SecondaryAxis.Title.Text = humyaxis[p];
            humchart.PrimaryAxis.Title.Text = tempxaxis[p];
            
        }

    }

}
