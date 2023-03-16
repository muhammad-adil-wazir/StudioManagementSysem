namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext11 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.EnquiryDeviceDetails", "DeviceID");
            CreateIndex("dbo.EnquiryDeviceDetails", "EnquiryID");
            CreateIndex("dbo.EnquiryEmpDetails", "EmployeeID");
            CreateIndex("dbo.EnquiryEmpDetails", "EnquiryID");
            CreateIndex("dbo.EnquiryJobDetails", "JobID");
            CreateIndex("dbo.EnquiryJobDetails", "EnquiryID");
            CreateIndex("dbo.EnquiryStatusDetails", "EnquiryStatusID");
            CreateIndex("dbo.EnquiryStatusDetails", "EnquiryID");
            AddForeignKey("dbo.EnquiryDeviceDetails", "DeviceID", "dbo.Devices", "DeviceID", cascadeDelete: false);
            AddForeignKey("dbo.EnquiryDeviceDetails", "EnquiryID", "dbo.Enquiries", "EnquiryID", cascadeDelete: false);
            AddForeignKey("dbo.EnquiryEmpDetails", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: false);
            AddForeignKey("dbo.EnquiryEmpDetails", "EnquiryID", "dbo.Enquiries", "EnquiryID", cascadeDelete: false);
            AddForeignKey("dbo.EnquiryJobDetails", "EnquiryID", "dbo.Enquiries", "EnquiryID", cascadeDelete: false);
            AddForeignKey("dbo.EnquiryJobDetails", "JobID", "dbo.Jobs", "JobID", cascadeDelete: false);
            AddForeignKey("dbo.EnquiryStatusDetails", "EnquiryID", "dbo.Enquiries", "EnquiryID", cascadeDelete: false);
            AddForeignKey("dbo.EnquiryStatusDetails", "EnquiryStatusID", "dbo.EnquiryStatus", "EnquiryStatusID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnquiryStatusDetails", "EnquiryStatusID", "dbo.EnquiryStatus");
            DropForeignKey("dbo.EnquiryStatusDetails", "EnquiryID", "dbo.Enquiries");
            DropForeignKey("dbo.EnquiryJobDetails", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.EnquiryJobDetails", "EnquiryID", "dbo.Enquiries");
            DropForeignKey("dbo.EnquiryEmpDetails", "EnquiryID", "dbo.Enquiries");
            DropForeignKey("dbo.EnquiryEmpDetails", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.EnquiryDeviceDetails", "EnquiryID", "dbo.Enquiries");
            DropForeignKey("dbo.EnquiryDeviceDetails", "DeviceID", "dbo.Devices");
            DropIndex("dbo.EnquiryStatusDetails", new[] { "EnquiryID" });
            DropIndex("dbo.EnquiryStatusDetails", new[] { "EnquiryStatusID" });
            DropIndex("dbo.EnquiryJobDetails", new[] { "EnquiryID" });
            DropIndex("dbo.EnquiryJobDetails", new[] { "JobID" });
            DropIndex("dbo.EnquiryEmpDetails", new[] { "EnquiryID" });
            DropIndex("dbo.EnquiryEmpDetails", new[] { "EmployeeID" });
            DropIndex("dbo.EnquiryDeviceDetails", new[] { "EnquiryID" });
            DropIndex("dbo.EnquiryDeviceDetails", new[] { "DeviceID" });
        }
    }
}
