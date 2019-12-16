using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.IO;
using System.Reflection;

namespace OhMySky
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SKPaint backgroundFillPaint = new SKPaint { Style = SKPaintStyle.Fill };

        public MainPage()
        {
            InitializeComponent();
            CreateShader();
            GetAsteroidsData();

        }

        public async void GetAsteroidsData()
        {
            RestService restService = new RestService();
            AsteroidData asteroidData = await restService.GetAsteroidData(GenerateRequestUri(Constants.NasaApiEndpoint));
            BindingContext = asteroidData;
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?start_date={GetCurrentDate()}&end_date={GetCurrentDate()}";
            requestUri += $"&api_key={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        private string GetCurrentDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            return dateTime.ToString("yyyy-MM-dd");
        }

        private void CreateShader()
        {
            System.Reflection.Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("OhMySky.Background.jpg"))
            using (SKManagedStream skStream = new SKManagedStream(stream))
            using (SKBitmap bitmap = SKBitmap.Decode(skStream))
            using (SKShader shader = SKShader.CreateBitmap(bitmap, SKShaderTileMode.Mirror, SKShaderTileMode.Mirror))
            {
                backgroundFillPaint.Shader = shader;
            }
        }

    }
}
