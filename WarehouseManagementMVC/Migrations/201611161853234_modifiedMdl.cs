namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedMdl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.Items", "Warehouse_Id", "dbo.Warehouses");
            DropIndex("dbo.Branches", new[] { "Warehouse_Id" });
            DropIndex("dbo.Items", new[] { "Warehouse_Id" });
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Branches", "Warehouse_Id");
            DropColumn("dbo.Items", "Warehouse_Id");
            DropTable("dbo.Warehouses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Items", "Warehouse_Id", c => c.Int());
            AddColumn("dbo.Branches", "Warehouse_Id", c => c.Int());
            AlterColumn("dbo.Items", "Name", c => c.String());
            CreateIndex("dbo.Items", "Warehouse_Id");
            CreateIndex("dbo.Branches", "Warehouse_Id");
            AddForeignKey("dbo.Items", "Warehouse_Id", "dbo.Warehouses", "Id");
            AddForeignKey("dbo.Branches", "Warehouse_Id", "dbo.Warehouses", "Id");
        }
    }
}
