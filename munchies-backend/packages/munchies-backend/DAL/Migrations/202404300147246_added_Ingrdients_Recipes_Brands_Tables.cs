namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_Ingrdients_Recipes_Brands_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        style = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DescriptionRestaurant = c.String(),
                        DescriptionCustomer = c.String(),
                        Category = c.String(),
                        price = c.Int(nullable: false),
                        videoPath = c.String(),
                        Brand_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .Index(t => t.Brand_Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Amount = c.String(),
                        RecipeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            DropIndex("dbo.Recipes", new[] { "Brand_Id" });
            DropTable("dbo.Ingredients");
            DropTable("dbo.Recipes");
            DropTable("dbo.Brands");
        }
    }
}
