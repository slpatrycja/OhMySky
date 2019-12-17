using System;
using System.Collections.Generic;
using System.Text;
using OhMySky.Views;


namespace OhMySky.ViewModels
{
    class AsteroidDataViewModel
    {
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
