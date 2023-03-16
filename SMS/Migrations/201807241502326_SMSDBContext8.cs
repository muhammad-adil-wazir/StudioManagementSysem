namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext8 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Interfaces", "ParentInterfaceID");
            AddForeignKey("dbo.Interfaces", "ParentInterfaceID", "dbo.Interfaces", "InterfaceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interfaces", "ParentInterfaceID", "dbo.Interfaces");
            DropIndex("dbo.Interfaces", new[] { "ParentInterfaceID" });
        }
    }
}
