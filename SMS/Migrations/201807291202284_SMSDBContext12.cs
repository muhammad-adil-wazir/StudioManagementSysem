namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnquiryFunctionTypeDetails",
                c => new
                    {
                        EnquiryFunctionTypeDetailID = c.Int(nullable: false, identity: true),
                        FunctionTypeID = c.Int(nullable: false),
                        EnquiryID = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnquiryFunctionTypeDetailID)
                .ForeignKey("dbo.Enquiries", t => t.EnquiryID, cascadeDelete: false)
                .ForeignKey("dbo.FunctionTypes", t => t.FunctionTypeID, cascadeDelete: false)
                .Index(t => t.FunctionTypeID)
                .Index(t => t.EnquiryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnquiryFunctionTypeDetails", "FunctionTypeID", "dbo.FunctionTypes");
            DropForeignKey("dbo.EnquiryFunctionTypeDetails", "EnquiryID", "dbo.Enquiries");
            DropIndex("dbo.EnquiryFunctionTypeDetails", new[] { "EnquiryID" });
            DropIndex("dbo.EnquiryFunctionTypeDetails", new[] { "FunctionTypeID" });
            DropTable("dbo.EnquiryFunctionTypeDetails");
        }
    }
}
