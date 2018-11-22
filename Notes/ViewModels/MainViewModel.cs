using Notes.DBModels;
using Notes.Managers;
using Notes.Models;
using Notes.Properties;
using Notes.Tools;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Notes.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields
        private NoteUIModel _selectedNote;
        private ObservableCollection<NoteUIModel> _notes;
        #region Commands
        private ICommand _logOutCommand;
        private ICommand _addNoteCommand;
        private ICommand _deleteNoteCommand;
        #endregion
        #endregion

        #region Properties
        #region Commands
        
        public ICommand LogOutCommand
        {
            get
            {
                return _logOutCommand ?? (_logOutCommand = new RelayCommand<object>(LogOutExecute));
            }
        }

        public ICommand AddNoteCommand
        {
            get
            {
                return _addNoteCommand ?? (_addNoteCommand = new RelayCommand<object>(AddNoteExecute));
            }
        }
        
        
        public ICommand DeleteNoteCommand
        {
            get
            {
                return _deleteNoteCommand ?? (_deleteNoteCommand = new RelayCommand<KeyEventArgs>(DeleteNoteExecute));
            }
        }
        #endregion

        public ObservableCollection<NoteUIModel> Notes
        {
            get { return _notes; }
        }
        public NoteUIModel SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor
        public MainViewViewModel()
        {
            FillNotes();
            PropertyChanged += OnPropertyChanged;
        }
        #endregion
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SelectedNote")
                OnNoteChanged(_selectedNote);
        }
        public void FillNotes()
        {
            _notes = new ObservableCollection<NoteUIModel>();
            foreach (var note in StationManager.CurrentUser.Notes)
            {
                _notes.Add(new NoteUIModel(note));
            }
            if (_notes.Count > 0)
            {
                _selectedNote = Notes[0];
            }
        }

        private async void DeleteNoteExecute(KeyEventArgs args)
        {
            //    if (args.Key != Key.Delete) return;

            LoaderManager.ShowLoader();
            await Task.Run(() =>
            {
                if (SelectedNote == null) return;

                StationManager.CurrentUser.Notes.RemoveAll(uwr => uwr.Guid == SelectedNote.Guid);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    DBManager.DeleteNote(SelectedNote.Note);
                    FillNotes();
                    OnPropertyChanged(nameof(SelectedNote));
                    OnPropertyChanged(nameof(Notes));
                });
            });
            LoaderManager.HideLoader();
        }

        private async void AddNoteExecute(object o)
        {
            LoaderManager.ShowLoader();
            await Task.Run(() =>
            {
                Note note = new Note("New Note", "", StationManager.CurrentUser);
                DBManager.AddNote(note);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    var noteUIModel = new NoteUIModel(note);
                    _notes.Add(noteUIModel);
                    FillNotes();
                    SelectedNote = noteUIModel;
                });
            });
            LoaderManager.HideLoader();
        }
        private void LogOutExecute(object o)
        {
            StationManager.DeleteCurrentUserFromCache();
            NavigationManager.Instance.Navigate(ModesEnum.SignIn);
        }

        #region EventsAndHandlers
        #region Loader
        internal event NoteChangedHandler NoteChanged;
        internal delegate void NoteChangedHandler(NoteUIModel note);

        internal virtual void OnNoteChanged(NoteUIModel note) => NoteChanged?.Invoke(note);
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion


    }
}