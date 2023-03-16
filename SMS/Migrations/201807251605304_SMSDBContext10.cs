namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext10 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Enquiries", "EnquiryStatusID");
            CreateIndex("dbo.Enquiries", "JobID");
            CreateIndex("dbo.Enquiries", "CustomerID");
            CreateIndex("dbo.Enquiries", "DeviceID");
            CreateIndex("dbo.Enquiries", "FunctionTypeID");
            CreateIndex("dbo.Enquiries", "SkillID");
            CreateIndex("dbo.Enquiries", "EnquiryTypeID");
            CreateIndex("dbo.Projects", "JobID");
            CreateIndex("dbo.Projects", "EmployeeID");
            AddForeignKey("dbo.Enquiries", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Enquiries", "DeviceID", "dbo.Devices", "DeviceID", cascadeDelete: true);
            AddForeignKey("dbo.Enquiries", "EnquiryStatusID", "dbo.EnquiryStatus", "EnquiryStatusID", cascadeDelete: true);
            AddForeignKey("dbo.Enquiries", "EnquiryTypeID", "dbo.EnquiryTypes", "EnquiryTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Enquiries", "FunctionTypeID", "dbo.FunctionTypes", "FunctionTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Enquiries", "JobID", "dbo.Jobs", "JobID", cascadeDelete: true);
            AddForeignKey("dbo.Enquiries", "SkillID", "dbo.Skills", "SkillID", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "JobID", "dbo.Jobs", "JobID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.Projects", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Enquiries", "SkillID", "dbo.Skills");
            DropForeignKey("dbo.Enquiries", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.Enquiries", "FunctionTypeID", "dbo.FunctionTypes");
            DropForeignKey("dbo.Enquiries", "EnquiryTypeID", "dbo.EnquiryTypes");
            DropForeignKey("dbo.Enquiries", "EnquiryStatusID", "dbo.EnquiryStatus");
            DropForeignKey("dbo.Enquiries", "DeviceID", "dbo.Devices");
            DropForeignKey("dbo.Enquiries", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Projects", new[] { "EmployeeID" });
            DropIndex("dbo.Projects", new[] { "JobID" });
            DropIndex("dbo.Enquiries", new[] { "EnquiryTypeID" });
            DropIndex("dbo.Enquiries", new[] { "SkillID" });
            DropIndex("dbo.Enquiries", new[] { "FunctionTypeID" });
            DropIndex("dbo.Enquiries", new[] { "DeviceID" });
            DropIndex("dbo.Enquiries", new[] { "CustomerID" });
            DropIndex("dbo.Enquiries", new[] { "JobID" });
            DropIndex("dbo.Enquiries", new[] { "EnquiryStatusID" });
        }
    }
}
