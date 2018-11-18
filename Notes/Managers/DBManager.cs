
using Notes.DBModels;
using Notes.DBAdapter;

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

        internal static void AddUser(User user)
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
        }
        public static void SaveNote(Note selectedNote)
        {
            EntityWrapper.SaveNote(selectedNote);
        }

        public static void AddNote(Note note)
        {
            EntityWrapper.AddNote(note);
        }
    }
}