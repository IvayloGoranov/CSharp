using UIKit;
using Foundation;
using Xamarin.Forms;

using Phoneword.Core;
using Phoneword.iOS;

[assembly: Dependency(typeof(Dialer_iOS))]
namespace Phoneword.iOS
{
    public class Dialer_iOS : IDialer
    {
        public bool Dial(string number)
        {
            var url = new NSUrl("tel:" + number);
            bool openUrlResult = UIApplication.SharedApplication.OpenUrl(url);

            return openUrlResult;
        }
    }
}