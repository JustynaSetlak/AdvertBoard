namespace AdvertBoard.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatesToAdvert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "DateOfCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Adverts", "DateOfLastModification", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "DateOfLastModification");
            DropColumn("dbo.Adverts", "DateOfCreation");
        }
    }
}
