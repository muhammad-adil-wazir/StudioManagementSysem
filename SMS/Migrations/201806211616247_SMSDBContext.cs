namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                        MobileNumber = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        DeviceID = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.DeviceID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Designation = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Enquiries",
                c => new
                    {
                        EnquiryID = c.Int(nullable: false, identity: true),
                        EnquiryDate = c.Int(nullable: false),
                        EnquiryTime = c.Int(nullable: false),
                        JobID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        FunctionDate = c.Int(nullable: false),
                        DeviceID = c.Int(nullable: false),
                        FunctionTypeID = c.Int(nullable: false),
                        SkillID = c.Int(nullable: false),
                        EnquiryTypeID = c.Int(nullable: false),
                        Reference = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.EnquiryID);
            
            CreateTable(
                "dbo.EnquiryStatus",
                c => new
                    {
                        EnquiryStatusID = c.Int(nullable: false, identity: true),
                        EnquiryStatusName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.EnquiryStatusID);
            
            CreateTable(
                "dbo.EnquiryTypes",
                c => new
                    {
                        EnquiryTypeID = c.Int(nullable: false, identity: true),
                        EnquiryTypeName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.EnquiryTypeID);
            
            CreateTable(
                "dbo.FunctionTypes",
                c => new
                    {
                        FunctionTypeID = c.Int(nullable: false, identity: true),
                        FunctionTypeName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.FunctionTypeID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.JobID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        EnquiryID = c.Int(nullable: false),
                        ProjectDateTime = c.DateTime(nullable: false),
                        JobID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        HoursRequired = c.Double(nullable: false),
                        ActualCost = c.Double(nullable: false),
                        MaxCost = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        ChargeableAmount = c.Double(nullable: false),
                        NoOfUnits = c.Double(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectStatus",
                c => new
                    {
                        ProjectStatusID = c.Int(nullable: false, identity: true),
                        ProjectStatusName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ProjectStatusID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
            DropTable("dbo.ProjectStatus");
            DropTable("dbo.Projects");
            DropTable("dbo.Jobs");
            DropTable("dbo.FunctionTypes");
            DropTable("dbo.EnquiryTypes");
            DropTable("dbo.EnquiryStatus");
            DropTable("dbo.Enquiries");
            DropTable("dbo.Employees");
            DropTable("dbo.Devices");
            DropTable("dbo.Customers");
        }
    }
}
