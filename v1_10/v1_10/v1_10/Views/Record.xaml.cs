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
        Language lang;
        string[][] text = { new string[] { "Show records","顯示記錄", "显示记录" },
        new string[] { "Temperature (Trend)","溫度 (趨勢)","温度 (趋势)"},
        new string[] { "Temperature","溫度","温度"},
        new string[] { "Date","日期","日期"},
        new string[] { "Humidity (Trend)","濕度 (趨勢)","湿度 (趋势)"},
        new string[] { "Humidity","濕度","湿度"},
        new string[] { "PM 2.5 (Trend)","PM 2.5 (趨勢)","PM 2.5 (趋势)"},
        new string[] { "PM 2.5 conc.","PM 2.5 濃度","PM 2.5 浓度"},
        new string[] { "PM 10 (Trend)","PM 10 (趨勢)","PM 10 (趋势)"},
        new string[] { "PM 10 conc.","PM 10 濃度","PM 10 浓度"},
        new string[] { "SO₂ (Trend)", "SO₂ (趨勢)", "SO₂ (趋势)"},
        new string[] {  "SO₂ conc.", "SO₂ 濃度", "SO₂ 浓度"},
        new string[] { "CO (Trend)","CO (趨勢)","CO (趋势)"},
        new string[] {  "CO conc.", "CO 濃度", "CO 浓度"},
        new string[] { "NO₂ (Trend)", "NO₂ (趨勢)", "NO₂ (趋势)"},
        new string[] {  "NO₂ conc.", "NO₂ 濃度", "NO₂ 浓度"},
        new string[] { "O₃ (Trend)", "O₃ (趨勢)", "O₃ (趋势)"},
        new string[] {  "O₃ conc.", "O₃ 濃度", "O₃ 浓度"},
        new string[] {  "Past records", "過往記錄", "过往记录"},
        new string[]{ "Error","錯誤","错误"},
        new string[]{  "The interval should be greater than 2 days",
            "間距應超過兩天", "间距应该超过两天" },
        new string[]{"retry","重試","重试" } };
        public Record()
        {
            InitializeComponent();
            Mindate.MinimumDate = new DateTime(1999, 2, 15);
            Mindate.MaximumDate = new DateTime(1999, 2, 21);
            Maxdate.MinimumDate = new DateTime(1999, 2, 15);
            Maxdate.MaximumDate = new DateTime(1999, 2, 21);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection dbconn;
                
            try
            {
                dbconn = new SQLiteConnection(App.settingpath);
                var info = dbconn.Table<settingsdata>().ToList().First();
                lang = info.language;
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
                    var p = (int)lang;
                    showRecordbtn.Text = text[0][p];
                    weatherchart.Title.Text = text[1][p];
                    weatherchart.SecondaryAxis.Title.Text = text[2][p];
                    weatherchart.PrimaryAxis.Title.Text = text[3][p];
                    chart0.Title.Text = text[4][p];
                    chart0.SecondaryAxis.Title.Text = text[5][p];
                    chart0.PrimaryAxis.Title.Text = text[3][p];
                    chart1.Title.Text = text[6][p];
                    chart1.SecondaryAxis.Title.Text = text[7][p];
                    chart1.PrimaryAxis.Title.Text = text[3][p];
                    chart2.Title.Text = text[8][p];
                    chart2.SecondaryAxis.Title.Text = text[9][p];
                    chart2.PrimaryAxis.Title.Text = text[3][p];
                    chart3.Title.Text = text[10][p];
                    chart3.SecondaryAxis.Title.Text = text[11][p];
                    chart3.PrimaryAxis.Title.Text = text[3][p];
                    chart4.Title.Text = text[12][p];
                    chart4.SecondaryAxis.Title.Text = text[13][p];
                    chart4.PrimaryAxis.Title.Text = text[3][p];
                    chart5.Title.Text = text[14][p];
                    chart5.SecondaryAxis.Title.Text = text[15][p];
                    chart5.PrimaryAxis.Title.Text = text[3][p];
                    chart6.Title.Text = text[16][p];
                    chart6.SecondaryAxis.Title.Text = text[17][p];
                    chart6.PrimaryAxis.Title.Text = text[3][p];
                    Title = text[18][p];

                }
            }

            catch (Exception) { }
        }

        private void ShowRecordbtn_Clicked(object sender, EventArgs e)
        {
            var day = Maxdate.Date - Mindate.Date;
            if (day.Days < 2)
            {
                var p = (int)lang;
                DisplayAlert(text[19][p], text[20][p], text[21][p]);
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
            var dp = showdata.Where((x) => x.date >= Mindate.Date && x.date <= Maxdate.Date);
            maxtempdata.ItemsSource = dp;
            mintempdata.ItemsSource = dp;
            maxtempdata.YBindingPath = "MaxTemp_level";
            maxtempdata.XBindingPath = "date";
            mintempdata.YBindingPath = "MinTemp_level";
            mintempdata.XBindingPath = "date";

            humi.ItemsSource = dp;
            humi.YBindingPath = "Hum_level";
            humi.XBindingPath = "date";
            PM2_5.ItemsSource = dp;
            PM2_5.YBindingPath = "PM2_5_level";
            PM2_5.XBindingPath = "date";
            PM10.ItemsSource = dp;
            PM10.YBindingPath = "PM_10_level";
            PM10.XBindingPath = "date";
            SO2.ItemsSource = dp;
            SO2.YBindingPath = "SO2_level";
            SO2.XBindingPath = "date";
            CO.ItemsSource = dp;
            CO.YBindingPath = "CO_level";
            CO.XBindingPath = "date";
            NO2.ItemsSource = dp;
            NO2.YBindingPath = "NO2_level";
            NO2.XBindingPath = "date";
            O3.ItemsSource = dp;
            O3.YBindingPath = "O3_level";
            O3.XBindingPath = "date";



        }
        private void updaterecord()
        {
            SQLiteConnection oldrecord = new SQLiteConnection(App.legacyweatherDBpath);
            SQLiteConnection futurerecord = new SQLiteConnection(App.futureweatherDBpath);
        }
    }
}
