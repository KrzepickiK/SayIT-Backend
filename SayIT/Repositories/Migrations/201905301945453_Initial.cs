namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypeId, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        MaterialIconName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TranslationEN = c.String(),
                        TranslationPL = c.String(),
                        MeaningPL = c.String(),
                        MeaningEN = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TranslationId = c.Int(nullable: false),
                        LearningTypeId = c.Int(nullable: false),
                        Option1 = c.String(),
                        Option2 = c.String(),
                        Option3 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LearningTypes", t => t.LearningTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Translations", t => t.TranslationId, cascadeDelete: true)
                .Index(t => t.TranslationId)
                .Index(t => t.LearningTypeId);
            
            CreateTable(
                "dbo.LearningTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Translations", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.QuizQuestions", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.QuizQuestions", "LearningTypeId", "dbo.LearningTypes");
            DropForeignKey("dbo.Users", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.QuizQuestions", new[] { "LearningTypeId" });
            DropIndex("dbo.QuizQuestions", new[] { "TranslationId" });
            DropIndex("dbo.Translations", new[] { "CategoryId" });
            DropIndex("dbo.Users", new[] { "AccountTypeId" });
            DropIndex("dbo.Users", new[] { "Id" });
            DropTable("dbo.LearningTypes");
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.Translations");
            DropTable("dbo.Categories");
            DropTable("dbo.Users");
            DropTable("dbo.AccountTypes");
        }
    }
}
