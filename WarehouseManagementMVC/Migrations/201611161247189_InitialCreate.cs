namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Double(),
                        Branch_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Branch_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryItems",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Item_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Items", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.CategoryItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.CategoryItems", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryItems", new[] { "Item_Id" });
            DropIndex("dbo.CategoryItems", new[] { "Category_Id" });
            DropIndex("dbo.Items", new[] { "Order_Id" });
            DropIndex("dbo.Items", new[] { "Branch_Id" });
            DropTable("dbo.CategoryItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Branches");
        }
    }
}
