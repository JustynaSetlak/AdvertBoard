namespace AdvertBoard.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false, maxLength: 200));
            AddPrimaryKey("dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "Content", c => c.String());
            AlterColumn("dbo.Comments", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Comments", "Id");
        }
    }
}
