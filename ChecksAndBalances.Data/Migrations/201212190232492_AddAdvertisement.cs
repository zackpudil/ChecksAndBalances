namespace ChecksAndBalances.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdvertisement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "Advertisement_Id", c => c.Int());
            AddForeignKey("dbo.Articles", "Advertisement_Id", "dbo.Advertisements", "Id");
            CreateIndex("dbo.Articles", "Advertisement_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Articles", new[] { "Advertisement_Id" });
            DropForeignKey("dbo.Articles", "Advertisement_Id", "dbo.Advertisements");
            DropColumn("dbo.Articles", "Advertisement_Id");
            DropTable("dbo.Advertisements");
        }
    }
}
