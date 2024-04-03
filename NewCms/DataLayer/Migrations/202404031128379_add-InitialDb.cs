namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageComments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        WebSite = c.String(maxLength: 100),
                        CommentText = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Pages", t => t.PageID, cascadeDelete: true)
                .Index(t => t.PageID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        ShortDescription = c.String(nullable: false, maxLength: 350),
                        Text = c.String(),
                        Tags = c.String(),
                        Visit = c.Int(nullable: false),
                        ImageName = c.String(),
                        showInslider = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.PageGroups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageComments", "PageID", "dbo.Pages");
            DropForeignKey("dbo.Pages", "GroupID", "dbo.PageGroups");
            DropIndex("dbo.Pages", new[] { "GroupID" });
            DropIndex("dbo.PageComments", new[] { "PageID" });
            DropTable("dbo.PageGroups");
            DropTable("dbo.Pages");
            DropTable("dbo.PageComments");
        }
    }
}
