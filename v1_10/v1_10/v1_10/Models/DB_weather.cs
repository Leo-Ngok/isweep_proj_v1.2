using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace v1_10.Models
{
    class weatherkey
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get;}
        public DateTime date { get; set; }
        public double SO2_level { get; set; }
        public double CO_level { get; set; }
        public double NO2_level { get; set; }
        public double PM2_5_level { get; set; }
        public double PM_10_level { get; set; }
        public double MinTemp_level { get; set; }
        public double MaxTemp_level { get; set; }
        public double Hum_level { get; set; }
        public double O3_level { get; set; }
        public double CVD_idx { get; set; }

    }
    class DB_weather
    {
        public List<weatherkey> WeatherInfo { get; set; }
        public DB_weather()
        {
            WeatherInfo = new List<weatherkey>();
            
            WeatherInfo.Add(new weatherkey { date = new DateTime(1999, 2, 15), MinTemp_level = 17,   MaxTemp_level = (25),   SO2_level = 0,     CO_level = 1.8, NO2_level = 32, PM2_5_level = 17, PM_10_level = 32, Hum_level = 0.8, O3_level = 20 });
            WeatherInfo.Add(new weatherkey { date = new DateTime(1999, 2, 16), MinTemp_level = 17.3, MaxTemp_level = (26.5), SO2_level = 0.8,   CO_level = 1.6, NO2_level = 35, PM2_5_level = 7, PM_10_level = 29, Hum_level = 0.82, O3_level = 29 });
            WeatherInfo.Add(new weatherkey { date = new DateTime(1999, 2, 17), MinTemp_level = 16.6, MaxTemp_level = (25.8), SO2_level = 0.3,   CO_level = 1.3, NO2_level = 40, PM2_5_level = 12, PM_10_level = 21, Hum_level = 0.81, O3_level = 41 });
            WeatherInfo.Add(new weatherkey { date = new DateTime(1999, 2, 18), MinTemp_level = 16.9, MaxTemp_level = (27),   SO2_level = 0.5,   CO_level = 1.05,NO2_level = 33, PM2_5_level = 14, PM_10_level = 27, Hum_level = 0.76, O3_level = 36 });
            WeatherInfo.Add(new weatherkey { date = new DateTime(1999, 2, 19), MinTemp_level = 19.1, MaxTemp_level = (29.3), SO2_level = 0.73,   CO_level = 0.8, NO2_level = 28, PM2_5_level = 8, PM_10_level = 27, Hum_level = 0.73, O3_level = 25 });
            WeatherInfo.Add(new weatherkey { date = new DateTime(1999, 2, 20), MinTemp_level = 18.2, MaxTemp_level = (26),   SO2_level = 1,     CO_level = 0.4, NO2_level = 23, PM2_5_level = 6, PM_10_level = 43, Hum_level = 0.76, O3_level = 27 });
            WeatherInfo.Add(new weatherkey { date = new DateTime(1999, 2, 21), MinTemp_level = 13.6,   MaxTemp_level = (25.2), SO2_level = 1.2,   CO_level = 0.2, NO2_level = 27, PM2_5_level = 11, PM_10_level = 36, Hum_level = 0.75, O3_level = 17 });
        }
        public static string tempunit(temp tem)
        {
            if (tem == temp.Celsius) return "°C";
            else if (tem == temp.Fahrenheit) return "°F";
            throw new Exception();
        }
        public static double celtofah(double value)
        {
            return 1.8 * value + 32;
        }
    }

}
