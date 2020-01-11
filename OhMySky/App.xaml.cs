using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace OhMySky
{
    public partial class App : Application
    {
        static AsteroidDatabase database;

        public App()
        {
             MainPage = new NavigationPage(new MainPage());

            InitializeComponent();
        }

        public static AsteroidDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AsteroidDatabase();
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
