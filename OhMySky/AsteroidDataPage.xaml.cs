using System;
using OhMySky.Models;
using Xamarin.Forms;

namespace OhMySky
{
	public partial class AsteroidDataPage : ContentPage
	{
		public AsteroidDataPage()
        {
            InitializeComponent();
            BindingContext = new AsteroidDataViewModel();
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