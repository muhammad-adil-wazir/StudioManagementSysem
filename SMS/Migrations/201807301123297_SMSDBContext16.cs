namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext16 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EnquiryDeviceDetails", "CreatedByID");
            DropColumn("dbo.EnquiryDeviceDetails", "CreatedByDate");
            DropColumn("dbo.EnquiryDeviceDetails", "UpdatedByID");
            DropColumn("dbo.EnquiryDeviceDetails", "updatedByDate");
            DropColumn("dbo.EnquiryDeviceDetails", "Remarks");
            DropColumn("dbo.EnquiryEmpDetails", "CreatedByID");
            DropColumn("dbo.EnquiryEmpDetails", "CreatedByDate");
            DropColumn("dbo.EnquiryEmpDetails", "UpdatedByID");
            DropColumn("dbo.EnquiryEmpDetails", "updatedByDate");
            DropColumn("dbo.EnquiryEmpDetails", "Remarks");
            DropColumn("dbo.EnquiryFunctionTypeDetails", "CreatedByID");
            DropColumn("dbo.EnquiryFunctionTypeDetails", "CreatedByDate");
            DropColumn("dbo.EnquiryFunctionTypeDetails", "UpdatedByID");
            DropColumn("dbo.EnquiryFunctionTypeDetails", "updatedByDate");
            DropColumn("dbo.EnquiryFunctionTypeDetails", "Remarks");
            DropColumn("dbo.EnquiryJobDetails", "CreatedByID");
            DropColumn("dbo.EnquiryJobDetails", "CreatedByDate");
            DropColumn("dbo.EnquiryJobDetails", "UpdatedByID");
            DropColumn("dbo.EnquiryJobDetails", "updatedByDate");
            DropColumn("dbo.EnquiryJobDetails", "Remarks");
            DropColumn("dbo.EnquirySkillDetails", "CreatedByID");
            DropColumn("dbo.EnquirySkillDetails", "CreatedByDate");
            DropColumn("dbo.EnquirySkillDetails", "UpdatedByID");
            DropColumn("dbo.EnquirySkillDetails", "updatedByDate");
            DropColumn("dbo.EnquirySkillDetails", "Remarks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EnquirySkillDetails", "Remarks", c => c.String());
            AddColumn("dbo.EnquirySkillDetails", "updatedByDate", c => c.DateTime());
            AddColumn("dbo.EnquirySkillDetails", "UpdatedByID", c => c.Int());
            AddColumn("dbo.EnquirySkillDetails", "CreatedByDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EnquirySkillDetails", "CreatedByID", c => c.Int(nullable: false));
            AddColumn("dbo.EnquiryJobDetails", "Remarks", c => c.String());
            AddColumn("dbo.EnquiryJobDetails", "updatedByDate", c => c.DateTime());
            AddColumn("dbo.EnquiryJobDetails", "UpdatedByID", c => c.Int());
            AddColumn("dbo.EnquiryJobDetails", "CreatedByDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EnquiryJobDetails", "CreatedByID", c => c.Int(nullable: false));
            AddColumn("dbo.EnquiryFunctionTypeDetails", "Remarks", c => c.String());
            AddColumn("dbo.EnquiryFunctionTypeDetails", "updatedByDate", c => c.DateTime());
            AddColumn("dbo.EnquiryFunctionTypeDetails", "UpdatedByID", c => c.Int());
            AddColumn("dbo.EnquiryFunctionTypeDetails", "CreatedByDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EnquiryFunctionTypeDetails", "CreatedByID", c => c.Int(nullable: false));
            AddColumn("dbo.EnquiryEmpDetails", "Remarks", c => c.String());
            AddColumn("dbo.EnquiryEmpDetails", "updatedByDate", c => c.DateTime());
            AddColumn("dbo.EnquiryEmpDetails", "UpdatedByID", c => c.Int());
            AddColumn("dbo.EnquiryEmpDetails", "CreatedByDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EnquiryEmpDetails", "CreatedByID", c => c.Int(nullable: false));
            AddColumn("dbo.EnquiryDeviceDetails", "Remarks", c => c.String());
            AddColumn("dbo.EnquiryDeviceDetails", "updatedByDate", c => c.DateTime());
            AddColumn("dbo.EnquiryDeviceDetails", "UpdatedByID", c => c.Int());
            AddColumn("dbo.EnquiryDeviceDetails", "CreatedByDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EnquiryDeviceDetails", "CreatedByID", c => c.Int(nullable: false));
        }
    }
}
