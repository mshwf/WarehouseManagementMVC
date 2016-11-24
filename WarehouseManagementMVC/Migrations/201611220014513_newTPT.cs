namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTPT : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WItems", newName: "BItems");
            DropForeignKey("dbo.WItemCategories", "WItem_Id", "dbo.WItems");
            DropForeignKey("dbo.Orders", "BItem_Id", "dbo.WItems");
            DropIndex("dbo.BItems", new[] { "Order_Id" });
            DropIndex("dbo.BItems", new[] { "Warehouse_Id" });
            DropPrimaryKey("dbo.BItems");
            CreateTable(
                "dbo.WItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_Id = c.Int(),
                        Warehouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Warehouse_Id);
            
            AlterColumn("dbo.BItems", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.BItems", "DiscountPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.BItems", "Id");
            CreateIndex("dbo.BItems", "Id");
            AddForeignKey("dbo.BItems", "Id", "dbo.WItems", "Id");
            AddForeignKey("dbo.Orders", "BItem_Id", "dbo.BItems", "Id");
            DropColumn("dbo.BItems", "Name");
            DropColumn("dbo.BItems", "Quantity");
            DropColumn("dbo.BItems", "Price");
            DropColumn("dbo.BItems", "Discriminator");
            DropColumn("dbo.BItems", "Order_Id");
            DropColumn("dbo.BItems", "Warehouse_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BItems", "Warehouse_Id", c => c.Int());
            AddColumn("dbo.BItems", "Order_Id", c => c.Int());
            AddColumn("dbo.BItems", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.BItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BItems", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.BItems", "Name", c => c.String());
            DropForeignKey("dbo.Orders", "BItem_Id", "dbo.BItems");
            DropForeignKey("dbo.BItems", "Id", "dbo.WItems");
            DropIndex("dbo.BItems", new[] { "Id" });
            DropIndex("dbo.WItems", new[] { "Warehouse_Id" });
            DropIndex("dbo.WItems", new[] { "Order_Id" });
            DropPrimaryKey("dbo.BItems");
            AlterColumn("dbo.BItems", "DiscountPercentage", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.BItems", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.WItems");
            AddPrimaryKey("dbo.BItems", "Id");
            CreateIndex("dbo.BItems", "Warehouse_Id");
            CreateIndex("dbo.BItems", "Order_Id");
            AddForeignKey("dbo.Orders", "BItem_Id", "dbo.WItems", "Id");
            AddForeignKey("dbo.WItemCategories", "WItem_Id", "dbo.WItems", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.BItems", newName: "WItems");
        }
    }
}
