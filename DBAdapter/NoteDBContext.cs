using System.Data.Entity;
using Notes.DBAdapter.Migrations;
using Notes.DBModels;

namespace Notes.DBAdapter
{
    internal class NoteDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        public NoteDBContext() : base("NewNoteDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NoteDBContext, Configuration>(true));
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Note.NoteEntityConfiguration());
        }
    }
}