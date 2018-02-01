using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Phoneword.Core;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Phoneword
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            IPhonewordTranslator translator = new PhonewordTranslator();
            PhoneNumbers = new List<string>();
            var mainPage = new MainPage(translator);
            this.MainPage = new NavigationPage(mainPage);
        }

        public static IList<string> PhoneNumbers { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
