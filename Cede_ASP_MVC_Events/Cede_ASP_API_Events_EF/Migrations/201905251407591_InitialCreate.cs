namespace Cede_ASP_API_Events_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Guid(nullable: false),
                        PersonalId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 120),
                        Description = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Personal", t => t.PersonalId, cascadeDelete: true)
                .Index(t => t.PersonalId);
            
            CreateTable(
                "dbo.Personal",
                c => new
                    {
                        PersonalId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 120),
                        LastName = c.String(nullable: false, maxLength: 120),
                        Email = c.String(maxLength: 120),
                        IsDeleted = c.Boolean(nullable: false),
                        Phone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PersonalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "PersonalId", "dbo.Personal");
            DropIndex("dbo.Event", new[] { "PersonalId" });
            DropTable("dbo.Personal");
            DropTable("dbo.Event");
        }
    }
}
