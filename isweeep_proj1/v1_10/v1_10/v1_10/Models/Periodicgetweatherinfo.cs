using Matcha.BackgroundService;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MOWeatherCore;

namespace v1_10.Models
{
    class Periodicgetweatherinfo:IPeriodicTask
    {
        public Periodicgetweatherinfo(int duration)
        {
            Interval = TimeSpan.FromSeconds(duration);
        }
        public TimeSpan Interval { get; set; }
        int i = 0;
        //TimeSpan time = new SQLite.SQLiteConnection(App.settingpath).Table<settingsdata>().ToList()[0].alerttime;
        public async Task<bool> StartJob()
        {
            //var state = DateTime.Now.Hour == time.Hours && DateTime.Now.Minute == time.Minutes && DateTime.Now.Second == time.Seconds;
            //if (DateTime.Now.Second%10==0) {
                //i++;
                //CrossLocalNotifications.Current.Show("CVD Calculator", "hello world :" + i.ToString(), i);

                //var w = new WeatherCore();
               // AirQuality data = (await w.GetAirQualityFromMacauWeather())[0];
                //var forecast = await w.GetWeatherForecast();
                //weatherkey saveddata = new weatherkey()
                //{
                //    date = data.date,
                //    //MinTemp_level=data.
               // };
                //forecast[0].WeatherStatus;
             //}
            return true;
        }
    }
}
