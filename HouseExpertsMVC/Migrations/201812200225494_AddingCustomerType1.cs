namespace HouseExpertsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCustomerType1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerType_ID", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerType_ID" });
            DropColumn("dbo.Customers", "CustomerTypeID");
            RenameColumn(table: "dbo.Customers", name: "CustomerType_ID", newName: "CustomerTypeID");
            AlterColumn("dbo.Customers", "CustomerTypeID", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "CustomerTypeID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "CustomerTypeID");
            AddForeignKey("dbo.Customers", "CustomerTypeID", "dbo.CustomerTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerTypeID", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerTypeID" });
            AlterColumn("dbo.Customers", "CustomerTypeID", c => c.Byte());
            AlterColumn("dbo.Customers", "CustomerTypeID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Customers", name: "CustomerTypeID", newName: "CustomerType_ID");
            AddColumn("dbo.Customers", "CustomerTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CustomerType_ID");
            AddForeignKey("dbo.Customers", "CustomerType_ID", "dbo.CustomerTypes", "ID");
        }
    }
}
