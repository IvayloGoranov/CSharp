using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Geolocation;

using Android.App;
using Android.OS;
using Android.Util;

using DeviceAPIs;

[assembly: Dependency(typeof(DeviceAPIs.Droid.GeoLocator_Android))]
namespace DeviceAPIs.Droid
{
    [Activity(Label = "GeoLocator")]
    public class GeoLocator_Android : Activity, IGeoLocator
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        public async void GetPosition()
        {
            try
            {
                var locator = new Geolocator(Forms.Context)
                {
                    DesiredAccuracy = 50
                };

                if (!locator.IsListening)
                {
                    locator.StartListening(minTime: 1000, minDistance: 0);
                }

                var position = await locator.GetPositionAsync(timeout: 20000);
                var appPosition = new AppPosition()
                {
                    Latitude = position.Latitude,
                    Longtitude = position.Longitude
                };

                MessagingCenter.Send<IGeoLocator, AppPosition>(this, "gotLocation", appPosition);
            }
            catch (Exception e)
            {
                Log.Debug("GeoLocator Error", e.ToString());
            }
        }
    }
}