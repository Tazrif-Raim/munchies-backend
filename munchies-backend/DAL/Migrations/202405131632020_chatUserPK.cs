﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chatUserPK : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ChatUsers");
            AlterColumn("dbo.ChatUsers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ChatUsers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ChatUsers");
            AlterColumn("dbo.ChatUsers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ChatUsers", "Id");
        }
    }
}
