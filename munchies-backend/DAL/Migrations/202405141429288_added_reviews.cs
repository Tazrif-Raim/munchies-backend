namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_reviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.String(nullable: false, maxLength: 50),
                        Comment = c.String(nullable: false, maxLength: 50),
                        Rating = c.Int(nullable: false),
                        ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Reviews", new[] { "ProfileId" });
            DropTable("dbo.Reviews");
        }
    }
}
