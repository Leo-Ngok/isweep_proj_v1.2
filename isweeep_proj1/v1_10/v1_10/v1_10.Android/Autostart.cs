using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace v1_10.Droid
{
    [BroadcastReceiver(Enabled =true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class Autostart : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent arg1)
        {
            Intent intent = new Intent(context, typeof(StarterService));
            Toast.MakeText(Application.Context, "broadcast receiver" +
                " is running", ToastLength.Short);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                context.StartForegroundService(intent);            
            else context.StartService(intent);
            
        }
    }
}