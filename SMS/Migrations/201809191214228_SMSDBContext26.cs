namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext26 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "PaymentDate1", c => c.DateTime());
            AlterColumn("dbo.Projects", "PaymentDate2", c => c.DateTime());
            AlterColumn("dbo.Projects", "PaymentDate3", c => c.DateTime());
            AlterColumn("dbo.Projects", "PaymentDate4", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "PaymentDate4", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "PaymentDate3", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "PaymentDate2", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "PaymentDate1", c => c.DateTime(nullable: false));
        }
    }
}
