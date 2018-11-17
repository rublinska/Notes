using System.Windows;
using Notes.Tools;
using Notes.ViewModels;

namespace Notes.Managers
{
    internal class LoaderManager
    {
        #region static
        private static ILoaderOwner _loaderOwner;
        #endregion 

        private static ILoaderOwner ViewModel
        {
            get
            {
                return _loaderOwner ?? (_loaderOwner = new LoaderViewModel());
            }
            set { _loaderOwner = value; }
        }

        internal static void Initialize(ILoaderOwner owner)
        {
            ViewModel = owner;
        }

        internal static void ShowLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Visible;
            _loaderOwner.IsEnabled = false;

        }

        internal static void HideLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Hidden;
            _loaderOwner.IsEnabled = true;
        }
    }
}