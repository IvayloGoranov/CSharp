using System;
using Xamarin.Forms;

namespace DeviceAPIs
{
    public partial class PhotoTakerPage : ContentPage
    {
        public PhotoTakerPage()
        {
            InitializeComponent();
        }

        public void TakePhoto_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IPhotoTaker>().TakePhoto();

            MessagingCenter.Subscribe<IPhotoTaker, string>(this, "photoTaken", PathPhotoTaken);
        }

        private void PathPhotoTaken(IPhotoTaker sender, string arg)
        {
            throw new NotImplementedException();
        }
    }
}
