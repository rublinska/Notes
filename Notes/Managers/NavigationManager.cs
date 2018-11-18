using Notes.Tools;

namespace Notes.Managers
{
    internal class NavigationManager
    {
        #region static
        /// <summary>
        /// This field is used only in lock to synchronize threads
        /// </summary>
        private static readonly object Lock = new object();
        /// <summary>
        /// Singelton Object of a manager
        /// </summary>
        private static NavigationManager _instance;

        /// <summary>
        /// Singelton Object of a manager
        /// </summary>
        public static NavigationManager Instance
        {
            get
            {
                //If object is already initialized, then return it
                if (_instance != null)
                    return _instance;
                //Lock operator for threads synchrnization, in case few threads 
                //will try to initialize Instance at the same time
                lock (Lock)
                {
                    //Initialize Singleton instance and return its object
                    return _instance = new NavigationManager();
                }
            }
        }
        #endregion
        private NavigationModel _navigationModel;
        internal void Initialize(NavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }
        internal void Navigate(ModesEnum mode)
        {
            _navigationModel?.Navigate(mode);
        }

    }
}