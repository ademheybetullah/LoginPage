namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registrations", "UserId", "dbo.Users");
            DropIndex("dbo.Registrations", new[] { "UserId" });
            DropColumn("dbo.Users", "RegistrationId");
            DropTable("dbo.Registrations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistrationId);
            
            AddColumn("dbo.Users", "RegistrationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Registrations", "UserId");
            AddForeignKey("dbo.Registrations", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
