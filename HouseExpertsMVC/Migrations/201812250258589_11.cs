namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EmployeeType_ID", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeType_ID" });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        IsAcive = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                        EmployeeType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Employees", "EmployeeType_ID");
            AddForeignKey("dbo.Employees", "EmployeeType_ID", "dbo.EmployeeTypes", "ID");
        }
    }
}
