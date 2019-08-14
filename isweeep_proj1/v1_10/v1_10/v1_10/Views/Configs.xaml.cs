using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using v1_10.Models;

namespace v1_10.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configs : ContentPage
    {
        public Configs()
        {
            InitializeComponent();
            SQLiteConnection dbconn = new SQLiteConnection(App.settingpath);
            try
            {
                settingsdata settinginfo = dbconn.Table<settingsdata>().ToList().First();
                Weightset.Detail = settinginfo.weight.ToString();
                Heightset.Detail = settinginfo.height.ToString();
                Bpset.Detail = settinginfo.bp.ToString();
                Tpset.Detail = settinginfo._temp.ToString();
                timeofalert.Time = settinginfo.alerttime;
                weatheroption.On = settinginfo.walert;
                otheroption.On = settinginfo.oalert;
            }
            catch (Exception)
            {
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SQLiteConnection dbconn = new SQLiteConnection(App.settingpath);
            dbconn.CreateTable<settingsdata>();

            settingsdata settinginfo = new settingsdata()
            {
                height = toheightunit(Heightset.Detail),
                weight = toweightunit(Weightset.Detail),
                bp = tobpunit(Bpset.Detail),
                _temp = totempunit(Tpset.Detail),
                alerttime = timeofalert.Time,
                walert = weatheroption.On,
                oalert = otheroption.On
            };
            try
            {
                dbconn.DeleteAll<settingsdata>();
            }
            catch (Exception) { }
            dbconn.Insert(settinginfo);
            dbconn.Dispose();
        }

        private weight toweightunit(string strval)
        {
            if (strval == "Kilogram") return weight.Kilogram;
            if (strval == "Pounds") return weight.Pounds;
            return weight.None;
        }
        private height toheightunit(string strval)
        {
            if (strval == "Meter") return height.Meter;
            if (strval == "Feet") return height.Feet;
            return height.None;
        }
        private bp tobpunit(string strval)
        {
            if (strval == "mmHg") return bp.mmHg;
            if (strval == "kPa") return bp.kPa;
            return bp.None;
        }
        public static temp totempunit(string strval)
        {
            if (strval == "Celsius") return temp.Celsius;
            if (strval == "Fahrenheit") return temp.Fahrenheit;
            return temp.None;
        }
        private async void TextCell_Tapped(object sender, EventArgs e)
        {
            string unit = await DisplayActionSheet("Unit of weight", "Cancel", null, "Kilogram", "Pounds");
            if (unit != null)
                Weightset.Detail = unit;
        }
        private async void Heightset_Tapped(object sender, EventArgs e)
        {
            string unit = await DisplayActionSheet("Unit of height", "Cancel", null, "Meter", "Feet");
            if (unit != null)
                Heightset.Detail = unit;
        }
        private async void Bpset_Tapped(object sender, EventArgs e)
        {
            string unit = await DisplayActionSheet("Unit of Blood pressure", "Cancel", null, "mmHg", "kPa");
            if (unit != null) Bpset.Detail = unit;
        }
        private async void Tpset_Tapped(object sender, EventArgs e)
        {
            string unit = await DisplayActionSheet("Unit of Temperature", "Cancel", null, "Celsius", "Fahrenheit");
            if (unit != null)
                Tpset.Detail = unit;          
        }


        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
                if (answer) await this.Navigation.PopAsync(); // or anything else
            });

            return true;

        }
    }
}
