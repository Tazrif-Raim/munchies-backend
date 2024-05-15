namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login_reg : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Logistics");
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        userRole = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.DeliveryMen",
                c => new
                    {
                        id = c.Int(nullable: false),
                        name = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        location = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        id = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.tokens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        token_string = c.String(),
                        expireTime = c.DateTime(nullable: false),
                        userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid);
            
            AddColumn("dbo.Recipes", "Restaurant_id", c => c.Int());
            AddColumn("dbo.OrderLocations", "DeliveryMan_id", c => c.Int());
            AlterColumn("dbo.Logistics", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Logistics", "id");
            CreateIndex("dbo.OrderLocations", "DeliveryMan_id");
            CreateIndex("dbo.Logistics", "id");
            CreateIndex("dbo.Recipes", "Restaurant_id");
            AddForeignKey("dbo.OrderLocations", "DeliveryMan_id", "dbo.DeliveryMen", "id");
            AddForeignKey("dbo.Logistics", "id", "dbo.users", "id");
            AddForeignKey("dbo.Recipes", "Restaurant_id", "dbo.Restaurants", "id");
            DropTable("dbo.CreateUsers");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.tokens", "userid", "dbo.users");
            DropForeignKey("dbo.Admins", "id", "dbo.users");
            DropForeignKey("dbo.Restaurants", "id", "dbo.users");
            DropForeignKey("dbo.Recipes", "Restaurant_id", "dbo.Restaurants");
            DropForeignKey("dbo.Logistics", "id", "dbo.users");
            DropForeignKey("dbo.DeliveryMen", "id", "dbo.users");
            DropForeignKey("dbo.OrderLocations", "DeliveryMan_id", "dbo.DeliveryMen");
            DropForeignKey("dbo.Customers", "id", "dbo.users");
            DropIndex("dbo.tokens", new[] { "userid" });
            DropIndex("dbo.Recipes", new[] { "Restaurant_id" });
            DropIndex("dbo.Restaurants", new[] { "id" });
            DropIndex("dbo.Logistics", new[] { "id" });
            DropIndex("dbo.OrderLocations", new[] { "DeliveryMan_id" });
            DropIndex("dbo.DeliveryMen", new[] { "id" });
            DropIndex("dbo.Customers", new[] { "id" });
            DropIndex("dbo.Admins", new[] { "id" });
            DropPrimaryKey("dbo.Logistics");
            AlterColumn("dbo.Logistics", "id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.OrderLocations", "DeliveryMan_id");
            DropColumn("dbo.Recipes", "Restaurant_id");
            DropTable("dbo.tokens");
            DropTable("dbo.Restaurants");
            DropTable("dbo.DeliveryMen");
            DropTable("dbo.Customers");
            DropTable("dbo.users");
            DropTable("dbo.Admins");
            AddPrimaryKey("dbo.Logistics", "Id");
        }
    }
}
