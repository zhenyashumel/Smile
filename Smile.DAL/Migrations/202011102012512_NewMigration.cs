namespace Smile.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsMale = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsMale = c.Boolean(nullable: false),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lang = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Raiting = c.Single(nullable: false),
                        CharacterId = c.Int(),
                        InProgress = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Weekends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LanguageEmployees",
                c => new
                    {
                        Language_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language_Id, t.Employee_Id })
                .ForeignKey("dbo.Languages", t => t.Language_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Language_Id)
                .Index(t => t.Employee_Id);
            
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
            
            CreateTable(
                "dbo.WeekendEmployees",
                c => new
                    {
                        Weekend_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Weekend_Id, t.Employee_Id })
                .ForeignKey("dbo.Weekends", t => t.Weekend_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Weekend_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeekendEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.WeekendEmployees", "Weekend_Id", "dbo.Weekends");
            DropForeignKey("dbo.OrderEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.OrderEmployees", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.LanguageEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.LanguageEmployees", "Language_Id", "dbo.Languages");
            DropIndex("dbo.WeekendEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.WeekendEmployees", new[] { "Weekend_Id" });
            DropIndex("dbo.OrderEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.OrderEmployees", new[] { "Order_Id" });
            DropIndex("dbo.LanguageEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.LanguageEmployees", new[] { "Language_Id" });
            DropIndex("dbo.Orders", new[] { "CharacterId" });
            DropTable("dbo.WeekendEmployees");
            DropTable("dbo.OrderEmployees");
            DropTable("dbo.LanguageEmployees");
            DropTable("dbo.Weekends");
            DropTable("dbo.Orders");
            DropTable("dbo.Languages");
            DropTable("dbo.Employees");
            DropTable("dbo.Characters");
        }
    }
}
