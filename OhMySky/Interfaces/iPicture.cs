using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OhMySky.Interfaces
{
    public class iPicture : INotifyPropertyChanged
    {
        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; OnPropertyChanged(); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
