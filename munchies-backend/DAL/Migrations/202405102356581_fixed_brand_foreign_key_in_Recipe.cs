namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixed_brand_foreign_key_in_Recipe : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Recipes", "Brand_Id");
            RenameColumn(table: "dbo.Recipes", name: "Brand_Id1", newName: "Brand_Id");
            RenameIndex(table: "dbo.Recipes", name: "IX_Brand_Id1", newName: "IX_Brand_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Recipes", name: "IX_Brand_Id", newName: "IX_Brand_Id1");
            RenameColumn(table: "dbo.Recipes", name: "Brand_Id", newName: "Brand_Id1");
            AddColumn("dbo.Recipes", "Brand_Id", c => c.Guid());
        }
    }
}
