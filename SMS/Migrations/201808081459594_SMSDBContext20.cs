namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Venue", c => c.String());
            AddColumn("dbo.Projects", "ParticipantOne", c => c.String());
            AddColumn("dbo.Projects", "ParticipantTwo", c => c.String());
            AddColumn("dbo.Projects", "FilesPath", c => c.String());
            AddColumn("dbo.ProjectJobDetails", "FromDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectJobDetails", "ToDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectStatusDetails", "CreatedByID", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectStatusDetails", "CreatedByDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectStatusDetails", "UpdatedByID", c => c.Int());
            AddColumn("dbo.ProjectStatusDetails", "updatedByDate", c => c.DateTime());
            AddColumn("dbo.ProjectStatusDetails", "Remarks", c => c.String());
            AddColumn("dbo.ProjectStatusDetails", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectStatusDetails", "IsDeleted");
            DropColumn("dbo.ProjectStatusDetails", "Remarks");
            DropColumn("dbo.ProjectStatusDetails", "updatedByDate");
            DropColumn("dbo.ProjectStatusDetails", "UpdatedByID");
            DropColumn("dbo.ProjectStatusDetails", "CreatedByDate");
            DropColumn("dbo.ProjectStatusDetails", "CreatedByID");
            DropColumn("dbo.ProjectJobDetails", "ToDate");
            DropColumn("dbo.ProjectJobDetails", "FromDate");
            DropColumn("dbo.Projects", "FilesPath");
            DropColumn("dbo.Projects", "ParticipantTwo");
            DropColumn("dbo.Projects", "ParticipantOne");
            DropColumn("dbo.Projects", "Venue");
        }
    }
}
