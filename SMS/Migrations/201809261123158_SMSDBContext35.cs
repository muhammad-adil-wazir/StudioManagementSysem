namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext35 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "EnquiryTypeID", "dbo.EnquiryTypes");
            DropIndex("dbo.Projects", new[] { "EnquiryTypeID" });
            AddColumn("dbo.Enquiries", "FunctionTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "FunctionTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "FunctionTypeID");
            AddForeignKey("dbo.Projects", "FunctionTypeID", "dbo.FunctionTypes", "FunctionTypeID", cascadeDelete: true);
            DropColumn("dbo.Projects", "EnquiryTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "EnquiryTypeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Projects", "FunctionTypeID", "dbo.FunctionTypes");
            DropIndex("dbo.Projects", new[] { "FunctionTypeID" });
            DropColumn("dbo.Projects", "FunctionTypeID");
            DropColumn("dbo.Enquiries", "FunctionTypeID");
            CreateIndex("dbo.Projects", "EnquiryTypeID");
            AddForeignKey("dbo.Projects", "EnquiryTypeID", "dbo.EnquiryTypes", "EnquiryTypeID", cascadeDelete: true);
        }
    }
}
