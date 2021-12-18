namespace CRUD_Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String());
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime());
        }
    }
}
