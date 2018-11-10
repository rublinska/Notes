using System.Collections.Generic;
using System.Linq;
using Notes.Models;
using Notes.Tools;

namespace Notes.Managers
{
    internal class DBManager
    {
        private static readonly List<User> Users;

        static DBManager()
        {
            Users = SerializationManager.Deserialize<List<User>>(FileFolderHelper.StorageFilePath) ?? new List<User>();
      
        }

        internal static bool UserExists(string login)
        {
            return Users.Any(u => u.Login == login);
        }

        internal static User GetUserByLogin(string login)
        {
            return Users.FirstOrDefault(u => u.Login == login);
        }

        internal static void AddUser(User user)
        {
            Users.Add(user);
            SaveChangesu();
        }

        private static void SaveChangesu()
        {
            SerializationManager.Serialize(Users, FileFolderHelper.StorageFilePath);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = Users.FirstOrDefault(u => u.Guid == userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void UpdateUser(User currentUser)
        {
            SaveChangesu();
        }


        public DBManager()
        {
            Notes = SerializationManager.Deserialize<List<Note>>(FileFolderHelper.StorageFilePath) ?? new List<Note>();

        }

        private static List<Note> Notes;

        internal static void AddNote(Note note)
        {
            Notes.Add(note);
            SaveChangesn();
        }

        private static void SaveChangesn()
        {
            SerializationManager.Serialize(Notes, FileFolderHelper.StorageFilePath);
        }

        public static void UpdateNote(Note currentNote)
        {
            SaveChangesn();
        }
    }
}
