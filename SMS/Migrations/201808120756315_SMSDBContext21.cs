namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquiryDeviceDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectEmpDetails", "FromDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectEmpDetails", "ToDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectEmpDetails", "ToDate");
            DropColumn("dbo.ProjectEmpDetails", "FromDate");
            DropColumn("dbo.EnquiryDeviceDetails", "Quantity");
        }
    }
}
