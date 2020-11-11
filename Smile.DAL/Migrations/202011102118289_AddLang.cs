namespace Smile.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "LanguageId", c => c.Int());
            CreateIndex("dbo.Orders", "LanguageId");
            AddForeignKey("dbo.Orders", "LanguageId", "dbo.Languages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Orders", new[] { "LanguageId" });
            DropColumn("dbo.Orders", "LanguageId");
        }
    }
}
