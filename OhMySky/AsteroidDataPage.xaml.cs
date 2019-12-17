using System;
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
	}
}