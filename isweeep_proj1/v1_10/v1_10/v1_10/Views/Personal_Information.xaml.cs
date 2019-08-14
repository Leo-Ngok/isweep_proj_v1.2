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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }
        public Personal_Information ()
		{
            InitializeComponent();
            using (SQLiteConnection dbim = new SQLiteConnection(App.DBPATH))
            {
                dbim.CreateTable<DB_pdata>();
                List<DB_pdata> dBs;
                try {
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
                    tba.SelectedIndex = 0;
                }
                catch (Exception){
                    gend.SelectedIndex = 0;
                    smok.SelectedIndex = 0;
                    diab.SelectedIndex = 0;
                    tba.SelectedIndex = 0;
                    DOB.Date = new DateTime(1949, 10, 1);
                }
            }			      
            DOB.MaximumDate = DateTime.Today;            
            height_text.Keyboard = Keyboard.Numeric;
            weight_text.Keyboard = Keyboard.Numeric;
            sybp_text.Keyboard = Keyboard.Numeric;
            dibp_text.Keyboard = Keyboard.Numeric;
            chol_text.Keyboard = Keyboard.Numeric;
            hdl_text.Keyboard = Keyboard.Numeric;
           
            DisplayAlert("Warning", "You are not advised to"
                +" change any of the information unless you have to."
                +" Changing the information means a greater chance "+
                "to get things wrong", "OK");
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
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
                assertgt0(height);
                assertgt0(weight);
                assertgt0(sybp);
                assertgt0(dibp);
                assertgt0(chol);
                assertgt0(hdl);

            }
            catch (Exception)
            {
                DisplayAlert("Error", "The value(s) you input is/are not valid", "Retry");
                return;
            }
            DB_pdata pdata = new DB_pdata() {
                dob = DOB.Date, heig = height,
                hdll = hdl, Cho = chol,
                Dbp = dibp, diaB = dia,
                weig = weight, genD = gen,
                Sbp=sybp,  smoK=smo };
            using (SQLiteConnection conn = new SQLiteConnection(App.DBPATH))
            {     
                
                conn.CreateTable<DB_pdata>();
                conn.DeleteAll<DB_pdata>();
                int nbf =conn.Insert(pdata);
                if (nbf > 0) DisplayAlert("Successful", "saved", "close");
                else DisplayAlert("Failure", "record failed to be saved", "retry");
            }             
        }
        public void assertgt0(double value)
        {
            if (value <= 0) throw new Exception();
        }
        public bool Extendparse(string representation)
        {
            if (representation == "Yes" || representation == "Male") return true;
            if (representation == "No" || representation == "Female") return false;
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