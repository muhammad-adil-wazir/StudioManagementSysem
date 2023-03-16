namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enquiries", "EnquiryTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enquiries", "EnquiryTime");
        }
    }
}
