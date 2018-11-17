using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Notes.DBModels;
using Notes.Properties;

namespace Notes.Models
{
    public class NoteUIModel : INotifyPropertyChanged
    {
        #region Fields
        private Note _note;
        #endregion

        #region Properties
        internal Note Note
        {
            get { return _note; }
            private set
            {
                _note = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _note.Title; }
            set
            {
                _note.Title = value;
                OnPropertyChanged();
            }
        }

        public string NoteText
        {
            get { return _note.NoteText; }
            set
            {
                _note.NoteText = value;
                OnPropertyChanged();
            }
        }
        public Guid Guid
        {
            get { return _note.Guid; }
        }

        #endregion

        public NoteUIModel(Note note)
        {
            _note = note;
        }

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