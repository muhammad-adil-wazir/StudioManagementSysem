namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enquiries", "Venue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enquiries", "Venue");
        }
    }
}
