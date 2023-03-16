namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "EnquiryTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "EnquiryTypeID");
            AddForeignKey("dbo.Projects", "EnquiryTypeID", "dbo.EnquiryTypes", "EnquiryTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "EnquiryTypeID", "dbo.EnquiryTypes");
            DropIndex("dbo.Projects", new[] { "EnquiryTypeID" });
            DropColumn("dbo.Projects", "EnquiryTypeID");
        }
    }
}
