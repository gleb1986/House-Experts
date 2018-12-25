namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RemovingEmployeeType_IDColomn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EmployeeType_ID", "dbo.EmployeeTypes");
            //DropColumn("dbo.Employees", "EmployeeType_ID");
        }

        public override void Down()
        {
            AddForeignKey("dbo.Employees", "EmployeeType_ID", "dbo.EmployeeTypes");
            //AddColumn("dbo.Employees", "EmployeeType_ID", c => c.Byte(nullable: false));
        }
    }
}
