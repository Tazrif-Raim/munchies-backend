namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_ChatProfile_ServerPass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        secret = c.String(),
                        email = c.String(),
                        first_name = c.String(),
                        last_name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.serverPasses",
                c => new
                    {
                        serverPassword = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.serverPassword);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.serverPasses");
            DropTable("dbo.ChatUsers");
        }
    }
}
