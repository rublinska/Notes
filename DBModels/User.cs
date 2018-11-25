using System;
using System.Collections.Generic;
using Notes.Tools;
using System.Runtime.Serialization;
using System.Data.Entity.ModelConfiguration;

namespace Notes.DBModels
{

    [Serializable]
    [DataContract(IsReference = true)]
    public class User
    {

        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;
        [DataMember]
        private string _login;
        [DataMember]
        private string _email;
        [DataMember]
        private string _password;
        [DataMember]
        private DateTime _lastLoginDate;
        [DataMember]
        private List<Note> _notes;
        #endregion
        #region Properties 
        public Guid Guid
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public DateTime LastLoginDate
        {
            get
            {
                return _lastLoginDate;
            }
            set
            {
                _lastLoginDate = value;
            }
        }
        public string Password
        {
            get { return _password; }
            private set { _password = value; }
        }
        public List<Note> Notes
        {
            get { return _notes; }
            private set { _notes = value; }
        }
        #endregion
        #region Constructor

        public User(string Login, string FirstName, string LastName, string Email, string password) : this()
        {
            _guid = Guid.NewGuid();
            _firstName = FirstName;
            _lastName = LastName;
            _login = Login;
            _email = Email;
            _lastLoginDate = DateTime.Now;

            SetPassword(password);
        }

        private User()
        {
            _notes = new List<Note>();
        }

        #endregion

        private void SetPassword(string password)
        {
            _password = Encrypting.GetMd5HashForString(password);
        }
        public bool CheckPassword(string password)
        {
            try
            {
                string res2 = Encrypting.GetMd5HashForString(password);
                return _password == res2;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckPassword(User userCandidate)
        {
            try
            {
                return _password == userCandidate._password;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        #region EntityConfiguration
        public class UserEntityConfiguration : EntityTypeConfiguration<User>
        {
            public UserEntityConfiguration()
            {
                ToTable("Users");
                HasKey(s => s.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                Property(p => p.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();
                Property(p => p.Login)
                    .HasColumnName("Login")
                    .IsRequired();
                Property(p => p.Email)
                    .HasColumnName("Email")
                    .IsOptional();
                Property(p => p.Password)
                    .HasColumnName("Password")
                    .IsRequired();
                Property(p => p.LastLoginDate)
                    .HasColumnName("LastLoginDate")
                    .IsRequired();

                HasMany(s => s.Notes)
                    .WithRequired(w => w.User)
                    .HasForeignKey(w => w.UserGuid)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion

    }
}