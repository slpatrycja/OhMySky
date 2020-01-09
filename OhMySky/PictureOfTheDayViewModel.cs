using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Disposables;
using System.Windows.Input;
using OhMySky.Infrastructure;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OhMySky
{

    public class PictureOfTheDayViewModel : INotifyPropertyChanged
    {
        public Command TextCommand { get; }
        public PictureData PictureData { get; set; }        private iPicture _Picture;        public iPicture Picture
        {
            get { return _Picture; }
            set
            {
                _Picture = value;
                OnPropertyChanged();
            }
        }
        public PictureOfTheDayViewModel()
        {
            Task.Run(async () => { await GetPictureData(); });
        }

        public async Task GetPictureData()
        {
            RestService restService = new RestService();
            PictureData = await restService.GetPictureOfTheDay(GenerateRequestUri(Constants.NasaPictureOfTheDayEndpoint));

            Picture = new iPicture
            {
                Url = PictureData.Url,
                Title = PictureData.Title
            };
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?api_key={Constants.APIKey}";
            return requestUri;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
