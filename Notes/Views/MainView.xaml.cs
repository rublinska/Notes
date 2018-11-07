using System.Windows;
using System.Windows.Controls;
using Notes.ViewModels;
using Notes.Views.Note;

namespace Notes.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView
    {
        private MainViewViewModel _mainWindowViewModel;
        private NoteConfigView _currentNoteConfigView;

        public MainView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _mainWindowViewModel = new MainViewViewModel();
            _mainWindowViewModel.NoteChanged += OnNoteChanged;
            DataContext = _mainWindowViewModel;
        }
        
        private void OnNoteChanged(Models.Note note)
        {
            if (_currentNoteConfigView == null)
            {
                _currentNoteConfigView = new NoteConfigView(note);
                MainGrid.Children.Add(_currentNoteConfigView);
                Grid.SetRow(_currentNoteConfigView, 0);
                Grid.SetRowSpan(_currentNoteConfigView, 2);
                Grid.SetColumn(_currentNoteConfigView, 1);
            }
            else
                _currentNoteConfigView.DataContext = new NoteConfigViewModel(note);

        }

    }
}