
using Xamarin.Forms;

namespace Views
{
    public class App : Application
    {
        public App()
        {
            //// The root page of your application
            //var content = new ContentPage
            //{
            //    Title = "Views",
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};

            //this.MainPage = new NavigationPage(content);
            this.MainPage = new ListViewPage();
        }

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
