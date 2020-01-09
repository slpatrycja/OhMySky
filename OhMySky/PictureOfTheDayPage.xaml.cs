using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OhMySky
{
	public partial class PictureOfTheDayPage : ContentPage
	{
		public PictureOfTheDayPage()
        {
            InitializeComponent();
            BindingContext = new PictureOfTheDayViewModel();
		}

        private Task GetPictureOfTheDay()
        {
            throw new NotImplementedException();
        }
    }
}