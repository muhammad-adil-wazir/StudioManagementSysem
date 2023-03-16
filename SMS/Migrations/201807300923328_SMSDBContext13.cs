namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enquiries", "EnquiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "ProjectDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "ProjectTime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Enquiries", "EnquiryDateTime");
            DropColumn("dbo.Enquiries", "EnquiryTime");
            DropColumn("dbo.Projects", "ProjectDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ProjectDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Enquiries", "EnquiryTime", c => c.Int(nullable: false));
            AddColumn("dbo.Enquiries", "EnquiryDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Projects", "ProjectTime");
            DropColumn("dbo.Projects", "ProjectDate");
            DropColumn("dbo.Enquiries", "EnquiryDate");
        }
    }
}
