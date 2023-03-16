namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Payment1", c => c.Double(nullable: false));
            AddColumn("dbo.Projects", "Payment2", c => c.Double(nullable: false));
            AddColumn("dbo.Projects", "Payment3", c => c.Double(nullable: false));
            AddColumn("dbo.Projects", "Payment4", c => c.Double(nullable: false));
            AddColumn("dbo.Projects", "Balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Balance");
            DropColumn("dbo.Projects", "Payment4");
            DropColumn("dbo.Projects", "Payment3");
            DropColumn("dbo.Projects", "Payment2");
            DropColumn("dbo.Projects", "Payment1");
        }
    }
}
