namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingCustomerTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CustomerType(ID, Name) VALUES(1, 'Residential')");
            Sql("INSERT INTO CustomerType(ID, Name) VALUES(2, 'Comercial')");
        }

        public override void Down()
        {
        }
    }
}
