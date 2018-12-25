namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reverse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeTypeID" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeTypeID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsAcive = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Employees", "EmployeeTypeID");
            AddForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes", "ID", cascadeDelete: true);
        }
    }
}
