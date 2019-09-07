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
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DBPATH))
            {
                conn.CreateTable<DB_pdata>();
                List<DB_pdata> pd = conn.Table<DB_pdata>().ToList();
                DateTime h = pd.First().dob;
                debuglabel.Text = "Hello World";
            }

        }

    }
}