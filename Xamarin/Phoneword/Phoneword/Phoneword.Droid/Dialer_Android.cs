using Android.Content;
using Android.Telephony;
using System.Linq;
using Xamarin.Forms;
using Android.Net;

using Phoneword.Core;
using Phoneword.Droid;

[assembly: Dependency(typeof(Dialer_Android))]
namespace Phoneword.Droid
{
    public class Dialer_Android : IDialer
    {
        public bool Dial(string number)
        {
            var context = Forms.Context;
            if (context == null)
            {
                return false;
            }

            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + number));

            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);

                return true;
            }

            return false;
        }

        public bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));

            if (list.Any())
            {
                return true;
            }

            var manager = TelephonyManager.FromContext(context);

            return manager.PhoneType != PhoneType.None;
        }
    }
}