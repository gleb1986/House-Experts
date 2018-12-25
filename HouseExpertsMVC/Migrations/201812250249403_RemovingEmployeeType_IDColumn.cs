namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingEmployeeType_IDColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeTypeID" });
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
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
        }
    }
}
