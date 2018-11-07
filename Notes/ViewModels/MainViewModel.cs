using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Notes.Managers;
using Notes.Models;
using Notes.Properties;
using Notes.Tools;

namespace Notes.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Note _selectedNote;
        private ObservableCollection<Note> _notes;
        #region Commands
        private ICommand _addNoteCommand;
        private ICommand _editNoteCommand;
        private ICommand _deleteNoteCommand;
        #endregion
        #endregion

        #region Properties
        #region Commands

        public ICommand AddNoteCommand
        {
            get
            {
                return _addNoteCommand ?? (_addNoteCommand = new RelayCommand<object>(AddNoteExecute));
            }
        }
        /*
        public ICommand EditNoteCommand
        {
            get
            {
                return _editNoteCommand ?? (_editNoteCommand = new RelayCommand<KeyEventArgs>(EditNoteExecute));
            }
        }
        */
        public ICommand DeleteNoteCommand
        {
            get
            {
                return _deleteNoteCommand ?? (_deleteNoteCommand = new RelayCommand<KeyEventArgs>(DeleteNoteExecute));
            }
        }
        #endregion

        public ObservableCollection<Note> Notes
        {
            get { return _notes; }
        }
        public Note SelectedNote
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
        private void FillNotes()
        {
            _notes = new ObservableCollection<Note>();
            foreach (var Note in StationManager.CurrentUser.Notes)
            {
                _notes.Add(Note);
            }
            if (_notes.Count > 0)
            {
                _selectedNote = Notes[0];
            }
        }

        private void DeleteNoteExecute(KeyEventArgs args)
        {
            if (args.Key != Key.Delete) return;

            if (SelectedNote == null) return;

            StationManager.CurrentUser.Notes.RemoveAll(uwr => uwr.Guid == SelectedNote.Guid);
            DBManager.UpdateUser(StationManager.CurrentUser);
            FillNotes();
            OnPropertyChanged(nameof(SelectedNote));
            OnPropertyChanged(nameof(Notes));
        }

        private void AddNoteExecute(object o)
        {
            Note note = new Note("New Note", StationManager.CurrentUser);
            _notes.Add(note);
            _selectedNote = note;
        }

        #region EventsAndHandlers
        #region Loader
        internal event NoteChangedHandler NoteChanged;
        internal delegate void NoteChangedHandler(Note note);

        internal virtual void OnNoteChanged(Note note) => NoteChanged?.Invoke(note);
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