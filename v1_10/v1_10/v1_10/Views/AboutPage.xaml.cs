using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace v1_10.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new Uri(url));
        });
    }
}