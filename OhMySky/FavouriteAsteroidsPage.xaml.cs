using OhMySky.Models;
using OhMySky.ViewModels;
using Xamarin.Forms;

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
                await Navigation.PushAsync(new FavouriteAsteroidPage
                {
                    BindingContext = e.SelectedItem as Asteroid
                });
            }
        }
    }
}
