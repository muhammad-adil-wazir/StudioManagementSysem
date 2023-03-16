namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext28 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSkillDetails",
                c => new
                    {
                        EmployeeSkillDetailID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        SkillID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeSkillDetailID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSkillDetails", "SkillID", "dbo.Skills");
            DropForeignKey("dbo.EmployeeSkillDetails", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.EmployeeSkillDetails", new[] { "SkillID" });
            DropIndex("dbo.EmployeeSkillDetails", new[] { "EmployeeID" });
            DropTable("dbo.EmployeeSkillDetails");
        }
    }
}
