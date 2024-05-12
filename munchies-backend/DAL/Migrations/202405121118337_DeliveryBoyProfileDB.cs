namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeliveryBoyProfileDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryBoyProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        VehicleNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeliveryBoyProfiles");
        }
    }
}
