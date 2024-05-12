namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_customerProfile_and_Meal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        PaymentMethod = c.String(nullable: false, maxLength: 50),
                        CurrentPassword = c.String(nullable: false, maxLength: 50),
                        NewPassword = c.String(nullable: false, maxLength: 50),
                        ConfirmPassword = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profiles");
            DropTable("dbo.Meals");
        }
    }
}
