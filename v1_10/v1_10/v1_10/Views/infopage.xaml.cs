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
	public partial class infopage : ContentPage
	{
		public infopage ()
		{
			InitializeComponent ();
            
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            int lang;
            using(var conn=new SQLite.SQLiteConnection(App.settingpath))
                lang = (int)conn.Table<settingsdata>().ToList()[0].language;

            description.Text = new string[]{"To start using the app,\n" +
                "you need to configure the personal information" +
                " and other data, \nso let's get started",
                "在開始使用本應用程式前，\n請先設定個人資料。\n請按下一步繼續。",
                "在开始使用本程序前，\n请先设定个人资料。\n请按下一步继续。" }[lang];
            btnnext.Text = new string[] { "Next", "下一步", "下一步" }[lang];
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}