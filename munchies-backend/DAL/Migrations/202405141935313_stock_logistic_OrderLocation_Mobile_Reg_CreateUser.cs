namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock_logistic_OrderLocation_Mobile_Reg_CreateUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangeMobileBankingNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        NewPhoneNumber = c.String(),
                        OldPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreateUsers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        userRole = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Logistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Restaurant = c.String(nullable: false, maxLength: 60),
                        Description = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Address = c.String(nullable: false),
                        MealId = c.Int(),
                        ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.MealId)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.MealId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 255),
                        PasswordHash = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.RegistrationId);
            
            CreateTable(
                "dbo.StockTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company_Name = c.String(nullable: false, maxLength: 60),
                        Current_Price = c.Int(nullable: false),
                        High_Price = c.Int(nullable: false),
                        Low_Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLocations", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.OrderLocations", "MealId", "dbo.Meals");
            DropIndex("dbo.OrderLocations", new[] { "ProfileId" });
            DropIndex("dbo.OrderLocations", new[] { "MealId" });
            DropTable("dbo.StockTables");
            DropTable("dbo.Registrations");
            DropTable("dbo.OrderLocations");
            DropTable("dbo.Logistics");
            DropTable("dbo.CreateUsers");
            DropTable("dbo.ChangeMobileBankingNumbers");
        }
    }
}
