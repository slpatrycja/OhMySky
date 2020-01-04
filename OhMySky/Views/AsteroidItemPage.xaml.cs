using Xamarin.Forms;

namespace OhMySky
{
    public partial class AsteroidItemPage : ContentPage
    {
        public AsteroidItemPage()
        {
            InitializeComponent();
            BindingContext = new AsteroidItemViewModel();
        }
    }
}
