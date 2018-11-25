
using Notes.DBModels;
using WCF.Notes.ServiceInterface;
using Notes.Tools;

namespace Notes.Managers
{
    public class DBManager
    {

        public static bool UserExists(string login)
        {
            return NoteServiceWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return NoteServiceWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            NoteServiceWrapper.AddUser(user);
        }


        public static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = NoteServiceWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void DeleteNote(Note selectedNote)
        {
            NoteServiceWrapper.DeleteNote(selectedNote);
            Logger.Log("Note '" + $"\t{selectedNote.ToString()}" + "' deleted.");
        }

        public static void SaveNote(Note selectedNote)
        {
            NoteServiceWrapper.SaveNote(selectedNote);
            Logger.Log("Note '" + $"\t{selectedNote.ToString()}" + "' saved after editing.");
        }

        public static void AddNote(Note note)
        {
            NoteServiceWrapper.AddNote(note);
            Logger.Log("New note added.");
        }
    }
}