namespace AdvertBoard.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAmountOfSignsInDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adverts", "Details", c => c.String(maxLength: 700));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adverts", "Details", c => c.String(maxLength: 500));
        }
    }
}
