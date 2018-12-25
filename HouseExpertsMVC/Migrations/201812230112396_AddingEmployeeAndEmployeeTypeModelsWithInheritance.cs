namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmployeeAndEmployeeTypeModelsWithInheritance : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeeTypes", t => t.EmployeeTypeID, cascadeDelete: true)
                .Index(t => t.EmployeeTypeID);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeTypeID" });
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
        }
    }
}
