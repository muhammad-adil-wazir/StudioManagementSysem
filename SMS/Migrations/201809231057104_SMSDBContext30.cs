namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectEmpDetails", "SkillID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectEmpDetails", "SkillID");
            AddForeignKey("dbo.ProjectEmpDetails", "SkillID", "dbo.Skills", "SkillID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectEmpDetails", "SkillID", "dbo.Skills");
            DropIndex("dbo.ProjectEmpDetails", new[] { "SkillID" });
            DropColumn("dbo.ProjectEmpDetails", "SkillID");
        }
    }
}
