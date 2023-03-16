namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Devices", "IsHired", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectDeviceDetails", "IsHired", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectDeviceDetails", "FromDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectDeviceDetails", "ToDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectDeviceDetails", "HiredCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProjectDeviceDetails", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectDeviceDetails", "Quantity");
            DropColumn("dbo.ProjectDeviceDetails", "HiredCost");
            DropColumn("dbo.ProjectDeviceDetails", "ToDate");
            DropColumn("dbo.ProjectDeviceDetails", "FromDate");
            DropColumn("dbo.ProjectDeviceDetails", "IsHired");
            DropColumn("dbo.Devices", "IsHired");
            DropColumn("dbo.Devices", "Quantity");
        }
    }
}
