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
    }
}
