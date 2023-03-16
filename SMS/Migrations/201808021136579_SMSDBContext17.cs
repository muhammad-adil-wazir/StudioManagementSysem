namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Projects", "JobID", "dbo.Jobs");
            DropIndex("dbo.Projects", new[] { "JobID" });
            DropIndex("dbo.Projects", new[] { "EmployeeID" });
            CreateTable(
                "dbo.ProjectDeviceDetails",
                c => new
                    {
                        ProjectDeviceDetailID = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeviceID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectDeviceDetailID)
                .ForeignKey("dbo.Devices", t => t.DeviceID, cascadeDelete: false)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: false)
                .Index(t => t.DeviceID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectEmpDetails",
                c => new
                    {
                        ProjectEmpDetailID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectEmpDetailID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: false)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: false)
                .Index(t => t.EmployeeID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectFunctionTypeDetails",
                c => new
                    {
                        ProjectFunctionTypeDetailID = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        FunctionTypeID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectFunctionTypeDetailID)
                .ForeignKey("dbo.FunctionTypes", t => t.FunctionTypeID, cascadeDelete: false)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: false)
                .Index(t => t.FunctionTypeID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectJobDetails",
                c => new
                    {
                        ProjectJobDetailID = c.Int(nullable: false, identity: true),
                        JobID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectJobDetailID)
                .ForeignKey("dbo.Jobs", t => t.JobID, cascadeDelete: false)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: false)
                .Index(t => t.JobID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectSkillDetails",
                c => new
                    {
                        ProjectSkillDetailID = c.Int(nullable: false, identity: true),
                        SkillID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectSkillDetailID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: false)
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: false)
                .Index(t => t.SkillID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectStatusDetails",
                c => new
                    {
                        ProjectStatusDetailID = c.Int(nullable: false, identity: true),
                        ProjectStatusID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectStatusDetailID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: false)
                .ForeignKey("dbo.ProjectStatus", t => t.ProjectStatusID, cascadeDelete: false)
                .Index(t => t.ProjectStatusID)
                .Index(t => t.ProjectID);
            
            AddColumn("dbo.Projects", "ProjectStatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ProjectStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "ProjectEndDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Projects", "EnquiryID");
            CreateIndex("dbo.Projects", "ProjectStatusID");
            AddForeignKey("dbo.Projects", "EnquiryID", "dbo.Enquiries", "EnquiryID", cascadeDelete: false);
            AddForeignKey("dbo.Projects", "ProjectStatusID", "dbo.ProjectStatus", "ProjectStatusID", cascadeDelete: true);
            DropColumn("dbo.EnquiryStatusDetails", "CreatedByID");
            DropColumn("dbo.EnquiryStatusDetails", "CreatedByDate");
            DropColumn("dbo.EnquiryStatusDetails", "UpdatedByID");
            DropColumn("dbo.EnquiryStatusDetails", "updatedByDate");
            DropColumn("dbo.EnquiryStatusDetails", "Remarks");
            DropColumn("dbo.EnquiryStatusDetails", "IsDeleted");
            DropColumn("dbo.Projects", "JobID");
            DropColumn("dbo.Projects", "EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "EmployeeID", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "JobID", c => c.Int(nullable: false));
            AddColumn("dbo.EnquiryStatusDetails", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.EnquiryStatusDetails", "Remarks", c => c.String());
            AddColumn("dbo.EnquiryStatusDetails", "updatedByDate", c => c.DateTime());
            AddColumn("dbo.EnquiryStatusDetails", "UpdatedByID", c => c.Int());
            AddColumn("dbo.EnquiryStatusDetails", "CreatedByDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EnquiryStatusDetails", "CreatedByID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProjectStatusDetails", "ProjectStatusID", "dbo.ProjectStatus");
            DropForeignKey("dbo.ProjectStatusDetails", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectSkillDetails", "SkillID", "dbo.Skills");
            DropForeignKey("dbo.ProjectSkillDetails", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectJobDetails", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectJobDetails", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.ProjectFunctionTypeDetails", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectFunctionTypeDetails", "FunctionTypeID", "dbo.FunctionTypes");
            DropForeignKey("dbo.ProjectEmpDetails", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectEmpDetails", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.ProjectDeviceDetails", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectStatusID", "dbo.ProjectStatus");
            DropForeignKey("dbo.Projects", "EnquiryID", "dbo.Enquiries");
            DropForeignKey("dbo.ProjectDeviceDetails", "DeviceID", "dbo.Devices");
            DropIndex("dbo.ProjectStatusDetails", new[] { "ProjectID" });
            DropIndex("dbo.ProjectStatusDetails", new[] { "ProjectStatusID" });
            DropIndex("dbo.ProjectSkillDetails", new[] { "ProjectID" });
            DropIndex("dbo.ProjectSkillDetails", new[] { "SkillID" });
            DropIndex("dbo.ProjectJobDetails", new[] { "ProjectID" });
            DropIndex("dbo.ProjectJobDetails", new[] { "JobID" });
            DropIndex("dbo.ProjectFunctionTypeDetails", new[] { "ProjectID" });
            DropIndex("dbo.ProjectFunctionTypeDetails", new[] { "FunctionTypeID" });
            DropIndex("dbo.ProjectEmpDetails", new[] { "ProjectID" });
            DropIndex("dbo.ProjectEmpDetails", new[] { "EmployeeID" });
            DropIndex("dbo.Projects", new[] { "ProjectStatusID" });
            DropIndex("dbo.Projects", new[] { "EnquiryID" });
            DropIndex("dbo.ProjectDeviceDetails", new[] { "ProjectID" });
            DropIndex("dbo.ProjectDeviceDetails", new[] { "DeviceID" });
            DropColumn("dbo.Projects", "ProjectEndDate");
            DropColumn("dbo.Projects", "ProjectStartDate");
            DropColumn("dbo.Projects", "ProjectStatusID");
            DropTable("dbo.ProjectStatusDetails");
            DropTable("dbo.ProjectSkillDetails");
            DropTable("dbo.ProjectJobDetails");
            DropTable("dbo.ProjectFunctionTypeDetails");
            DropTable("dbo.ProjectEmpDetails");
            DropTable("dbo.ProjectDeviceDetails");
            CreateIndex("dbo.Projects", "EmployeeID");
            CreateIndex("dbo.Projects", "JobID");
            AddForeignKey("dbo.Projects", "JobID", "dbo.Jobs", "JobID", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
        }
    }
}
