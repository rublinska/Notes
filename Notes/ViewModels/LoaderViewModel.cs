using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Notes.Tools;

namespace Notes.ViewModels
{
    internal class LoaderViewModel : ILoaderOwner
    {
        private Visibility _loaderVisibility = Visibility.Collapsed;
        private bool _isEnabled = true;

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}