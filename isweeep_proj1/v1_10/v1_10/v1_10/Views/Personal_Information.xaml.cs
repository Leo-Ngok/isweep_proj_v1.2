using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v1_10.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace v1_10.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Personal_Information : ContentPage
	{
        double height, weight, sybp, dibp, chol, hdl;
        bool gen, smo, dia;
        Language lang;
        height hieg;
        weight wieg;
        bp pres;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            try
            {
                var setting = new SQLiteConnection(App.settingpath)
               .Table<settingsdata>()
               .ToList()
               .First();
                lang = setting.language;
                hieg = setting.height;
                 wieg = setting.weight;
                pres = setting.bp;
            }
            finally { }
            
            try
            {
                if (lang == Language.English)
                {
                    
                    lbl0.Text = "User Information";
                    lbl1.Text = "Date of Birth";
                    lbl2.Text = "Height";
                    lbl3.Text = "Weight";
                    lbl4.Text = "Systolic Blood pressure";
                    lbl5.Text = "Diastolic Blood pressure";
                    lbl6.Text = "Cholesterol level";
                    lbl7.Text = "HDL level";
                    lbl8.Text = "Gender";
                    lbl9.Text = "Are you a smoker?";
                    lbl10.Text = "Do you have diabetes?";
                    //lbl11.Text = "Are you always taking medicine?";
                    height_text.Placeholder = "(in ";
                    if (hieg == Models.height.Meter)
                        height_text.Placeholder += "cm)";
                    else
                        height_text.Placeholder += "feet)";
                    weight_text.Placeholder = "(in ";
                    if (wieg == Models.weight.Kilogram)
                        weight_text.Placeholder += "kg)";
                    else
                        weight_text.Placeholder += "lb)";
                    sybp_text.Placeholder = "(in ";
                    dibp_text.Placeholder = "(in ";
                    if (pres == bp.kPa)
                    {
                        sybp_text.Placeholder += "kPa)";
                        dibp_text.Placeholder += "kPa)";
                    }
                    else
                    {
                        sybp_text.Placeholder += "mmHg)";
                        dibp_text.Placeholder += "mmHg)";
                    }
                    chol_text.Placeholder = "(in mg/dL)";
                    hdl_text.Placeholder = "(in mg/dL)";
                    gend.ItemsSource=new string[] {"---Choose an item---" ,"Male", "Female" };
                    smok.ItemsSource = new string[] { "---Choose an item---", "Yes", "No" };
                    diab.ItemsSource= new string[] { "---Choose an item---", "Yes", "No" };
                    //tba.ItemsSource= new string[] { "---Choose an item---", "Yes", "No" };
                    Title = "User Profile";
                    btn.Text = "Submit";
                }
                else if (lang == Language.trad_chi)
                {
                    lbl0.Text = "用戶資料";
                    lbl1.Text = "出生日期";
                    lbl2.Text = "身高";
                    lbl3.Text = "體重";
                    lbl4.Text = "血壓(上壓)";
                    lbl5.Text = "血壓(下壓)";
                    lbl6.Text = "膽固醇水平";
                    lbl7.Text = "HDL水平";
                    lbl8.Text = "性別";
                    lbl9.Text = "閣下有沒有吸煙的習慣?";
                    lbl10.Text = "閣下有沒有糖尿病?";
                    //lbl11.Text = "閣下是否長期病患?";
                    height_text.Placeholder = "(";
                    if (hieg == Models.height.Meter)
                        height_text.Placeholder += "公分)";
                    else
                        height_text.Placeholder += "尺)";
                    weight_text.Placeholder = "(";
                    if (wieg == Models.weight.Kilogram)
                        weight_text.Placeholder += "kg)";
                    else
                        weight_text.Placeholder += "lb)";
                    sybp_text.Placeholder = "(";
                    dibp_text.Placeholder = "(";
                    if (pres == bp.kPa)
                    {
                        sybp_text.Placeholder += "kPa)";
                        dibp_text.Placeholder += "kPa)";
                    }
                    else
                    {
                        sybp_text.Placeholder += "mmHg)";
                        dibp_text.Placeholder += "mmHg)";
                    }
                    chol_text.Placeholder = "(mg/dL)";
                    hdl_text.Placeholder = "(mg/dL)";
                    gend.ItemsSource = new string[] { "---請選擇---", "男", "女" };
                    smok.ItemsSource = new string[] { "---請選擇---", "有", "沒有" };
                    diab.ItemsSource = new string[] { "---請選擇---", "有", "沒有" };
                    //tba.ItemsSource = new string[] { "---請選擇---", "是", "否" };
                    Title = "個人檔案";
                    btn.Text = "提交";
                }
            
                else
                {
                    lbl0.Text = "用户资料";
                    lbl1.Text = "出生日期";
                    lbl2.Text = "身高";
                    lbl3.Text = "体重";
                    lbl4.Text = "血压(上压)";
                    lbl5.Text = "血压(下压)";
                    lbl6.Text = "胆固醇水平";
                    lbl7.Text = "HDL水平";
                    lbl8.Text = "性別";
                    lbl9.Text = "阁下有沒有吸烟的习惯?";
                    lbl10.Text = "阁下有沒有糖尿病?";
                    //lbl11.Text = "阁下是否长期病患?";
                    height_text.Placeholder = "(";
                    if (hieg == Models.height.Meter)
                        height_text.Placeholder += "公分)";
                    else
                        height_text.Placeholder += "尺)";
                    weight_text.Placeholder = "(";
                    if (wieg == Models.weight.Kilogram)
                        weight_text.Placeholder += "kg)";
                    else
                        weight_text.Placeholder += "lb)";
                    sybp_text.Placeholder = "(";
                    dibp_text.Placeholder = "(";
                    if (pres == bp.kPa)
                    {
                        sybp_text.Placeholder += "kPa)";
                        dibp_text.Placeholder += "kPa)";
                    }
                    else
                    {
                        sybp_text.Placeholder += "mmHg)";
                        dibp_text.Placeholder += "mmHg)";
                    }
                    chol_text.Placeholder = "(mg/dL)";
                    hdl_text.Placeholder = "(mg/dL)";
                    gend.ItemsSource = new string[] { "---请选择---", "男", "女" };
                    smok.ItemsSource = new string[] { "---请选择---", "有", "沒有" };
                    diab.ItemsSource = new string[] { "---请选择---", "有", "沒有" };
                    //tba.ItemsSource = new string[] { "---请选择---", "是", "否" };
                    Title = "个人档案";
                    btn.Text = "提交";
                }
            }
            catch (Exception) { }
            using (SQLiteConnection dbim = new SQLiteConnection(App.DBPATH))
            {
                dbim.CreateTable<DB_pdata>();
                List<DB_pdata> dBs;
                try
                {
                    dBs = dbim.Table<DB_pdata>().ToList();
                    height_text.Text = dBs.First().heig.ToString();
                    weight_text.Text = dBs.First().weig.ToString();
                    sybp_text.Text = dBs.First().Sbp.ToString();
                    dibp_text.Text = dBs.First().Dbp.ToString();
                    chol_text.Text = dBs.First().Cho.ToString();
                    hdl_text.Text = dBs.First().hdll.ToString();
                    DOB.Date = dBs.First().dob;
                    gend.SelectedIndex = bootoint(dBs.First().genD);
                    smok.SelectedIndex = bootoint(dBs.First().smoK);
                    diab.SelectedIndex = bootoint(dBs.First().diaB);
                    //tba.SelectedIndex = bootoint(dBs.First().medic);
                }
                catch (Exception)
                {
                    gend.SelectedIndex = 0;
                    smok.SelectedIndex = 0;
                    diab.SelectedIndex = 0;
                    //tba.SelectedIndex = 0;
                    DOB.Date = DateTime.Today;
                }
            }
            DOB.MaximumDate = DateTime.Today;
        }
        public Personal_Information ()
		{
            InitializeComponent();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.settingpath))
                {
                    conn.CreateTable<settingsdata>();
                    Language lang = conn.Table<settingsdata>().ToList().First().language;

                }
            }
            finally { }
                        
            height_text.Keyboard = Keyboard.Numeric;
            weight_text.Keyboard = Keyboard.Numeric;
            sybp_text.Keyboard = Keyboard.Numeric;
            dibp_text.Keyboard = Keyboard.Numeric;
            chol_text.Keyboard = Keyboard.Numeric;
            hdl_text.Keyboard = Keyboard.Numeric;
           
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            int k = (int)lang;
            try
            {
                height=double.Parse(height_text.Text);
                weight= double.Parse(weight_text.Text);
                sybp= double.Parse(sybp_text.Text);
                dibp = double.Parse(dibp_text.Text);
                chol = double.Parse(chol_text.Text);
                hdl = double.Parse(hdl_text.Text);
                gen = Extendparse(gend.SelectedItem.ToString());
                smo = Extendparse(smok.SelectedItem.ToString());
                dia = Extendparse(diab.SelectedItem.ToString());
                //med = Extendparse(tba.SelectedItem.ToString());
                assertgt0(height);
                assertgt0(weight);
                assertgt0(sybp);
                assertgt0(dibp);
                assertgt0(chol);
                assertgt0(hdl);

            }
            catch (Exception)
            {
                DisplayAlert(new string[] { "Error", "錯誤", "错误" }[k], 
                    new string[] { "The value(s) you input is/are not valid", "輸入的數值無效", "输入的数值无效" }[k]
                    , new string[] { "Retry", "重試", "重试" }[k]);
                return;
            }
            DB_pdata pdata = new DB_pdata() {
                dob = DOB.Date, heig = height,
                hdll = hdl, Cho = chol,
                Dbp = dibp, diaB = dia,
                weig = weight, genD = gen,
                Sbp=sybp,  smoK=smo};
            using (SQLiteConnection conn = new SQLiteConnection(App.DBPATH))
            {     
                
                conn.CreateTable<DB_pdata>();
                conn.DeleteAll<DB_pdata>();
                int nbf =conn.Insert(pdata);
                if (nbf > 0) DisplayAlert(new string[] { "Successful", "成功", "成功" }[k],
                    new string[] { "saved", "已儲存", "已储存" }[k], new string[] { "close", "關閉", "关闭" }[k]);
                else DisplayAlert("Failure", "record failed to be saved", "retry");
            }             
        }
        public void assertgt0(double value)
        {
            if (value <= 0) throw new Exception();
        }
        public bool Extendparse(string representation)
        {
            if (representation == "Yes" || representation == "Male"
                || representation == "是"
                || representation == "有"
                || representation == "男") return true;
            if (representation == "No" || representation == "Female"
                || representation == "否"
                || representation == "沒有"
                || representation == "女") return false;
            throw new Exception();
        }
        public int bootoint(bool state)
        {
            if (state)
                return 1;
            else
                return 2;
        }
    }     
}