using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DynamicData;
using OhMySky.Models;
using Xamarin.Forms;

namespace OhMySky.ViewModels
{
    public class FavouriteAsteroidsViewModel : ContentPage
    {

        public FavouriteAsteroidsViewModel()
        {
            Task.Run(async () => { await GetAsteroidData(); });
            FavouriteAsteroids = favouriteAsteroids;
        }

        public async Task GetAsteroidData()
        {
            var data = await App.Database.GetItemsAsync();
            foreach (var asteroid in data)
            {
                if (!FavouriteAsteroids.Any(favAsteroid => favAsteroid.Id == asteroid.Id)) FavouriteAsteroids.Add(asteroid);
            }
        }

        public IList<Asteroid> FavouriteAsteroids { get; private set; }
        ObservableCollection<Asteroid> favouriteAsteroids = new ObservableCollection<Asteroid>();
    }
}

