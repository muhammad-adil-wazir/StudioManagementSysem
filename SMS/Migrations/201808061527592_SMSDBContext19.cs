namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext19 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "NoOfUnits");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "NoOfUnits", c => c.Double(nullable: false));
        }
    }
}
