namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wrhsMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Branches", "Warehouse_Id", c => c.Int());
            AddColumn("dbo.Items", "Warehouse_Id", c => c.Int());
            CreateIndex("dbo.Branches", "Warehouse_Id");
            CreateIndex("dbo.Items", "Warehouse_Id");
            AddForeignKey("dbo.Branches", "Warehouse_Id", "dbo.Warehouses", "Id");
            AddForeignKey("dbo.Items", "Warehouse_Id", "dbo.Warehouses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.Branches", "Warehouse_Id", "dbo.Warehouses");
            DropIndex("dbo.Items", new[] { "Warehouse_Id" });
            DropIndex("dbo.Branches", new[] { "Warehouse_Id" });
            DropColumn("dbo.Items", "Warehouse_Id");
            DropColumn("dbo.Branches", "Warehouse_Id");
            DropTable("dbo.Warehouses");
        }
    }
}
