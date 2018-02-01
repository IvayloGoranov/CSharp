using System;
using Xamarin.Forms;

namespace DeviceAPIs
{
    public partial class GeoLocationPage : ContentPage
    {
        public GeoLocationPage()
        {
            InitializeComponent();
        }

        public void GeoLocation_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IGeoLocator>().GetPosition();

            MessagingCenter.Subscribe<IGeoLocator, AppPosition>(this, "gotLocation", DisplayPosition);
        }

        private void DisplayPosition(IGeoLocator sender, AppPosition arg)
        {
            this.labelLatitude.Text = arg.Latitude.ToString();
            this.labelLatitude.Text = arg.Longtitude.ToString();
        }
    }
}
