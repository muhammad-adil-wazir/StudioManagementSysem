namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enquiries", "EnquiryStatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Enquiries", "EnquiryDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Enquiries", "MinCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Enquiries", "MaxCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Enquiries", "ChargeableCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Enquiries", "FunctionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Enquiries", "Reference", c => c.String());
            DropColumn("dbo.Enquiries", "EnquiryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enquiries", "EnquiryDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Enquiries", "Reference", c => c.Int(nullable: false));
            AlterColumn("dbo.Enquiries", "FunctionDate", c => c.Int(nullable: false));
            DropColumn("dbo.Enquiries", "ChargeableCost");
            DropColumn("dbo.Enquiries", "MaxCost");
            DropColumn("dbo.Enquiries", "MinCost");
            DropColumn("dbo.Enquiries", "EnquiryDateTime");
            DropColumn("dbo.Enquiries", "EnquiryStatusID");
        }
    }
}
