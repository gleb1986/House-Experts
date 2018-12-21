namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverridingCustomerconventions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "IsAcive", c => c.Boolean());
            AlterColumn("dbo.Customers", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Customers", "DateModified", c => c.DateTime());
            DropColumn("dbo.Customers", "CustomerTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "IsAcive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
