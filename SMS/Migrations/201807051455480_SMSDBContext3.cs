namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnquiryDeviceDetails",
                c => new
                    {
                        EnquiryDeviceDetailID = c.Int(nullable: false, identity: true),
                        DeviceID = c.Int(nullable: false),
                        EnquiryID = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnquiryDeviceDetailID);
            
            CreateTable(
                "dbo.EnquiryEmpDetails",
                c => new
                    {
                        EnquiryEmpDetailID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        EnquiryID = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnquiryEmpDetailID);
            
            CreateTable(
                "dbo.EnquiryJobDetails",
                c => new
                    {
                        EnquiryJobDetailID = c.Int(nullable: false, identity: true),
                        JobID = c.Int(nullable: false),
                        EnquiryID = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnquiryJobDetailID);
            
            CreateTable(
                "dbo.EnquiryStatusDetails",
                c => new
                    {
                        EnquiryStatusDetailID = c.Int(nullable: false, identity: true),
                        EnquiryStatusID = c.Int(nullable: false),
                        EnquiryID = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnquiryStatusDetailID);
            
            CreateTable(
                "dbo.EventAccesses",
                c => new
                    {
                        EventAccessID = c.Int(nullable: false, identity: true),
                        EventAccessName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventAccessID);
            
            CreateTable(
                "dbo.Interfaces",
                c => new
                    {
                        InterfaceID = c.Int(nullable: false, identity: true),
                        ParentInterfaceID = c.Int(),
                        InterfaceName = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InterfaceID);
            
            CreateTable(
                "dbo.RoleAccesses",
                c => new
                    {
                        RoleAccessID = c.Int(nullable: false, identity: true),
                        InterfaceID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        EventAccessID = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleAccessID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleID = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(nullable: false),
                        updatedByDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.RoleAccesses");
            DropTable("dbo.Interfaces");
            DropTable("dbo.EventAccesses");
            DropTable("dbo.EnquiryStatusDetails");
            DropTable("dbo.EnquiryJobDetails");
            DropTable("dbo.EnquiryEmpDetails");
            DropTable("dbo.EnquiryDeviceDetails");
        }
    }
}
