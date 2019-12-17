using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OhMySky.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OhMySky.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AsteroidsDataPage : ContentPage
	{
		public AsteroidsDataPage()
		{
			//InitializeComponent ();
            //BindingContext = new AsteroidsDataViewModel();

            async void AsteroidsDataPage()
            {
                RestService restService = new RestService();
                AsteroidData asteroidData = await restService.GetAsteroidData(GenerateRequestUri(Constants.NasaApiEndpoint));

                BindingContext = asteroidData;
            }

            string GenerateRequestUri(string endpoint)
            {
                string requestUri = endpoint;
                requestUri += $"?start_date={GetCurrentDate()}&end_date={GetCurrentDate()}";
                requestUri += $"&api_key={Constants.APIKey}";
                return requestUri;
            }

             string GetCurrentDate()
            {
                return DateTime.UtcNow.Date.ToString("yyyy-MM-dd");
            }

        }
    }
}