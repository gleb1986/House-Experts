namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmployeeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsAcive = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
