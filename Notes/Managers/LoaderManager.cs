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

        private static readonly object Lock = new object();
        private static LoaderManager _instance;

        internal static LoaderManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Lock)
                {
                    return _instance = new LoaderManager();
                }
            }
        }

        internal static void Initialize(ILoaderOwner owner)
        {
            _loaderOwner = owner;
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