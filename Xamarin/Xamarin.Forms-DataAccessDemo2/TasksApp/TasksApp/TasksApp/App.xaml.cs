using Xamarin.Forms;

namespace TasksApp
{
    public partial class App : Application
    {
        private static TasksDatabase database;

        public App()
        {
            this.InitializeComponent();

            var mainPageViewModel = new MainPageViewModel(Database);
            this.MainPage = new MainPage(mainPageViewModel);
        }

        public static TasksDatabase Database
        { 
            get
            {
                if (database == null)
                {
                    database = new TasksDatabase();
                }

                return database;
            }
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
