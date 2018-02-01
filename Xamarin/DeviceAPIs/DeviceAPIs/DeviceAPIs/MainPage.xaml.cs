using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeviceAPIs
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void GeoLocationPage_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new GeoLocationPage());
        }

        public async void ContactsPage_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new ContactsPage());
        }
    }
}
