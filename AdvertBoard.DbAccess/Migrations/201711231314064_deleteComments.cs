namespace AdvertBoard.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteComments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Advert_Id", "dbo.Adverts");
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.Comments", new[] { "Advert_Id" });
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.Int(nullable: false),
                        DateOfCreating = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Advert_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Comments", "Advert_Id");
            CreateIndex("dbo.Comments", "Author_Id");
            AddForeignKey("dbo.Comments", "Advert_Id", "dbo.Adverts", "Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
