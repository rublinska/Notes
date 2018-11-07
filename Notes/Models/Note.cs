using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Models
{


    [Serializable]
    public class Note
    {
        #region Fields
        private Guid _guid;
        private string _title;
        private string _text;
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
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        #endregion

        #region Constructor
        public Note(string title, User user) : this()
        {
            _guid = Guid.NewGuid();
            _title = title;
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
    }
}

