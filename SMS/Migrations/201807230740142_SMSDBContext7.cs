namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "ParentCompanyID", c => c.Int());
            AddColumn("dbo.Companies", "LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "ParentCompanyID");
            CreateIndex("dbo.Companies", "LocationID");
            AddForeignKey("dbo.Companies", "ParentCompanyID", "dbo.Companies", "CompanyID");
            AddForeignKey("dbo.Companies", "LocationID", "dbo.Locations", "LocationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Companies", "ParentCompanyID", "dbo.Companies");
            DropIndex("dbo.Companies", new[] { "LocationID" });
            DropIndex("dbo.Companies", new[] { "ParentCompanyID" });
            DropColumn("dbo.Companies", "LocationID");
            DropColumn("dbo.Companies", "ParentCompanyID");
        }
    }
}
