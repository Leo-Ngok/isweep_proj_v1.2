using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using v1_10.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace v1_10.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Interval_Timer : ContentPage
    {
        private tTimer1 _ttimer;
        Timer timer = new Timer(1000);
        int winittime = 0;
        int rinittime = 0;
        int wtotaltime = 0;
        int rtotaltime = 0;
        bool isworking = true;
        //bool isactivated = true;
        //int hrleft;
        //int minleft;
        //int secleft;
        public Interval_Timer()
        {
            InitializeComponent();
            Rhr.Text = "0";
            Rmin.Text = "0";
            Rsec.Text = "0";
            Whr.Text = "0";
            Wmin.Text = "0";
            Wsec.Text = "0";
            Rhr.Keyboard = Keyboard.Numeric;
            Rmin.Keyboard = Keyboard.Numeric;
            Rsec.Keyboard = Keyboard.Numeric;
            Whr.Keyboard = Keyboard.Numeric;
            Wmin.Keyboard = Keyboard.Numeric;
            Wsec.Keyboard = Keyboard.Numeric;
            // timer.Elapsed += Timer_Elapsed;
            _ttimer = new tTimer1(new TimeSpan(0, 0, 1), () =>
              {
                  if (isworking)
                  {
                      state.Text = g[(int)lang];
                      timeleft.Text = totimeformat(wtotaltime--);
                      if (wtotaltime < 0)
                      {
                          isworking = false;
                          rtotaltime = rinittime;
                          //CrossLocalNotifications.Current.Cancel(101);
                          CrossLocalNotifications.Current.Show(apptitle[(int)lang], restnotcaption[(int)lang],120);
                          try
                          {
                              CrossLocalNotifications.Current.Cancel(130);
                          }
                          finally { }
                          //DisplayAlert("times up", "time is up", "dismiss");
                          //_ttimer.Stop();
                      }
                  }
                  else
                  {
                      state.Text = f[(int)lang];
                      timeleft.Text = totimeformat(rtotaltime--);
                      if (rtotaltime < 0)
                      {
                          isworking = true;                          
                          wtotaltime = winittime;
                          CrossLocalNotifications.Current.Show(apptitle[(int)lang], worknotcaption[(int)lang],130);
                          try
                          {
                              CrossLocalNotifications.Current.Cancel(120);
                          }
                          finally { }
                      }
                  }
              });
        }
        string[] a = new string[3] { "Start", "開始", "开始" };
        string[] b = new string[3] { "Pause", "暫停", "暂停" };
        string[] c = new string[3] { "Continue", "繼續", "继续" };
        string[] d = new string[3] { "Interval Timer", "區間計時器", "区间计时器" };
        string[] g= new string[3] { "working", "工作中", "工作中" };
        string[] f = new string[3] { "resting", "休息中", "休息中" };
        string[] apptitle = new string[3] { "CVD Calculator", "CVD 計算器", "CVD 计算器" };
        string[] restnotcaption= new string[3] { "times up, rest now!",
                                                "時間到了，請開始休息", "时间到了,请开始休息" };
        string[] worknotcaption = new string[3] { "times up, work now!",
                                                "時間到了，請開始工作", "时间到了,请开始工作" };
        Language lang;
        protected override void OnAppearing()
        {
            lang = new SQLiteConnection(App.settingpath).Table<settingsdata>()
                .ToList()
                .First().language;
            
            if (lang == Language.English)
            {
                if (d.Contains(state.Text)) state.Text = d[0];
                else if (g.Contains(state.Text)) state.Text = g[0];
                else if (f.Contains(state.Text)) state.Text = f[0];
                labl1.Text = "Work Interval";
                labl2.Text = "Rest Interval";               
                if (a.Contains(startbtn.Text)) startbtn.Text = "Start";
                else if (b.Contains(startbtn.Text)) startbtn.Text = "Pause";              
                else if (c.Contains(startbtn.Text)) startbtn.Text = "Continue";             
                Stopbtn.Text = "Stop";
                Title = d[(int)lang];
            }
            else if (lang == Language.trad_chi)
            {
                if (d.Contains(state.Text)) state.Text = d[1];
                else if (g.Contains(state.Text)) state.Text = g[1];
                else if (f.Contains(state.Text)) state.Text = f[1];
                labl1.Text = "工作區間";
                labl2.Text = "休息區間";
                if (a.Contains(startbtn.Text)) startbtn.Text = "開始";
                else if (b.Contains(startbtn.Text)) startbtn.Text = "暫停";
                else if (c.Contains(startbtn.Text)) startbtn.Text = "繼續";
                Stopbtn.Text = "停止";
                Title = d[(int)lang];
            }
            else if(lang == Language.simp_chi)
            {
                if (d.Contains(state.Text)) state.Text = d[2];
                else if (g.Contains(state.Text)) state.Text = g[1];
                else if (f.Contains(state.Text)) state.Text = f[1];
                labl1.Text = "工作区间";
                labl2.Text = "休息区间";
                if (a.Contains(startbtn.Text)) startbtn.Text = "开始";
                else if (b.Contains(startbtn.Text)) startbtn.Text = "暂停";
                else if (c.Contains(startbtn.Text)) startbtn.Text = "继续";
                Stopbtn.Text = "停止";
                Title = d[(int)lang];
            }
            base.OnAppearing();
        }
        private void Rin_Clicked(object sender, EventArgs e)
        {
            ToZero();
            if (int.Parse(Rsec.Text) >= 59)
            {
                if (int.Parse(Rmin.Text) >= 59)
                {
                    Rhr.Text = (int.Parse(Rhr.Text) + 1).ToString();
                    Rmin.Text = "0";
                    Rsec.Text = "0";
                }
                else
                {
                    Rmin.Text = (int.Parse(Rmin.Text) + 1).ToString();
                    Rsec.Text = "0";
                }
            }
            else
            {
                Rsec.Text = (int.Parse(Rsec.Text) + 1).ToString();
            }
        }
        private void Rde_Clicked(object sender, EventArgs e)
        {
            ToZero();
            if (int.Parse(Rsec.Text) <= 0)
            {
                if (int.Parse(Rmin.Text) <= 0)
                {
                    if (int.Parse(Rhr.Text) > 0)
                    {
                        Rhr.Text = (int.Parse(Rhr.Text) - 1).ToString();
                        Rmin.Text = "59";
                        Rsec.Text = "59";
                    }

                }
                else
                {
                    Rmin.Text = (int.Parse(Rmin.Text) - 1).ToString();
                    Rsec.Text = "59";
                }
            }
            else
            {
                Rsec.Text = (int.Parse(Rsec.Text) - 1).ToString();
            }
        }
        private void Win_Clicked(object sender, EventArgs e)
        {
            ToZero();
            if (int.Parse(Wsec.Text) >= 59)
            {
                if (int.Parse(Wmin.Text) >= 59)
                {
                    Whr.Text = (int.Parse(Whr.Text) + 1).ToString();
                    Wmin.Text = "0";
                    Wsec.Text = "0";
                }
                else
                {
                    Wmin.Text = (int.Parse(Wmin.Text) + 1).ToString();
                    Wsec.Text = "0";
                }
            }
            else
            {
                Wsec.Text = (int.Parse(Wsec.Text) + 1).ToString();
            }
        }
        private void Wde_Clicked(object sender, EventArgs e)
        {
            ToZero();
            if (int.Parse(Wsec.Text) <= 0)
            {
                if (int.Parse(Wmin.Text) <= 0)
                {
                    if (int.Parse(Whr.Text) > 0)
                    {
                        Whr.Text = (int.Parse(Whr.Text) - 1).ToString();
                        Wmin.Text = "59";
                        Wsec.Text = "59";
                    }

                }
                else
                {
                    Wmin.Text = (int.Parse(Wmin.Text) - 1).ToString();
                    Wsec.Text = "59";
                }
            }
            else
            {
                Wsec.Text = (int.Parse(Wsec.Text) - 1).ToString();
            }
        }
        private void ToZero()
        {
            if (Rhr.Text==("")) Rhr.Text = "0";
            if (Rmin.Text.Equals("")) Rmin.Text = "0";
            if (Rsec.Text.Equals("")) Rsec.Text = "0";
            if (Whr.Text.Equals("")) Whr.Text = "0";
            if (Wmin.Text.Equals("")) Wmin.Text = "0";
            if (Wsec.Text.Equals("")) Wsec.Text = "0";
        }
        private string addzero(int N)
        {
            if (N < 10) return "0" + N.ToString();
            return N.ToString();
        }
       
        private void Startbtn_Clicked(object sender, EventArgs e)
        {
            if (a.Contains(startbtn.Text))
            {
                winittime = int.Parse(Whr.Text) * 3600 + int.Parse(Wmin.Text) * 60 + int.Parse(Wsec.Text);
                rinittime = int.Parse(Rhr.Text) * 3600 + int.Parse(Rmin.Text) * 60 + int.Parse(Rsec.Text);
                if (winittime <= 0 || rinittime <= 0)
                {
                    if (lang==Language.English)
                        DisplayAlert("Error","Please set a valid time","Retry");
                    else if(lang==Language.trad_chi)
                        DisplayAlert("錯誤", "時間無效", "重試");
                    else if(lang==Language.simp_chi)
                        DisplayAlert("错误", "时间无效", "重试");
                    return;
                }
                rtotaltime = rinittime;
                wtotaltime = winittime;
                _ttimer.Start();
                
                startbtn.Text = b[(int)lang];
                state.Text = g[(int)lang];
                Stopbtn.IsEnabled = false;
            }
            else if (c.Contains(startbtn.Text))
            {
                _ttimer.Start();
                startbtn.Text = b[(int)lang];
                Stopbtn.IsEnabled = false;
            }
            else if (b.Contains(startbtn.Text))
            {
                _ttimer.Stop();
                startbtn.Text = c[(int)lang];
                Stopbtn.IsEnabled = true;
            }
           
            Rhr.IsEnabled = false;
            Rmin.IsEnabled = false;
            Rsec.IsEnabled = false;
            Whr.IsEnabled = false;
            Wmin.IsEnabled = false;
            Wsec.IsEnabled = false;
            Wde.IsEnabled = false;
            Win.IsEnabled = false;
            Rde.IsEnabled = false;
            rin.IsEnabled = false;
        }
        private void Stopbtn_Clicked(object sender, EventArgs e)
        {
            _ttimer.Stop();
            //isactivated = false;
            Stopbtn.IsEnabled = false;
            startbtn.Text = a[(int)lang];
            winittime = 0;
            rinittime = 0;
            wtotaltime = 0;
            winittime = 0;
            isworking = true;
             Rhr.IsEnabled = !false;
             Rmin.IsEnabled = !false;
             Rsec.IsEnabled = !false;
             Whr.IsEnabled = !false;
             Wmin.IsEnabled = !false;
             Wsec.IsEnabled = !false;
             Wde.IsEnabled = !false;
             Win.IsEnabled = !false;
             Rde.IsEnabled = !false;
             rin.IsEnabled = !false;
            timeleft.Text = "00:00:00";
            state.Text = d[(int)lang];
        }
        string totimeformat(int time)
        {
            int hr = (int)Math.Floor(time / 3600.0);
            int mn = (int)Math.Floor((time%3600)/60.0);
            int se = (time % 3600) % 60;
            return addzero(hr) + ":" + addzero(mn) + ":" + addzero(se);
        }
    }
}