namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Interfaces", "InterfaceName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Interfaces", "InterfaceName", c => c.Int(nullable: false));
        }
    }
}
