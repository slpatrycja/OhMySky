using System;
using System.Collections.Generic;
using OhMySky.Infrastructure;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using OhMySky.Models;

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
            AsteroidData = await restService.GetAsteroidData(GenerateRequestUri(Constants.NasaApiEndpoint), GetCurrentDate());
            foreach (var asteroid in AsteroidData.NearEarthObjects)
            {
                var record = new Asteroid
                {
                    Id = Convert.ToInt32(asteroid.Id),
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

        public IList<Asteroid> Asteroids { get; private set; }
        ObservableCollection<Asteroid> asteroids = new ObservableCollection<Asteroid>();
    }
}
