namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquiryEmpDetails", "SkillID", c => c.Int(nullable: false));
            CreateIndex("dbo.EnquiryEmpDetails", "SkillID");
            AddForeignKey("dbo.EnquiryEmpDetails", "SkillID", "dbo.Skills", "SkillID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnquiryEmpDetails", "SkillID", "dbo.Skills");
            DropIndex("dbo.EnquiryEmpDetails", new[] { "SkillID" });
            DropColumn("dbo.EnquiryEmpDetails", "SkillID");
        }
    }
}
