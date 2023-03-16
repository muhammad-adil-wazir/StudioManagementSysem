namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Customers", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.Devices", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Devices", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.Employees", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Employees", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.Enquiries", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Enquiries", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.EnquiryDeviceDetails", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.EnquiryDeviceDetails", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.EnquiryEmpDetails", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.EnquiryEmpDetails", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.EnquiryJobDetails", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.EnquiryJobDetails", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.EnquiryStatus", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.EnquiryStatus", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.EnquiryStatusDetails", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.EnquiryStatusDetails", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.EnquiryTypes", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.EnquiryTypes", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.EventAccesses", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.EventAccesses", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.FunctionTypes", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.FunctionTypes", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.Interfaces", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Interfaces", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.Jobs", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Jobs", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.Projects", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Projects", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.ProjectStatus", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.ProjectStatus", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.RoleAccesses", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.RoleAccesses", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.Roles", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Roles", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.Skills", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Skills", "updatedByDate", c => c.DateTime());
            AlterColumn("dbo.Users", "UpdatedByID", c => c.Int());
            AlterColumn("dbo.Users", "updatedByDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.Skills", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Skills", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.Roles", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.RoleAccesses", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RoleAccesses", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProjectStatus", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectStatus", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.Interfaces", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Interfaces", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.FunctionTypes", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FunctionTypes", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventAccesses", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EventAccesses", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.EnquiryTypes", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EnquiryTypes", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.EnquiryStatusDetails", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EnquiryStatusDetails", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.EnquiryStatus", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EnquiryStatus", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.EnquiryJobDetails", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EnquiryJobDetails", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.EnquiryEmpDetails", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EnquiryEmpDetails", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.EnquiryDeviceDetails", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EnquiryDeviceDetails", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.Enquiries", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Enquiries", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.Devices", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Devices", "UpdatedByID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "updatedByDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "UpdatedByID", c => c.Int(nullable: false));
        }
    }
}
