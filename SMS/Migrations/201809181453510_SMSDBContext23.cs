namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "NationalityID", "dbo.Nationalities");
            DropIndex("dbo.Employees", new[] { "NationalityID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Employees", "NationalityID");
            AddForeignKey("dbo.Employees", "NationalityID", "dbo.Nationalities", "NationalityID", cascadeDelete: true);
        }
    }
}
