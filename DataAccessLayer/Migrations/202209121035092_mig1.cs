namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmCode", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "RegistrationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "EmailConfirmDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "EmailConfirmDate");
            DropColumn("dbo.Users", "RegistrationDate");
            DropColumn("dbo.Users", "ConfirmCode");
        }
    }
}
