using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Geolocation;

using Android.App;
using Android.OS;
using Android.Util;

using DeviceAPIs;
using Xamarin.Media;
using Android.Content;

namespace DeviceAPIs.Droid
{
    [Activity(Label = "PhotoTaker")]
    public class PhotoTaker_Android : Activity, IPhotoTaker
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled)
            {
                return;
            }

            var mediaFile = await data.GetMediaFileExtraAsync(Forms.Context);

            MessagingCenter.Send<IPhotoTaker, string>(this, "photoTaken", mediaFile.Path);
        }

        public void TakePhoto()
        {
            try
            {
                var mediaPicker = new MediaPicker(Forms.Context);
                var mediaOptions = new StoreCameraMediaOptions()
                {
                    DefaultCamera = CameraDevice.Rear,
                    Directory = "DemoFolder",
                    Name = "myPic.jpg"
                };
                var intent = mediaPicker.GetTakePhotoUI(mediaOptions);

                this.StartActivityForResult(intent, 1);
            }
            catch (Exception e)
            {
                Log.Debug("PhotoTaker Error", e.ToString());
            }
        }
    }
}