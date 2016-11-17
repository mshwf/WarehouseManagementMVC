namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.Items", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Items", new[] { "Branch_Id" });
            DropIndex("dbo.Items", new[] { "Order_Id" });
            CreateTable(
                "dbo.ItemBranches",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Branch_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Branch_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.Branch_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Branch_Id);
            
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
            
            DropColumn("dbo.Items", "Branch_Id");
            DropColumn("dbo.Items", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Order_Id", c => c.Int());
            AddColumn("dbo.Items", "Branch_Id", c => c.Int());
            DropForeignKey("dbo.OrderItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ItemBranches", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.ItemBranches", "Item_Id", "dbo.Items");
            DropIndex("dbo.OrderItems", new[] { "Item_Id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.ItemBranches", new[] { "Branch_Id" });
            DropIndex("dbo.ItemBranches", new[] { "Item_Id" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.ItemBranches");
            CreateIndex("dbo.Items", "Order_Id");
            CreateIndex("dbo.Items", "Branch_Id");
            AddForeignKey("dbo.Items", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Items", "Branch_Id", "dbo.Branches", "Id");
        }
    }
}
