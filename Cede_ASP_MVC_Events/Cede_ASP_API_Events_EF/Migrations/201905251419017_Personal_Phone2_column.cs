namespace Cede_ASP_API_Events_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Personal_Phone2_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personal", "Phone2", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personal", "Phone2");
        }
    }
}
