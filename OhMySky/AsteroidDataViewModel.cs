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
using System.Collections.ObjectModel;

namespace OhMySky
{

    public class AsteroidDataViewModel : ViewModel
    {
        public Command TextCommand { get; }
        public AsteroidData AsteroidData { get; set; }
        public AsteroidDataViewModel()
        {
            Task.Run(async () => { await GetAsteroidData(); });
            Asteroids = asteroids;
        }

        public async Task GetAsteroidData()
        {
            RestService restService = new RestService();
            AsteroidData = await restService.GetAsteroidData(GenerateRequestUri(Constants.NasaApiEndpoint));
            foreach(var asteroid in AsteroidData.NearEarthObjects.NearEarthObject)
            {
                var record = new iAsteroid
                {
                    Id = asteroid.Id,
                    Name = asteroid.Name,
                    IsPotentiallyHazardous = asteroid.IsPotentiallyHazardous,
                    EstimatedDiameter = asteroid.EstimatedDiameter.KilometersData.EstimatedDiameterMax,
                    CloseApproachDate = asteroid.CloseApproachData[0].CloseApproachDate,
                    RelativeVelocity = asteroid.CloseApproachData[0].RelativeVelocity.KilometersPerSecond,
                    AbsoluteMagnitudeH = asteroid.AbsoluteMagnitudeH
                };

                Asteroids.Add(record);
            }
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

        public IList<iAsteroid> Asteroids { get; private set; }
        ObservableCollection<iAsteroid> asteroids = new ObservableCollection<iAsteroid>();
    }
}
