using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using v1_10.Models;
using System.Collections.Generic;

namespace v1_10.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        int lang=-1;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try { lang = (int)new SQLite.SQLiteConnection(App.settingpath).Table<settingsdata>().ToList()[0].language; } catch (Exception) { }
            
            if (lang!=-1)
            {
                Title = new string[] { "Home", "主頁", "主页" }[lang];
                onlybtn.Text = new string[] { "Get CVD index immediately", "立即獲得CVD指數", "立即获得CVD指数" }[lang];                   
            }
            else
            {
                Title = "Home";
                onlybtn.Text = "Get CVD index immediately";
            }
            setlabeltext();                
        }
        private void setlabeltext()
        {
            List<weatherkey> b=new List<weatherkey>();
            try{ b= new SQLite.SQLiteConnection(App.legacyweatherDBpath).Table<weatherkey>().ToList(); } catch (Exception) { b.Add(new weatherkey() { CVD_idx = 0 }); };
            
            if (lang!= -1)
            {
                if (b[0].CVD_idx!= 0)
                    debuglabel.Text = new string[] { "Your current CVD index is " ,"您目前的CVD指數為 ","您目前的CVD指数为 "}[lang] + b[b.Count - 1].CVD_idx.ToString();
                debuglabel.Text += "\n" + new string[] { "Please press the button above to refresh the CVD index.", "請按以上按鈕以更新CVD指數", "请按以上按钮以更新指数" }[lang];
            }
            else
            {
                if (b[0].CVD_idx != 0)
                    debuglabel.Text =  "Your current CVD index is " + b[b.Count - 1].CVD_idx.ToString();
                debuglabel.Text += "\nPlease press the button above to refresh the CVD index.";
            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Task.Run(()=> { App.calcvdAsync(); });
            System.Threading.Thread.Sleep(5000);
            if(debuglabel.Text!=string.Empty)
                setlabeltext();

        }
        
    }
}