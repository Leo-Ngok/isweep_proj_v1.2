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
    public partial class startpage : ContentPage
    {
        public startpage()
        {
            InitializeComponent();
           // Navigation.PushModalAsync(new infopage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var page2=new infopage();
            SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.settingpath);
            conn.CreateTable<settingsdata>();
            try { conn.DeleteAll<settingsdata>(); } catch (Exception) { }
            conn.Insert(new settingsdata() { language = (Language)lang.SelectedIndex });
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new Configs(true));
            Navigation.PushModalAsync(new infopage());
        }
    }
}