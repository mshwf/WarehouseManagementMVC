namespace WarehouseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fxkeys : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WItems", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WItems", "Name", c => c.String(nullable: false));
        }
    }
}
