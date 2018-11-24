using Notes.DBAdapter;
using Notes.DBModels;
using Notes.ServiceInterface;
using System;
using System.Collections.Generic;

namespace Notes.NoteService
{
    class NoteService : INoteContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public User GetUserByGuid(Guid guid)
        {
            return EntityWrapper.GetUserByGuid(guid);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddNote(Note note)
        {
            EntityWrapper.AddNote(note);
        }

        public List<User> GetAllUsers(Guid NoteGuid)
        {
            return EntityWrapper.GetAllUsers(NoteGuid);
        }

        public void DeleteNote(Note selectedNote)
        {
            EntityWrapper.DeleteNote(selectedNote);
        }


        public void SaveNote(Note note)
        {
            EntityWrapper.SaveNote(note);
        }
    }
}
