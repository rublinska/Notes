using Notes.DBModels;
using System;
using System.ServiceModel;
using System.Collections.Generic;

namespace Notes.ServiceInterface
{
    class NoteServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<INoteContract>("Server"))
            {
                INoteContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<INoteContract>("Server"))
            {
                INoteContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var myChannelFactory = new ChannelFactory<INoteContract>("Server"))
            {
                INoteContract client = myChannelFactory.CreateChannel();
                return client.GetUserByGuid(guid);
            }
        }

        public static void AddUser(User user)
        {
            using (var myChannelFactory = new ChannelFactory<INoteContract>("Server"))
            {
                INoteContract client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }

        public static void AddNote(Note note)
        {
            using (var myChannelFactory = new ChannelFactory<INoteContract>("Server"))
            {
                INoteContract client = myChannelFactory.CreateChannel();
                client.AddNote(note);
            }
        }

        public static void SaveNote(Note note)
        {
            using (var myChannelFactory = new ChannelFactory<INoteContract>("Server"))
            {
                INoteContract client = myChannelFactory.CreateChannel();
                client.SaveNote(note);
            }
        }

        public static List<User> GetAllUsers(Guid noteGuid)
        {
            using (var myChannelFactory = new ChannelFactory<INoteContract>("Server"))
            {
                INoteContract client = myChannelFactory.CreateChannel();
                return client.GetAllUsers(noteGuid);
            }
        }

        public static void DeleteNote(Note selectedNote)
        {
            using (var myChannelFactory = new ChannelFactory<INoteContract>("Server"))
            {
                INoteContract client = myChannelFactory.CreateChannel();
                client.DeleteNote(selectedNote);
            }
        }
    }
}
