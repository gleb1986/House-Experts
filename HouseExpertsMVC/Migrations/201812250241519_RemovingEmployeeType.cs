namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingEmployeeType : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "EmployeeTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeeTypeID", c => c.Byte(nullable: false));
        }
    }
}
