using System.Windows;
using System.Windows.Controls;
using Notes.ViewModels;
using Notes.Models;
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
            if(_mainWindowViewModel.SelectedNote != null) OnNoteChanged(_mainWindowViewModel.SelectedNote);
            DataContext = _mainWindowViewModel;
        }
        
        private void OnNoteChanged(NoteUIModel note)
        {
            if (_currentNoteConfigView == null && note != null)
            {
                _currentNoteConfigView = new NoteConfigView(note);
                _currentNoteConfigView.IsEnabled = true;
                MainGrid.Children.Add(_currentNoteConfigView);
                Grid.SetRow(_currentNoteConfigView, 2);
                Grid.SetRowSpan(_currentNoteConfigView, 3);
                Grid.SetColumn(_currentNoteConfigView, 3);
            }
            else if (_currentNoteConfigView != null && note != null)
            {
                _currentNoteConfigView.DataContext = new NoteConfigViewModel(note);
                _currentNoteConfigView.IsEnabled = true;
            }
            else
            {
                _currentNoteConfigView.DataContext = null;
                _currentNoteConfigView.IsEnabled = false;
            }

        }

    }
}