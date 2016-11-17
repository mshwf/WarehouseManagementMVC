namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newPropBI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemBranches", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemBranches", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "Item_Id", "dbo.Items");
            DropIndex("dbo.ItemBranches", new[] { "Item_Id" });
            DropIndex("dbo.ItemBranches", new[] { "Branch_Id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.OrderItems", new[] { "Item_Id" });
            CreateTable(
                "dbo.BranchItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        DiscountPercentage = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.BranchId);
            
            AddColumn("dbo.Items", "Order_Id", c => c.Int());
            AddColumn("dbo.Orders", "BranchItem_Id", c => c.Int());
            CreateIndex("dbo.Items", "Order_Id");
            CreateIndex("dbo.Orders", "BranchItem_Id");
            AddForeignKey("dbo.Items", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "BranchItem_Id", "dbo.BranchItems", "Id");
            DropColumn("dbo.Items", "DiscountPercentage");
            DropTable("dbo.ItemBranches");
            DropTable("dbo.OrderItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Item_Id });
            
            CreateTable(
                "dbo.ItemBranches",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Branch_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Branch_Id });
            
            AddColumn("dbo.Items", "DiscountPercentage", c => c.Double());
            DropForeignKey("dbo.Orders", "BranchItem_Id", "dbo.BranchItems");
            DropForeignKey("dbo.Items", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.BranchItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.BranchItems", "BranchId", "dbo.Branches");
            DropIndex("dbo.Orders", new[] { "BranchItem_Id" });
            DropIndex("dbo.Items", new[] { "Order_Id" });
            DropIndex("dbo.BranchItems", new[] { "BranchId" });
            DropIndex("dbo.BranchItems", new[] { "ItemId" });
            DropColumn("dbo.Orders", "BranchItem_Id");
            DropColumn("dbo.Items", "Order_Id");
            DropTable("dbo.BranchItems");
            CreateIndex("dbo.OrderItems", "Item_Id");
            CreateIndex("dbo.OrderItems", "Order_Id");
            CreateIndex("dbo.ItemBranches", "Branch_Id");
            CreateIndex("dbo.ItemBranches", "Item_Id");
            AddForeignKey("dbo.OrderItems", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemBranches", "Branch_Id", "dbo.Branches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemBranches", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
        }
    }
}
