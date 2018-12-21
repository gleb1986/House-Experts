namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingCustomerIsActiveNotNullableToTryToAvoidError : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IsAcive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IsAcive", c => c.Boolean());
        }
    }
}
