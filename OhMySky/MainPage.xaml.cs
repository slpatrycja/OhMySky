using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Reflection;

namespace OhMySky
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetAsteroidsData();
        }

        public async void GetAsteroidsData()
        {
            RestService restService = new RestService();
            AsteroidData asteroidData = await restService.GetAsteroidData(GenerateRequestUri(Constants.NasaApiEndpoint));
            BindingContext = asteroidData;
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?start_date={getStartDate()}&end_date={getEndDate()}";
            requestUri += $"&api_key={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        private string getStartDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            return dateTime.ToString("yyyy-MM-dd");
        }

        private string getEndDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTime dt = dateTime.AddDays(7);
            return dt.ToString("yyyy-MM-dd");
        }
    }
}
