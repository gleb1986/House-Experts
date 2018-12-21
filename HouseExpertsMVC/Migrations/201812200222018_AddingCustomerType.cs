namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCustomerType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Customers", "CustomerTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CustomerType_ID", c => c.Byte());
            CreateIndex("dbo.Customers", "CustomerType_ID");
            AddForeignKey("dbo.Customers", "CustomerType_ID", "dbo.CustomerTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerType_ID", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerType_ID" });
            DropColumn("dbo.Customers", "CustomerType_ID");
            DropColumn("dbo.Customers", "CustomerTypeID");
            DropTable("dbo.CustomerTypes");
        }
    }
}
