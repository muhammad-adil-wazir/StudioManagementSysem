namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Display", c => c.String());
            AddColumn("dbo.Devices", "Recorder", c => c.String());
            AddColumn("dbo.Devices", "Media", c => c.String());
            AddColumn("dbo.Devices", "Video", c => c.String());
            AddColumn("dbo.Devices", "Audio", c => c.String());
            AddColumn("dbo.Devices", "Power", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Power");
            DropColumn("dbo.Devices", "Audio");
            DropColumn("dbo.Devices", "Video");
            DropColumn("dbo.Devices", "Media");
            DropColumn("dbo.Devices", "Recorder");
            DropColumn("dbo.Devices", "Display");
        }
    }
}
