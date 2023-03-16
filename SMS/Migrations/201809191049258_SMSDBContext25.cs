namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "PaymentDate1", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "PaymentDate2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "PaymentDate3", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "PaymentDate4", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "Vat", c => c.Double(nullable: false));
            AddColumn("dbo.Projects", "ContractName", c => c.String());
            AddColumn("dbo.Projects", "ContractNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ContractNumber");
            DropColumn("dbo.Projects", "ContractName");
            DropColumn("dbo.Projects", "Vat");
            DropColumn("dbo.Projects", "PaymentDate4");
            DropColumn("dbo.Projects", "PaymentDate3");
            DropColumn("dbo.Projects", "PaymentDate2");
            DropColumn("dbo.Projects", "PaymentDate1");
        }
    }
}
