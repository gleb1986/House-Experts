namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingCustomerIsActiveNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IsAcive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IsAcive", c => c.Boolean(nullable: false));
        }
    }
}
