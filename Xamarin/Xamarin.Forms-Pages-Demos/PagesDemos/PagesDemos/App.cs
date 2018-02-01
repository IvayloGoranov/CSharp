using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PagesDemos
{
    public class App : Application
    {
        public App()
        {
            this.MainPage = new TabbedPageDemo(this.InitColors());
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

        private NamedColor[] InitColors()
        {
            return new NamedColor[]
                {
                    new NamedColor("Aqua", Color.Aqua),
                    new NamedColor("Black", Color.Black),
                    new NamedColor("Blue", Color.Blue)
                };
        }
    }
}
