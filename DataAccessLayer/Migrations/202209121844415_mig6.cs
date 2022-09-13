namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropIndex("dbo.Logins", new[] { "UserId" });
            AlterColumn("dbo.Logins", "LoginDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Logins", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Logins", "LoginDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Logins", "UserId");
            AddForeignKey("dbo.Logins", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
