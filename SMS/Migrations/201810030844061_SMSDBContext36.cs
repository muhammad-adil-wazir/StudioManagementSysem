namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquirySkillDetails", "EmployeeName", c => c.String());
            AddColumn("dbo.EnquirySkillDetails", "CompanyName", c => c.String());
            AddColumn("dbo.ProjectSkillDetails", "EmployeeName", c => c.String());
            AddColumn("dbo.ProjectSkillDetails", "CompanyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectSkillDetails", "CompanyName");
            DropColumn("dbo.ProjectSkillDetails", "EmployeeName");
            DropColumn("dbo.EnquirySkillDetails", "CompanyName");
            DropColumn("dbo.EnquirySkillDetails", "EmployeeName");
        }
    }
}
