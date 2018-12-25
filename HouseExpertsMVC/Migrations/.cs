namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingEmployeeTypesTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EmployeeTypes (Name) VALUES('Part Time')");
            Sql("INSERT INTO EmployeeTypes (Name) VALUES('Full Time')");
            Sql("INSERT INTO EmployeeTypes (Name) VALUES('Subcontractor')");
        }
        
        public override void Down()
        {
        }
    }
}
