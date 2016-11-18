namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class omitItemBranch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BranchItems", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.BranchItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "BranchItem_Id", "dbo.BranchItems");
            DropIndex("dbo.BranchItems", new[] { "ItemId" });
            DropIndex("dbo.BranchItems", new[] { "BranchId" });
            DropIndex("dbo.Items", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "BranchItem_Id" });
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Item_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Item_Id);
            
            AddColumn("dbo.Items", "DiscountPercentage", c => c.Double());
            AddColumn("dbo.Items", "Branch_Id", c => c.Int());
            CreateIndex("dbo.Items", "Branch_Id");
            AddForeignKey("dbo.Items", "Branch_Id", "dbo.Branches", "Id");
            DropColumn("dbo.Items", "Order_Id");
            DropColumn("dbo.Orders", "BranchItem_Id");
            DropTable("dbo.BranchItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BranchItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        DiscountPercentage = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "BranchItem_Id", c => c.Int());
            AddColumn("dbo.Items", "Order_Id", c => c.Int());
            DropForeignKey("dbo.Items", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.OrderItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Item_Id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.Items", new[] { "Branch_Id" });
            DropColumn("dbo.Items", "Branch_Id");
            DropColumn("dbo.Items", "DiscountPercentage");
            DropTable("dbo.OrderItems");
            CreateIndex("dbo.Orders", "BranchItem_Id");
            CreateIndex("dbo.Items", "Order_Id");
            CreateIndex("dbo.BranchItems", "BranchId");
            CreateIndex("dbo.BranchItems", "ItemId");
            AddForeignKey("dbo.Orders", "BranchItem_Id", "dbo.BranchItems", "Id");
            AddForeignKey("dbo.Items", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.BranchItems", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BranchItems", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
    }
}
