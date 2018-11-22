
using Notes.DBModels;
using Notes.DBAdapter;
using Notes.Tools;

namespace Notes.Managers
{
    internal class DBManager
    {

        internal static bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        internal static User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        internal  static void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }


        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = EntityWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void DeleteNote(Note selectedNote)
        {
            EntityWrapper.DeleteNote(selectedNote);
            Logger.Log("Note '"+$"\t{selectedNote.ToString()}"+"' deleted.");
        }

        public static void SaveNote(Note selectedNote)
        {
            EntityWrapper.SaveNote(selectedNote);
            Logger.Log("Note '"+ $"\t{selectedNote.ToString()}"+"' saved after editing.");
        }

        public static void AddNote(Note note)
        {
            EntityWrapper.AddNote(note);
            Logger.Log("New note added.");
        }
    }
}