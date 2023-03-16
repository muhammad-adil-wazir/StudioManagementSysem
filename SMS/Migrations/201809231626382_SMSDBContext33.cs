namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnquiryEmpDetails", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.ProjectEmpDetails", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.EnquiryEmpDetails", new[] { "EmployeeID" });
            DropIndex("dbo.ProjectEmpDetails", new[] { "EmployeeID" });
            AlterColumn("dbo.EnquiryEmpDetails", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProjectEmpDetails", "EmployeeID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectEmpDetails", "EmployeeID", c => c.Int());
            AlterColumn("dbo.EnquiryEmpDetails", "EmployeeID", c => c.Int());
            CreateIndex("dbo.ProjectEmpDetails", "EmployeeID");
            CreateIndex("dbo.EnquiryEmpDetails", "EmployeeID");
            AddForeignKey("dbo.ProjectEmpDetails", "EmployeeID", "dbo.Employees", "EmployeeID");
            AddForeignKey("dbo.EnquiryEmpDetails", "EmployeeID", "dbo.Employees", "EmployeeID");
        }
    }
}
