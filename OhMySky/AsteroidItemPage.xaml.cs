using System;
using OhMySky.Models;
using Xamarin.Forms;

namespace OhMySky
{
    public partial class AsteroidItemPage : ContentPage
    {
        public AsteroidItemPage()
        {
            InitializeComponent();
        }

        async void addToFavourite(object sender, EventArgs e)
        {
            var asteroid = (Asteroid)BindingContext;
            await App.Database.SaveItemAsync(asteroid);
            await Navigation.PushAsync(new AsteroidDataPage());
        }

        async void removeFromFavourites(object sender, EventArgs e)
        {
            var asteroid = (Asteroid)BindingContext;
            await App.Database.DeleteItemAsync(asteroid);
            await Navigation.PushAsync(new FavouriteAsteroidsPage());
        }
    }
}
