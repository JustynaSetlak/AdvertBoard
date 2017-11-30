namespace AdvertBoard.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfCommentCreationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "DateOfCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adverts", "Details", c => c.String(maxLength: 1200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adverts", "Details", c => c.String(maxLength: 700));
            DropColumn("dbo.Comments", "DateOfCreation");
        }
    }
}
