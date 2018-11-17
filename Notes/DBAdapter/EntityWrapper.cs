using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Notes.DBModels;

namespace Notes.DBAdapter
{
    public static class EntityWrapper
    {
        public static bool UserExists(string login)
        {
            using (var context = new NoteDBContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new NoteDBContext())
            {
                return context.Users.Include(u => u.Notes).FirstOrDefault(u => u.Login == login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var context = new NoteDBContext())
            {
                return context.Users.Include(u => u.Notes).FirstOrDefault(u => u.Guid == guid);
            }
        }

        public static List<User> GetAllUsers(Guid noteGuid)
        {
            using (var context = new NoteDBContext())
            {
                return context.Users.Where(u => u.Notes.All(r => r.Guid != noteGuid)).ToList();
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new NoteDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddNote(Note note)
        {
            using (var context = new NoteDBContext())
            {
                note.DeleteDatabaseValues();
                context.Notes.Add(note);
                context.SaveChanges();
            }
        }

        public static void SaveNote(Note note)
        {
            using (var context = new NoteDBContext())
            {
                context.Entry(note).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void DeleteNote(Note selectedNote)
        {
            using (var context = new NoteDBContext())
            {
                selectedNote.DeleteDatabaseValues();
                context.Notes.Attach(selectedNote);
                context.Notes.Remove(selectedNote);
                context.SaveChanges();
            }
        }
    }
}