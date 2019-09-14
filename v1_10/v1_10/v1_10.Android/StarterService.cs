using System;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;

namespace v1_10.Droid
{
    [Service]
    class StarterService:Service
    {
        Timer timer = new Timer(800);
        private const string TAG = "MyService";
        public override void OnCreate()
        {
            base.OnCreate();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                startMyOwnForeground();
            else
                StartForeground(1, new Notification());
            timer.Elapsed += (sender, e) =>
            {
              if((DateTime.Now.Hour +1)%6==0&&DateTime.Now.Minute==0&&DateTime.Now.Second==0) App.calcvdAsync();
            };
            timer.Start();
        }
        public override void OnDestroy(){}
        private void startMyOwnForeground()
        {
            string channelid = "com.yw.cvdcalc";
            string channelname = "service1";
            NotificationChannel channel = new NotificationChannel(channelid,
                channelname, NotificationImportance.None);
            channel.LightColor = Color.LightBlue;
            channel.LockscreenVisibility = NotificationVisibility.Private;
            NotificationManager manager = (NotificationManager)GetSystemService(NotificationService);
            if (manager == null) return;
            manager.CreateNotificationChannel(channel);
            StartForeground(2,new NotificationCompat.Builder(this, channelid)
                .SetOngoing(true).SetContentTitle("App is running")
                .SetPriority((int)NotificationImportance.Max)
                .SetCategory(Notification.CategoryService).Build());
        }
        public override IBinder OnBind(Intent intent) => null;        
    }
}