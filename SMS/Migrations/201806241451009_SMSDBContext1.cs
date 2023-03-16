namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devices", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Enquiries", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.EnquiryStatus", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.EnquiryTypes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.FunctionTypes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectStatus", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Skills", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "IsDeleted");
            DropColumn("dbo.ProjectStatus", "IsDeleted");
            DropColumn("dbo.Projects", "IsDeleted");
            DropColumn("dbo.Jobs", "IsDeleted");
            DropColumn("dbo.FunctionTypes", "IsDeleted");
            DropColumn("dbo.EnquiryTypes", "IsDeleted");
            DropColumn("dbo.EnquiryStatus", "IsDeleted");
            DropColumn("dbo.Enquiries", "IsDeleted");
            DropColumn("dbo.Employees", "IsDeleted");
            DropColumn("dbo.Devices", "IsDeleted");
            DropColumn("dbo.Customers", "IsDeleted");
        }
    }
}
