namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverwritingCustomerTypeConventions : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerTypes", newName: "CustomerType");
            AlterColumn("dbo.CustomerType", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerType", "Name", c => c.String());
            RenameTable(name: "dbo.CustomerType", newName: "CustomerTypes");
        }
    }
}
