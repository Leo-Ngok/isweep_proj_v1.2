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
            setcontent();
        }
        public Configs(bool shownextbtn)
        {
            InitializeComponent();
            setcontent();
            btnext.IsVisible = shownextbtn;
            btnext.Clicked += Btnext_Clicked1;
            //Navigation.PushModalAsync(new infopage());
            
        }

        private async void Btnext_Clicked1(object sender, EventArgs e) => await Navigation.PopModalAsync();

        Language lang;
        private void setcontent()
        {
            SQLiteConnection dbconn = new SQLiteConnection(App.settingpath);
            try
            {
                settingsdata settinginfo = dbconn.Table<settingsdata>().ToList().First();
                lang = settinginfo.language;
                Weightset.Detail = fromweightunit(settinginfo.weight);
                Heightset.Detail = fromheightunit(settinginfo.height);
                Bpset.Detail = frombpunit(settinginfo.bp);
                Tpset.Detail = fromtempunit(settinginfo._temp);
                timeofalert.Time = settinginfo.alerttime;
                weatheroption.On = settinginfo.walert;
                otheroption.On = settinginfo.oalert;
                Lang.Detail = fromlang(settinginfo.language);
                var k = (int)lang;
                
                
                    measurementsection.Title = new string[] { "Unit of measurement", "量度單位" , "量度單位" }[k];
                    Weightset.Text = new string[] { "Weight", "體重", "体重" }[k];
                Heightset.Text = new string[] { "Height", "身高", "身高" }[k];
                Bpset.Text = new string[] { "Blood pressure", "血壓", "血压" }[k];
                Tpset.Text = new string[] { "Temperature", "溫度", "温度" }[k];
                Lang.Text = new string[] { "Language", "語言","语言" }[k];
                notifsection.Title = new string[] { "Notification", "通知", "通知" }[k];

                weatheroption.Text = new string[] { "Weather alerts", "顯示天氣", "显示天气" }[k];
                otheroption.Text = new string[] { "Other alerts", "顯示其他通知", "显示其他通知" }[k];
                toatitle.Text = new string[] { "Time of alert", "通知時間", "通知时间" }[k];
                toadetail.Text = new string[] { "When do you want to receive alerts about your health?", "接收天氣通知的時間", "接收天气通知的时间" }[k];

                Title = new string[] { "Preferences", "設定", "设定" }[k];
                btnext.Text = new string[] { "Next", "下一步", "下一步" }[k];

            }
            catch (Exception) { }
            base.OnAppearing();

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            setcontent();
        }
        private void savedata()
        {
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
                oalert = otheroption.On,
                language = tolang(Lang.Detail)
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
            if (strval == "Kilogram" || strval == "公斤") return weight.Kilogram;
            if (strval == "Pounds" || strval == "磅") return weight.Pounds;
            return weight.None;
        }
        public string fromweightunit(weight enumval)
        {
            if (enumval == weight.Kilogram)
                if (lang == Language.English) return "Kilogram";
                else return "公斤";
            else
                if (lang == Language.English) return "Pounds";
            else return "磅";
        }
        private height toheightunit(string strval)
        {
            if (strval == "Meter" || strval == "米") return height.Meter;
            if (strval == "Feet" || strval == "尺") return height.Feet;
            return height.None;
        }
        public string fromheightunit(height enumval)
        {
            if (enumval == height.Feet)
                if (lang == Language.English) return "Feet";
                else return "尺";
            else
                if (lang == Language.English) return "Meter";
            else return "米";
        }
        private bp tobpunit(string strval)
        {
            if (strval == "mmHg" || strval == "毫米汞柱") return bp.mmHg;
            if (strval == "kPa" || strval == "千帕卡") return bp.kPa;
            return bp.None;
        }
        public string frombpunit(bp enumval)
        {
            if (enumval == bp.kPa)
                if (lang == Language.English) return "kPa";
                else return "千帕卡";
            else
                if (lang == Language.English) return "mmHg";
            else return "毫米汞柱";
        }
        public static temp totempunit(string strval)
        {
            if (strval == "Celsius" || strval == "攝氏"||strval== "摄氏") return temp.Celsius;
            if (strval == "Fahrenheit" || strval == "華氏"|| strval == "华氏") return temp.Fahrenheit;
            return temp.None;
        }
        public string fromtempunit(temp enumval)
        {
            if (enumval == temp.Celsius)
                if (lang == Language.English) return "Celsius";
                else if (lang == Language.trad_chi) return "攝氏";
                else return "摄氏";
            else
                if (lang == Language.English) return "Fahrenheit";
                else if (lang == Language.trad_chi) return "華氏";
                else return "华氏";
        }
        public string fromlang(Language enumval)
        {
            if (enumval == Language.English) return "English";
            else if (enumval == Language.trad_chi) return "繁體中文";
            else return "简体中文";
        }
        public Language tolang(string strval)
        {
            if (strval == "English") return Language.English;
            else if (strval == "繁體中文") return Language.trad_chi;
            else return Language.simp_chi;
        }
        private async void TextCell_Tapped(object sender, EventArgs e)
        {
            string unit;
            unit = await DisplayActionSheet(new string[] { "Unit of weight", "重量單位", "重量单位" }[(int)lang],
                new string[] { "Cancel", "取消", "取消" }[(int)lang], null,
                new string[] { "Kilogram", "公斤", "公斤" }[(int)lang],
                new string[] { "Pounds", "磅", "磅" }[(int)lang]);
            
            if (unit != null)
                Weightset.Detail = unit;
            savedata();
        }
        private async void Heightset_Tapped(object sender, EventArgs e)
        {
            string unit;
            unit = await DisplayActionSheet(new string[] { "Unit of height", "身高單位", "身高单位" }[(int)lang],
                new string[] { "Cancel", "取消", "取消" }[(int)lang], null,
                new string[] { "Meter", "米", "米" }[(int)lang],
                new string[] { "Feet", "尺", "尺" }[(int)lang]);           
            if (unit != null)
                Heightset.Detail = unit;
            savedata();
        }
        private async void Bpset_Tapped(object sender, EventArgs e)
        {
            string unit;
            unit = await DisplayActionSheet(new string[] { "Unit of Blood pressure", "血壓單位", "血压单位" }[(int)lang],
                new string[] { "Cancel", "取消", "取消" }[(int)lang], null,
                new string[] { "mmHg", "毫米汞柱", "毫米汞柱" }[(int)lang],
                new string[] { "kPa", "千帕卡", "千帕卡" }[(int)lang]);
            
            if (unit != null) Bpset.Detail = unit;
            savedata();
        }
        private async void Tpset_Tapped(object sender, EventArgs e)
        {
            string unit;
            unit = await DisplayActionSheet(new string[] { "Unit of Temperature", "溫度單位", "温度单位" }[(int)lang],
                new string[] { "Cancel", "取消", "取消" }[(int)lang], null,
                new string[] { "Celsius", "攝氏", "摄氏" }[(int)lang],
                new string[] { "Celsius", "華氏", "华氏" }[(int)lang]);           
            if (unit != null)
                Tpset.Detail = unit;
            savedata();
        }
        private async void Lang_Tapped(object sender, EventArgs e)
        {
            string unit;
            unit = await DisplayActionSheet(new string[] { "Language", "語言","语言" }[(int)lang], new string[] { "Cancel", "取消", "取消" }[(int)lang], null, "English", "繁體中文", "简体中文");            
            if (unit != null)
            {
                Lang.Detail = unit;
                await DisplayAlert(new string[] { "Note", "注意", "注意" }[(int)lang],
                    new string[] { "Please restart app to take effect.", "請重新開啟應用程式,使更改生效", "请重启程序,使更改生效" }[(int)lang],
                    new string[] { "OK", "確定", "确定" }[(int)lang]);
                savedata(); setcontent();            
            }
        }

        private void Btnext_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
            OnDisappearing();
            //Navigation.PopModalAsync();
            Navigation.PushModalAsync(new Personal_Information());
        }
    }
}
