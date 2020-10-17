namespace Smile.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Raiting = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderEmployees",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Employee_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Employee_Id);
            
            AddColumn("dbo.Employees", "Contact", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.OrderEmployees", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.OrderEmployees", new[] { "Order_Id" });
            DropColumn("dbo.Employees", "Contact");
            DropTable("dbo.OrderEmployees");
            DropTable("dbo.Orders");
        }
    }
}
