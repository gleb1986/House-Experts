namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEmployeeTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EmployeeTypes (ID, Name) VALUES(1, 'Partal Time')");
            Sql("INSERT INTO EmployeeTypes (ID, Name) VALUES(2, 'Full Time')");
            Sql("INSERT INTO EmployeeTypes (ID, Name) VALUES(3, 'Subcontractor')");
        }
        
        public override void Down()
        {
        }
    }
}
