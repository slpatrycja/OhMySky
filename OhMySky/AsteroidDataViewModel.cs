using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Disposables;



namespace OhMySky
{

   public class AsteroidDataViewModel
    {
        public AsteroidDataViewModel()
        {
            async void AsteroidDataPage()
            {
                RestService restService = new RestService();
                AsteroidData asteroidData = await restService.GetAsteroidData(GenerateRequestUri(Constants.NasaApiEndpoint));

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
