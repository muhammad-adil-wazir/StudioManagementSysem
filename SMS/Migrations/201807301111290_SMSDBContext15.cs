namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enquiries", "DeviceID", "dbo.Devices");
            DropForeignKey("dbo.Enquiries", "FunctionTypeID", "dbo.FunctionTypes");
            DropForeignKey("dbo.Enquiries", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.Enquiries", "SkillID", "dbo.Skills");
            DropIndex("dbo.Enquiries", new[] { "JobID" });
            DropIndex("dbo.Enquiries", new[] { "DeviceID" });
            DropIndex("dbo.Enquiries", new[] { "FunctionTypeID" });
            DropIndex("dbo.Enquiries", new[] { "SkillID" });
            DropColumn("dbo.Enquiries", "JobID");
            DropColumn("dbo.Enquiries", "DeviceID");
            DropColumn("dbo.Enquiries", "FunctionTypeID");
            DropColumn("dbo.Enquiries", "SkillID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enquiries", "SkillID", c => c.Int(nullable: false));
            AddColumn("dbo.Enquiries", "FunctionTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Enquiries", "DeviceID", c => c.Int(nullable: false));
            AddColumn("dbo.Enquiries", "JobID", c => c.Int(nullable: false));
            CreateIndex("dbo.Enquiries", "SkillID");
            CreateIndex("dbo.Enquiries", "FunctionTypeID");
            CreateIndex("dbo.Enquiries", "DeviceID");
            CreateIndex("dbo.Enquiries", "JobID");
            AddForeignKey("dbo.Enquiries", "SkillID", "dbo.Skills", "SkillID", cascadeDelete: true);
            AddForeignKey("dbo.Enquiries", "JobID", "dbo.Jobs", "JobID", cascadeDelete: true);
            AddForeignKey("dbo.Enquiries", "FunctionTypeID", "dbo.FunctionTypes", "FunctionTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Enquiries", "DeviceID", "dbo.Devices", "DeviceID", cascadeDelete: true);
        }
    }
}
