namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnquiryEmpDetails", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.ProjectEmpDetails", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.EnquiryEmpDetails", new[] { "EmployeeID" });
            DropIndex("dbo.ProjectEmpDetails", new[] { "EmployeeID" });
            AlterColumn("dbo.EnquiryEmpDetails", "EmployeeID", c => c.Int());
            AlterColumn("dbo.ProjectEmpDetails", "EmployeeID", c => c.Int());
            CreateIndex("dbo.EnquiryEmpDetails", "EmployeeID");
            CreateIndex("dbo.ProjectEmpDetails", "EmployeeID");
            AddForeignKey("dbo.EnquiryEmpDetails", "EmployeeID", "dbo.Employees", "EmployeeID");
            AddForeignKey("dbo.ProjectEmpDetails", "EmployeeID", "dbo.Employees", "EmployeeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectEmpDetails", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.EnquiryEmpDetails", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.ProjectEmpDetails", new[] { "EmployeeID" });
            DropIndex("dbo.EnquiryEmpDetails", new[] { "EmployeeID" });
            AlterColumn("dbo.ProjectEmpDetails", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.EnquiryEmpDetails", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectEmpDetails", "EmployeeID");
            CreateIndex("dbo.EnquiryEmpDetails", "EmployeeID");
            AddForeignKey("dbo.ProjectEmpDetails", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
            AddForeignKey("dbo.EnquiryEmpDetails", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
        }
    }
}
