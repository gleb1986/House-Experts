namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverwritingEmployeeConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeTypeID" });
            AddColumn("dbo.Employees", "EmployeeType_ID", c => c.Int());
            AlterColumn("dbo.Employees", "EmployeeTypeID", c => c.Byte(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.EmployeeTypes", "Name", c => c.String(maxLength: 50));
            CreateIndex("dbo.Employees", "EmployeeType_ID");
            AddForeignKey("dbo.Employees", "EmployeeType_ID", "dbo.EmployeeTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeType_ID", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeType_ID" });
            AlterColumn("dbo.EmployeeTypes", "Name", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeTypeID", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "EmployeeType_ID");
            CreateIndex("dbo.Employees", "EmployeeTypeID");
            AddForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes", "ID", cascadeDelete: true);
        }
    }
}
