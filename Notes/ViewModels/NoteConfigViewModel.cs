﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using Notes.Managers;
using Notes.Models;
using Notes.Properties;

namespace Notes.ViewModels
{
    internal class 
        NoteConfigViewModel : INotifyPropertyChanged
    {
        #region Fields
        private readonly NoteUIModel _currentNote;
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