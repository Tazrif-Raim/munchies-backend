namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class str_pk_chat : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ChatUsers");
            AddColumn("dbo.ChatUsers", "serial", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ChatUsers", "serial");
            DropColumn("dbo.ChatUsers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChatUsers", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ChatUsers");
            DropColumn("dbo.ChatUsers", "serial");
            AddPrimaryKey("dbo.ChatUsers", "Id");
        }
    }
}
