using System;
using System.Threading.Tasks;
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

        private Task GetAsteroidData()
        {
            throw new NotImplementedException();
        }
    }
}