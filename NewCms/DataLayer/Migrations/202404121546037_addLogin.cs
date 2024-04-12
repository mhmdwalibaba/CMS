namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.LoginID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logins");
        }
    }
}
