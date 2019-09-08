using MOWeatherCore;
using SQLite;
using System;
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
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
                
            debuglabel.Text = "Hello World";
            

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //await Task.Run(()=>
            work_at_desire_time();
             //);
        }
        public async void
       work_at_desire_time()
        {
            int[][] holiday =
            { new int[] { 1 },
            new int[]{5,6,7},
            new int[]{},
            new int[]{5,19,20},
            new int[]{1,12},
            new int[]{7},
            new int[]{},
            new int[]{},
            new int[]{14},
            new int[]{1,2,7},
            new int[]{2},
            new int[]{8,20,22,24,25}
            };
            bool isholiday = holiday[DateTime.Now.Month - 1].Contains(DateTime.Now.Day);
            SQLiteConnection conn = new SQLiteConnection(App.DBPATH);
            double cvd_idx=0;
            
            var data = new WeatherCore();
            
            List<AirQuality> aq = await data.GetAirQualityFromMacauWeather();
            
            try
            {
                var c = conn.Table<DB_pdata>().ToList()[0];
                conn.Close();
                List<MOWeatherCore.Weather> wf = await data.GetWeatherForecast();
                var todaytemp = (wf[0].HighestTemperature + wf[0].LowestTemperature) / 2;
                cvd_idx = calcvd(c, todaytemp, aq);
                using (SQLiteConnection db = new SQLiteConnection(App.futureweatherDBpath))
                {
                    db.CreateTable<weatherDB>();
                    try { db.DeleteAll<weatherDB>(); } finally { }
                    weatherDB w;
                    foreach (var q in wf)
                    {
                        w = new weatherDB()
                        {
                            date = q.Date,
                            maxtemp = q.HighestTemperature,
                            maxhum = q.HighestHumidity,
                            mintemp = q.LowestTemperature,
                            minhum = q.LowestHumidity,
                        };
                        db.Insert(w);
                    }

                }
            }
            catch(Exception) { }
            conn.Close();
            await DisplayAlert("cvd idx", cvd_idx.ToString(), "Cancel");
        }
        Func<double, double, double, double>
            getwmean = (x, y, z) =>
        (11.4 * x + 13.9 * y + 8.6 * z) /
        (11.4 * Math.Sign(x) + 13.9 * Math.Sign(y) + 8.6 * Math.Sign(z));
        Func<double, double> relu = (x) => Math.Max(x, 0.0);
        double std(string x)
        {
            if (x == "null") return 0;
            if (x == null) return 0;
            return double.Parse(x);
        }
        private double calcvd(DB_pdata c, double tem, List<AirQuality> aq)
        {
            DateTime td = DateTime.Today;
            Func<int, int> f = x => (x < 0) ? -1 : 0;


            double age = (DateTime.Today.Year - c.dob.Year) + f(td.Month - c.dob.Month) + f(td.Day - c.dob.Day);
            double height = c.heig;
            double weight = c.weig;
            bool gender = c.genD;
            double SP = c.Sbp;
            double DP = c.Dbp;
            double CL = c.Cho;
            double BH = c.hdll;
            bool is_smoker = c.smoK;
            bool is_diabetic = c.diaB;

            //String is_under_treatment = input_str("Do you need to be taking hypertension medication?\n(Y/N)");
            //double bmi = BMI(weight, height);
            double temp = tem;
            double frs = 0;
            double pm_2_5 = getwmean((std(aq[0].HE_PM2_5) + std(aq[1].HE_PM2_5)) / 2,
                (std(aq[2].HE_PM2_5) + std(aq[3].HE_PM2_5)) / 2,
                (std(aq[4].HE_PM2_5) + std(aq[5].HE_PM2_5)) / 2);
            double pm_10 = getwmean((std(aq[0].HE_PM10) + std(aq[1].HE_PM10)) / 2,
                (std(aq[2].HE_PM10) + std(aq[3].HE_PM10)) / 2,
                (std(aq[4].HE_PM10) + std(aq[5].HE_PM10)) / 2);
            double so2 = 0;/*getwmean((std(aq[0].HE_SO2) + std(aq[1].HE_SO2)) / 2,
                (std(aq[2].HE_SO2) + std(aq[3].HE_SO2)) / 2,
                (std(aq[4].HE_SO2) + std(aq[5].HE_SO2)) / 2);*/
            double no2 = 0;/*getwmean((std(aq[0].HE_NO2) + std(aq[1].HE_NO2)) / 2,
                (std(aq[2].HE_NO2) + std(aq[3].HE_NO2)) / 2,
                (std(aq[4].HE_NO2) + std(aq[5].HE_NO2)) / 2);*/
            //age factor=====================================
            if (age >= 30 && age < 35) frs--;
            else if (age >= 40 && age < 45) frs++;
            else if (age >= 45 && age < 50) frs += 2;
            else if (age >= 50 && age < 55) frs += 3;
            else if (age >= 55 && age < 60) frs += 4;
            else if (age >= 60 && age < 65) frs += 5;
            else if (age >= 65 && age < 70) frs += 6;
            else if (age >= 70 && age < 75) frs += 7;
            //cholesterol level===============================
            if (CL < 160) frs -= 3;
            else if (CL >= 160 && CL < 200) frs += 0;
            else if (CL >= 200 && CL < 240) frs++;
            else if (CL >= 240 && CL < 280) frs += 2;
            else frs += 3;
            //blood HDL=======================================
            if (BH < 35) frs += 2;
            else if (BH >= 35 && BH < 45) frs++;
            else if (BH >= 45 && BH < 60) frs += 0;
            else frs -= 2;
            //blood pressure==================================
            if (SP >= 160 || DP >= 100) frs += 3;
            else if (SP >= 140 || DP >= 90) frs += 2;
            else if (SP >= 130 || DP >= 85) frs++;
            //else frs += 0;
            //is_diabetic=====================================
            if (is_diabetic) frs += 2;
            //is_smoker=======================================
            if (is_smoker) frs += 2;
            //temperature=====================================
            if (temp > 26) frs *= Math.Pow(1.17, (temp - 26));
            else if (temp < 26) frs *= Math.Pow(1.12, (-temp + 26));
            //air quality=====================================
            if (pm_2_5 > 96.2) frs *= Math.Pow(1.27, (pm_2_5 - 96.2) / 10);
            if (pm_10 > 115.6 && age >= 65) frs *= Math.Pow(1.012, (pm_10 - 115.6) / 10);
            if (so2 >= 53.21) frs *= Math.Pow(1.01, (so2 - 53.21));
            if (no2 >= 53.08) frs *= Math.Pow(1.019, (no2 - 53.08));
            return frs;
        }
    }
}