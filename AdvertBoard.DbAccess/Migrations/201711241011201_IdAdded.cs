namespace AdvertBoard.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adverts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Adverts", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Adverts", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Adverts", name: "Owner_Id", newName: "OwnerId");
            RenameIndex(table: "dbo.Adverts", name: "IX_Owner_Id", newName: "IX_OwnerId");
            AlterColumn("dbo.Adverts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Adverts", "CategoryId");
            AddForeignKey("dbo.Adverts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adverts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Adverts", new[] { "CategoryId" });
            AlterColumn("dbo.Adverts", "CategoryId", c => c.Int());
            RenameIndex(table: "dbo.Adverts", name: "IX_OwnerId", newName: "IX_Owner_Id");
            RenameColumn(table: "dbo.Adverts", name: "OwnerId", newName: "Owner_Id");
            RenameColumn(table: "dbo.Adverts", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Adverts", "Category_Id");
            AddForeignKey("dbo.Adverts", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
