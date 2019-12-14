namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accounts_refactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "AccountTypeId" });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        AvatarUrl = c.String(),
                        AccountTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Users", "AccountTypeId");
            CreateIndex("dbo.Users", "Id", unique: true);
            AddForeignKey("dbo.Users", "AccountTypeId", "dbo.AccountTypes", "Id", cascadeDelete: true);
        }
    }
}
