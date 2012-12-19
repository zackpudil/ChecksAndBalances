namespace ChecksAndBalances.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Authors = c.String(),
                        Sources = c.String(),
                        Published = c.Boolean(nullable: false),
                        DatePublished = c.DateTime(nullable: false, storeType: "datetime2"),
                        Views = c.Int(nullable: false),
                        SpotLighted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.CategoryTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.ArticleInProgresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SavedContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryTagArticles",
                c => new
                    {
                        CategoryTag_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryTag_Id, t.Article_Id })
                .ForeignKey("dbo.CategoryTags", t => t.CategoryTag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .Index(t => t.CategoryTag_Id)
                .Index(t => t.Article_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CategoryTagArticles", new[] { "Article_Id" });
            DropIndex("dbo.CategoryTagArticles", new[] { "CategoryTag_Id" });
            DropIndex("dbo.Comments", new[] { "Article_Id" });
            DropIndex("dbo.ArticleStates", new[] { "Article_Id" });
            DropForeignKey("dbo.CategoryTagArticles", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.CategoryTagArticles", "CategoryTag_Id", "dbo.CategoryTags");
            DropForeignKey("dbo.Comments", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.ArticleStates", "Article_Id", "dbo.Articles");
            DropTable("dbo.CategoryTagArticles");
            DropTable("dbo.ArticleImages");
            DropTable("dbo.ArticleInProgresses");
            DropTable("dbo.Comments");
            DropTable("dbo.CategoryTags");
            DropTable("dbo.ArticleStates");
            DropTable("dbo.Articles");
        }
    }
}
