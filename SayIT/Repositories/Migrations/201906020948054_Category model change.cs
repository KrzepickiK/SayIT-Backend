namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categorymodelchange : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Categories", "CategoryName", "Name");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Categories", "Name", "CategoryName");

        }
    }
}
