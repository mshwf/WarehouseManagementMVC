namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BItemAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Items", newName: "WItems");
            RenameTable(name: "dbo.CategoryItems", newName: "CategoryWItems");
            RenameTable(name: "dbo.OrderItems", newName: "OrderWItems");
            RenameColumn(table: "dbo.CategoryWItems", name: "Item_Id", newName: "WItem_Id");
            RenameColumn(table: "dbo.OrderWItems", name: "Item_Id", newName: "WItem_Id");
            RenameIndex(table: "dbo.CategoryWItems", name: "IX_Item_Id", newName: "IX_WItem_Id");
            RenameIndex(table: "dbo.OrderWItems", name: "IX_Item_Id", newName: "IX_WItem_Id");
            AddColumn("dbo.WItems", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WItems", "Discriminator");
            RenameIndex(table: "dbo.OrderWItems", name: "IX_WItem_Id", newName: "IX_Item_Id");
            RenameIndex(table: "dbo.CategoryWItems", name: "IX_WItem_Id", newName: "IX_Item_Id");
            RenameColumn(table: "dbo.OrderWItems", name: "WItem_Id", newName: "Item_Id");
            RenameColumn(table: "dbo.CategoryWItems", name: "WItem_Id", newName: "Item_Id");
            RenameTable(name: "dbo.OrderWItems", newName: "OrderItems");
            RenameTable(name: "dbo.CategoryWItems", newName: "CategoryItems");
            RenameTable(name: "dbo.WItems", newName: "Items");
        }
    }
}
