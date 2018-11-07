using System.Windows.Controls;
using Notes.Managers;
using Notes.Tools;
using Notes.ViewModels;

namespace Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            mainWindowViewModel.StartApplication();
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}