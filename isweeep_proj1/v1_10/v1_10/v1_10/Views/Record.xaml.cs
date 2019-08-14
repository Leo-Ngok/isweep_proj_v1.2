using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v1_10.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace v1_10.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Record : ContentPage
	{
		public Record ()
		{
			InitializeComponent ();
            Mindate.MinimumDate = new DateTime(1999, 2, 15);
            Mindate.MaximumDate = new DateTime(1999, 2, 21);
            Maxdate.MinimumDate = new DateTime(1999, 2, 15);
            Maxdate.MaximumDate = new DateTime(1999, 2, 21);
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection dbconn = new SQLiteConnection(App.settingpath);
            try
            {
                var info = dbconn.Table<settingsdata>().ToList().First();
                List<weatherkey> showdata = new DB_weather().WeatherInfo;

                { 
                
                    weatherchart.SecondaryAxis.LabelStyle.LabelFormat = "##.#" + DB_weather.tempunit(info._temp);                
                    if (info._temp == temp.Fahrenheit)
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
            }

            catch (Exception) { }
        }

        private void ShowRecordbtn_Clicked(object sender, EventArgs e)
        {
            var day = Maxdate.Date - Mindate.Date;
            if(day.Days<2)
            {
                DisplayAlert("Error", "The interval should be greater than one day", "retry");
                return;
            }
            SQLiteConnection dbconn = new SQLiteConnection(App.settingpath);
            var info = dbconn.Table<settingsdata>().ToList().First();
            List<weatherkey> showdata = new DB_weather().WeatherInfo;
            if (info._temp == temp.Fahrenheit)
            {
                foreach (var item in showdata)
                {
                    item.MaxTemp_level = DB_weather.celtofah(item.MaxTemp_level);
                    item.MinTemp_level = DB_weather.celtofah(item.MinTemp_level);
                }
            }
            maxtempdata.ItemsSource = showdata.GetRange(Mindate.Date.Day - 15, day.Days+1);
            mintempdata.ItemsSource = showdata.GetRange(Mindate.Date.Day - 15, day.Days+1);
            maxtempdata.YBindingPath = "MaxTemp_level";
            maxtempdata.XBindingPath = "date";
            mintempdata.YBindingPath = "MinTemp_level";
            mintempdata.XBindingPath = "date";






            humi.ItemsSource = showdata.GetRange(Mindate.Date.Day - 15, day.Days+1);
            humi.YBindingPath = "Hum_level";
            humi.XBindingPath = "date";
            PM2_5.ItemsSource = showdata.GetRange(Mindate.Date.Day - 15, day.Days + 1);
            PM2_5.YBindingPath = "PM2_5_level";
            PM2_5.XBindingPath = "date";
            PM10.ItemsSource = showdata.GetRange(Mindate.Date.Day - 15, day.Days + 1);
            PM10.YBindingPath = "PM_10_level";
            PM10.XBindingPath = "date";
            SO2.ItemsSource = showdata.GetRange(Mindate.Date.Day - 15, day.Days + 1);
            SO2.YBindingPath = "SO2_level";
            SO2.XBindingPath = "date";
            CO.ItemsSource = showdata.GetRange(Mindate.Date.Day - 15, day.Days + 1);
            CO.YBindingPath = "CO_level";
            CO.XBindingPath = "date";
            NO2.ItemsSource = showdata.GetRange(Mindate.Date.Day - 15, day.Days + 1);
            NO2.YBindingPath = "NO2_level";
            NO2.XBindingPath = "date";
            O3.ItemsSource = showdata.GetRange(Mindate.Date.Day - 15, day.Days + 1);
            O3.YBindingPath = "O3_level";
            O3.XBindingPath = "date";



        }
        private void updaterecord()
        {
            SQLiteConnection oldrecord = new SQLiteConnection(App.legacyweatherDBpath);
            SQLiteConnection futurerecord = new SQLiteConnection(App.futureweatherDBpath);
        }
    }
    public class alist : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
