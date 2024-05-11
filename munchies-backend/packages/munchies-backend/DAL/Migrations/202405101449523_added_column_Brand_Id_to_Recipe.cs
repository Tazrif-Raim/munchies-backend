namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_column_Brand_Id_to_Recipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Recipes", new[] { "Brand_Id" });
            AddColumn("dbo.Recipes", "Brand_Id1", c => c.Guid());
            CreateIndex("dbo.Recipes", "Brand_Id1");
            AddForeignKey("dbo.Recipes", "Brand_Id1", "dbo.Brands", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Brand_Id1", "dbo.Brands");
            DropIndex("dbo.Recipes", new[] { "Brand_Id1" });
            DropColumn("dbo.Recipes", "Brand_Id1");
            CreateIndex("dbo.Recipes", "Brand_Id");
            AddForeignKey("dbo.Recipes", "Brand_Id", "dbo.Brands", "Id");
        }
    }
}
