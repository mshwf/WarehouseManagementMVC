namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moveOrdrsProp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderWItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderWItems", "WItem_Id", "dbo.WItems");
            DropIndex("dbo.OrderWItems", new[] { "Order_Id" });
            DropIndex("dbo.OrderWItems", new[] { "WItem_Id" });
            AddColumn("dbo.WItems", "Order_Id", c => c.Int());
            AddColumn("dbo.Orders", "BItem_Id", c => c.Int());
            CreateIndex("dbo.WItems", "Order_Id");
            CreateIndex("dbo.Orders", "BItem_Id");
            AddForeignKey("dbo.WItems", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "BItem_Id", "dbo.WItems", "Id");
            DropTable("dbo.OrderWItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderWItems",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        WItem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.WItem_Id });
            
            DropForeignKey("dbo.Orders", "BItem_Id", "dbo.WItems");
            DropForeignKey("dbo.WItems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "BItem_Id" });
            DropIndex("dbo.WItems", new[] { "Order_Id" });
            DropColumn("dbo.Orders", "BItem_Id");
            DropColumn("dbo.WItems", "Order_Id");
            CreateIndex("dbo.OrderWItems", "WItem_Id");
            CreateIndex("dbo.OrderWItems", "Order_Id");
            AddForeignKey("dbo.OrderWItems", "WItem_Id", "dbo.WItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderWItems", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
