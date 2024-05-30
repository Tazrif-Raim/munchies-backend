namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_restaurant_recipe_foreign_key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Restaurant_id", "dbo.Restaurants");
            DropIndex("dbo.Recipes", new[] { "Restaurant_id" });
            DropColumn("dbo.Recipes", "Restaurant_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Restaurant_id", c => c.Int());
            CreateIndex("dbo.Recipes", "Restaurant_id");
            AddForeignKey("dbo.Recipes", "Restaurant_id", "dbo.Restaurants", "id");
        }
    }
}
