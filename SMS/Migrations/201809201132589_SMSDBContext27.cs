namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquiryDeviceDetails", "HiredCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EnquiryDeviceDetails", "IsHired", c => c.Boolean(nullable: false));
            AddColumn("dbo.EnquiryEmpDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.EnquiryEmpDetails", "HiredCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EnquiryEmpDetails", "IsHired", c => c.Boolean(nullable: false));
            AddColumn("dbo.EnquirySkillDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.EnquirySkillDetails", "HiredCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EnquirySkillDetails", "IsHired", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectEmpDetails", "IsHired", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectEmpDetails", "HiredCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProjectEmpDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectJobDetails", "IsHired", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectJobDetails", "HiredCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProjectJobDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectSkillDetails", "IsHired", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectSkillDetails", "FromDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectSkillDetails", "ToDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectSkillDetails", "HiredCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProjectSkillDetails", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Devices", "IsHired");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "IsHired", c => c.Boolean(nullable: false));
            DropColumn("dbo.ProjectSkillDetails", "Quantity");
            DropColumn("dbo.ProjectSkillDetails", "HiredCost");
            DropColumn("dbo.ProjectSkillDetails", "ToDate");
            DropColumn("dbo.ProjectSkillDetails", "FromDate");
            DropColumn("dbo.ProjectSkillDetails", "IsHired");
            DropColumn("dbo.ProjectJobDetails", "Quantity");
            DropColumn("dbo.ProjectJobDetails", "HiredCost");
            DropColumn("dbo.ProjectJobDetails", "IsHired");
            DropColumn("dbo.ProjectEmpDetails", "Quantity");
            DropColumn("dbo.ProjectEmpDetails", "HiredCost");
            DropColumn("dbo.ProjectEmpDetails", "IsHired");
            DropColumn("dbo.EnquirySkillDetails", "IsHired");
            DropColumn("dbo.EnquirySkillDetails", "HiredCost");
            DropColumn("dbo.EnquirySkillDetails", "Quantity");
            DropColumn("dbo.EnquiryEmpDetails", "IsHired");
            DropColumn("dbo.EnquiryEmpDetails", "HiredCost");
            DropColumn("dbo.EnquiryEmpDetails", "Quantity");
            DropColumn("dbo.EnquiryDeviceDetails", "IsHired");
            DropColumn("dbo.EnquiryDeviceDetails", "HiredCost");
        }
    }
}
