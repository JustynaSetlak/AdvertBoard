namespace AdvertBoard.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                        OwnerId = c.String(maxLength: 128),
                        AdvertId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.AdvertId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId)
                .Index(t => t.AdvertId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "AdvertId", "dbo.Adverts");
            DropIndex("dbo.Comments", new[] { "AdvertId" });
            DropIndex("dbo.Comments", new[] { "OwnerId" });
            DropTable("dbo.Comments");
        }
    }
}
