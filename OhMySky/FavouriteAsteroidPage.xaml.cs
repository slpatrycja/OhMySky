using System;
using OhMySky.Models;
using Xamarin.Forms;

namespace OhMySky
{
    public partial class FavouriteAsteroidPage : ContentPage
    {
        public FavouriteAsteroidPage()
        {
            InitializeComponent();
        }

        async void removeFromFavourites(object sender, EventArgs e)
        {
            var asteroid = (Asteroid)BindingContext;
            await App.Database.DeleteItemAsync(asteroid);
            await Navigation.PopAsync();
        }
    }
}
