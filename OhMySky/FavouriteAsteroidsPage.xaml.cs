using OhMySky.ViewModels;
using OhMySky.Models;
using Xamarin.Forms;
using System;

namespace OhMySky
{
    public partial class FavouriteAsteroidsPage : ContentPage
    {
        public FavouriteAsteroidsPage()
        {
            InitializeComponent();
            BindingContext = new FavouriteAsteroidsViewModel();
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AsteroidItemPage
                {
                    BindingContext = e.SelectedItem as Asteroid
                });
            }
        }
    }
}
