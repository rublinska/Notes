using System;
using System.Data.Entity.ModelConfiguration;

namespace Notes.DBModels
{
    
    [Serializable]
    public class Note
    {
        #region Fields
        private Guid _guid;
        private string _title;
        private string _text;
        private Guid _userGuid;
        private User _user;
        #endregion

        #region Properties
        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string NoteText
        {
            get { return _text; }
            set { _text = value; }
        }
        public Guid UserGuid
        {
            get { return _userGuid; }
            private set { _userGuid = value; }
        }
        public User User
        {
            get { return _user; }
            private set { _user = value; }
        }
        #endregion

        #region Constructor
        public Note(string title, string text, User user) : this()
        {
            _guid = Guid.NewGuid();
            _title = title;
            _text = text;
            _userGuid = user.Guid;
            _user = user;
            user.Notes.Add(this);
        }
        private Note()
        {
        }
        #endregion
        public override string ToString()
        {
            return Title;
        }
        #region EntityFrameworkConfiguration
        public class NoteEntityConfiguration : EntityTypeConfiguration<Note>
        {
            public NoteEntityConfiguration()
            {
                ToTable("Note");
                HasKey(s => s.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.Title)
                    .HasColumnName("Title")
                    .IsRequired();
                Property(p => p.NoteText)
                    .HasColumnName("NoteText")
                    .IsRequired();
            }
        }
        #endregion

        public void DeleteDatabaseValues()
        {
            _user = null;
        }
    }
}

