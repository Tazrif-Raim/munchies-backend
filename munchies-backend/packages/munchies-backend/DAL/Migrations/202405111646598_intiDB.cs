namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intiDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderText = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        OrderedBy = c.String(maxLength: 128),
                        ResturantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resturants", t => t.ResturantId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OrderedBy)
                .Index(t => t.OrderedBy)
                .Index(t => t.ResturantId);
            
            CreateTable(
                "dbo.Resturants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ResturantedBy = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ResturantedBy)
                .Index(t => t.ResturantedBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Uname = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Uname);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderedBy", "dbo.Users");
            DropForeignKey("dbo.Orders", "ResturantId", "dbo.Resturants");
            DropForeignKey("dbo.Resturants", "ResturantedBy", "dbo.Users");
            DropIndex("dbo.Resturants", new[] { "ResturantedBy" });
            DropIndex("dbo.Orders", new[] { "ResturantId" });
            DropIndex("dbo.Orders", new[] { "OrderedBy" });
            DropTable("dbo.Users");
            DropTable("dbo.Resturants");
            DropTable("dbo.Orders");
        }
    }
}
