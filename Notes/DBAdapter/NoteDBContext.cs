using System.Data.Entity;
using Notes.Migrations;
using Notes.DBModels;

namespace Notes.DBAdapter
{
    internal class NoteDBContext : DbContext
    {
        public NoteDBContext() : base("NewNoteDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NoteDBContext, Configuration>(true));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Note.NoteEntityConfiguration());
        }
    }
}