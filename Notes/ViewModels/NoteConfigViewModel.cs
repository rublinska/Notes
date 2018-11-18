using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Notes.Managers;
using Notes.Models;
using Notes.Properties;
using Notes.Tools;

namespace Notes.ViewModels
{
    internal class 
        NoteConfigViewModel : INotifyPropertyChanged
    {
        #region Fields
        private readonly NoteUIModel _currentNote;
        #endregion
        #region Commands
        private ICommand _editNoteCommand;
        #endregion

        #region Commands
        public ICommand EditNoteCommand
        {
            get
            {
                return _editNoteCommand ?? (_editNoteCommand = new RelayCommand<KeyEventArgs>(EditNoteExecute));
            }
        }
        #endregion

        #region Properties

        public string Title
        {
            get { return _currentNote.Title; }
            set
            {
                _currentNote.Title = value;
                OnPropertyChanged();
            }
        }
        public string NoteText
        {
            get { return _currentNote.NoteText; }
            set
            {
                _currentNote.NoteText = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private void EditNoteExecute(KeyEventArgs args)
        {
            DBManager.SaveNote(_currentNote.Note);
            MessageBox.Show("Note saved");
        }

        #region Constructor
        public NoteConfigViewModel(NoteUIModel note)
        {
            _currentNote = note;
        }
        #endregion
        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion


    }
}