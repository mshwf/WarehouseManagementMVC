namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InheritanceImplemented : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoryWItems", newName: "WItemCategories");
            DropPrimaryKey("dbo.WItemCategories");
            AlterColumn("dbo.WItems", "DiscountPercentage", c => c.Decimal(precision: 18, scale: 2));
            AddPrimaryKey("dbo.WItemCategories", new[] { "WItem_Id", "Category_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.WItemCategories");
            AlterColumn("dbo.WItems", "DiscountPercentage", c => c.Double());
            AddPrimaryKey("dbo.WItemCategories", new[] { "Category_Id", "WItem_Id" });
            RenameTable(name: "dbo.WItemCategories", newName: "CategoryWItems");
        }
    }
}
