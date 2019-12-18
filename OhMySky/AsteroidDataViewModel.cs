using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Disposables;
using System.Windows.Input;
using OhMySky.Infrastructure;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OhMySky
{

   public class AsteroidDataViewModel : ViewModel
    {
        public Command TextCommand { get; }
        public AsteroidData AsteroidData { get; set; }
        public AsteroidDataViewModel()
        {
            TextCommand = new Command(async () => await GetAsteroidData());
            TextCommand.Execute(null);            
        }

        public async Task<AsteroidData> GetAsteroidData()
        {
            RestService restService = new RestService();
            AsteroidData = await restService.GetAsteroidData(GenerateRequestUri(Constants.NasaApiEndpoint));
            return AsteroidData;
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
