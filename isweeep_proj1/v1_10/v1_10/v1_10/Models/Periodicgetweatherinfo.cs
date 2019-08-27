using Matcha.BackgroundService;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<bool> StartJob()
        {
            if (DateTime.Now.Second % 5 == 0)
                i++;
                CrossLocalNotifications.Current.Show("CVD Calculator", "hello world :"+i.ToString(),i);
            return true;
            
        }
    }
}
