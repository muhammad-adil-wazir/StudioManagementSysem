namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquiryEmpDetails", "FromDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EnquiryEmpDetails", "ToDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnquiryEmpDetails", "ToDate");
            DropColumn("dbo.EnquiryEmpDetails", "FromDate");
        }
    }
}
