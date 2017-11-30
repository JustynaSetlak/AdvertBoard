namespace AdvertBoard.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFlagOfAdvert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "IsDeleted");
        }
    }
}
