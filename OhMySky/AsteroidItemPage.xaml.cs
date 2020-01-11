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
            await Navigation.PopAsync();
        }
    }
}
