namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext37 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquiryEmpDetails", "EmployeeName", c => c.String());
            AddColumn("dbo.EnquiryEmpDetails", "CompanyName", c => c.String());
            AddColumn("dbo.ProjectEmpDetails", "EmployeeName", c => c.String());
            AddColumn("dbo.ProjectEmpDetails", "CompanyName", c => c.String());
            DropColumn("dbo.EnquirySkillDetails", "EmployeeName");
            DropColumn("dbo.EnquirySkillDetails", "CompanyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EnquirySkillDetails", "CompanyName", c => c.String());
            AddColumn("dbo.EnquirySkillDetails", "EmployeeName", c => c.String());
            DropColumn("dbo.ProjectEmpDetails", "CompanyName");
            DropColumn("dbo.ProjectEmpDetails", "EmployeeName");
            DropColumn("dbo.EnquiryEmpDetails", "CompanyName");
            DropColumn("dbo.EnquiryEmpDetails", "EmployeeName");
        }
    }
}
