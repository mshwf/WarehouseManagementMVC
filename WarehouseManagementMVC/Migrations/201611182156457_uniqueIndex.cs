namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.WItems", "Name", unique: true, name: "IX_FirstNameLastName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.WItems", "IX_FirstNameLastName");
        }
    }
}
