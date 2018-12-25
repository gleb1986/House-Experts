namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmployeeTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Employees", "EmployeeTypeID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Employees", "EmployeeTypeID");
            AddForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeTypeID" });
            DropColumn("dbo.Employees", "EmployeeTypeID");
            DropTable("dbo.EmployeeTypes");
        }
    }
}
