namespace Notes.DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        NoteText = c.String(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Users", t => t.UserGuid, cascadeDelete: true)
                .Index(t => t.UserGuid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Email = c.String(),
                        LastLoginDate = c.DateTime(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "UserGuid", "dbo.Users");
            DropIndex("dbo.Note", new[] { "UserGuid" });
            DropTable("dbo.Users");
            DropTable("dbo.Note");
        }
    }
}
