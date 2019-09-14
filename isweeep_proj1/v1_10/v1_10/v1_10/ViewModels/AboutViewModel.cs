using System;
using System.Windows.Input;
using SQLite;
using v1_10.Models;
using Xamarin.Forms;

namespace v1_10.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            int idx = (int)new SQLiteConnection(App.settingpath).
                Table<settingsdata>().ToList()[0].language;
            Title = new string[] { "About", "關於", "关于" }[idx];
            
            mullang = new string[] 
            {
                new string[]{ "CVD risk index calculator",
                    "CVD 風險計算器","CVD 风险计算器" }[idx],
                new string[]{ "This app is for reference only, ",
                    "此應用程式所提供的資料僅供參考，",
                    "此程序所提供的资料僅供参考，" }[idx],
                new string[]{ "NOT","不可", "不可" }[idx],
                new string[]{ " a substitution for the advice of a medical professional",
                    "作為專業的醫學意見", "作为专业的医学意见" }[idx],
                new string[]{"For more information, please visit",
                    "更多有關的資訊，請參閱", "更多有关的资讯，请参阅" }[idx],
                new string[]{"our project on github", "我們在github上的專案" ,
                    "我们在github上的专案" }[idx],
                new string[]{ "Feel free to give any feedback and recommendations.",
                    "歡迎對本應用提出意見/反饋，" ,
                    "欢迎对本程序提出意见/反馈，" }[idx],
                new string[]{ "Press me ","請按此","请按此" }[idx],
                new string[]{ "for more details.","以取得更多資訊", "以取得更多资讯"}[idx]
            };
            Android.Util.Log.Debug("aboutcontent", mullang[0]);
            Android.Util.Log.Debug("titlecontent", Title);
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));

        }
        public string[] mullang {get;}
        public ICommand OpenWebCommand { get; }
        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new Uri(url));
        });
    }
}