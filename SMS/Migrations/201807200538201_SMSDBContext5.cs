namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSDBContext5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccountTypes",
                c => new
                    {
                        BankAccountTypeID = c.Int(nullable: false, identity: true),
                        BankAccountTypeName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BankAccountTypeID);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankID = c.Int(nullable: false, identity: true),
                        BankName = c.String(),
                        BranchName = c.String(),
                        ContactPerson = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        LocationID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BankID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: false)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: false)
                .Index(t => t.LocationID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 70),
                        ShortForm = c.String(maxLength: 10),
                        Currency = c.String(maxLength: 10),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 70),
                        Logo = c.String(maxLength: 70),
                        EstablishmentDate = c.DateTime(nullable: false),
                        EstablishedBy = c.String(nullable: false, maxLength: 70),
                        AssistedBy = c.String(maxLength: 70),
                        RegistrationID = c.String(),
                        CountryID = c.Int(nullable: false),
                        CompanyNumber = c.String(maxLength: 70),
                        Currency = c.String(maxLength: 10),
                        CompanyTypeID = c.Int(),
                        CompanyStatusID = c.Int(),
                        Address = c.String(maxLength: 800),
                        ContactPerson = c.String(maxLength: 70),
                        MobileNumber = c.String(maxLength: 20),
                        OfficeNumber = c.String(maxLength: 20),
                        TotalCapital = c.Single(nullable: false),
                        TotalShares = c.Single(nullable: false),
                        InitialValue = c.Single(nullable: false),
                        CurrentValue = c.Single(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationID = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DesignationID);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityID = c.Int(nullable: false, identity: true),
                        NationalityName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NationalityID);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftID = c.Int(nullable: false, identity: true),
                        ShiftName = c.String(maxLength: 70),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        BreakStartTime = c.Time(nullable: false, precision: 7),
                        BreakEndTime = c.Time(nullable: false, precision: 7),
                        TotalTime = c.Time(nullable: false, precision: 7),
                        TotalBreakHours = c.Time(nullable: false, precision: 7),
                        TotalWorkingHours = c.Time(nullable: false, precision: 7),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftID);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        ReligionID = c.Int(nullable: false, identity: true),
                        ReligionName = c.String(),
                        CreatedByID = c.Int(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        updatedByDate = c.DateTime(),
                        Remarks = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReligionID);
            
            AddColumn("dbo.Customers", "LocationID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CountryID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "AttendenceReferenceID", c => c.Int());
            AddColumn("dbo.Employees", "BankID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "ShiftID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "DesignationID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "ReportingToID", c => c.Int());
            AddColumn("dbo.Employees", "DepartmentID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "WeeklyOff", c => c.Int());
            AddColumn("dbo.Employees", "QualificationDescription", c => c.String(maxLength: 150));
            AddColumn("dbo.Employees", "PhoneNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "MobileNumber", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Employees", "FamilyContactNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "ContactPersonName", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "Address", c => c.String(maxLength: 200));
            AddColumn("dbo.Employees", "ContactPersonRelationship", c => c.String(maxLength: 50));
            AddColumn("dbo.Employees", "NationalityID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "CountryID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "RegionID", c => c.Int());
            AddColumn("dbo.Employees", "Gender", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Employees", "Email", c => c.String(maxLength: 70));
            AddColumn("dbo.Employees", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "ActualDOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "InternationalContactNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "PhotoPath", c => c.String());
            AddColumn("dbo.Employees", "Status", c => c.String(nullable: false, maxLength: 70));
            AddColumn("dbo.Employees", "MedicalHistory", c => c.String());
            AddColumn("dbo.Employees", "LeaveBalance", c => c.Single());
            AddColumn("dbo.Employees", "AccountNumber", c => c.String());
            AddColumn("dbo.Employees", "JoiningDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "BankAccountTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false, maxLength: 70));
            CreateIndex("dbo.Customers", "LocationID");
            CreateIndex("dbo.Customers", "CountryID");
            CreateIndex("dbo.Employees", "BankID");
            CreateIndex("dbo.Employees", "CompanyID");
            CreateIndex("dbo.Employees", "ShiftID");
            CreateIndex("dbo.Employees", "DesignationID");
            CreateIndex("dbo.Employees", "DepartmentID");
            CreateIndex("dbo.Employees", "NationalityID");
            CreateIndex("dbo.Employees", "CountryID");
            CreateIndex("dbo.Employees", "BankAccountTypeID");
            CreateIndex("dbo.Users", "EmployeeID");
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.Customers", "CountryID", "dbo.Countries", "CountryID", cascadeDelete: false);
            AddForeignKey("dbo.Customers", "LocationID", "dbo.Locations", "LocationID", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "BankID", "dbo.Banks", "BankID", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "BankAccountTypeID", "dbo.BankAccountTypes", "BankAccountTypeID", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "CountryID", "dbo.Countries", "CountryID", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments", "DepartmentID", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "DesignationID", "dbo.Designations", "DesignationID", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "NationalityID", "dbo.Nationalities", "NationalityID", cascadeDelete: false);
            AddForeignKey("dbo.Employees", "ShiftID", "dbo.Shifts", "ShiftID", cascadeDelete: false);
            AddForeignKey("dbo.Users", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: false);
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "RoleID", cascadeDelete: false);
            DropColumn("dbo.Employees", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Designation", c => c.String());
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Users", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ShiftID", "dbo.Shifts");
            DropForeignKey("dbo.Employees", "NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.Employees", "DesignationID", "dbo.Designations");
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Employees", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Employees", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Employees", "BankAccountTypeID", "dbo.BankAccountTypes");
            DropForeignKey("dbo.Employees", "BankID", "dbo.Banks");
            DropForeignKey("dbo.Customers", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Customers", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Companies", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Banks", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Banks", "CountryID", "dbo.Countries");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Users", new[] { "EmployeeID" });
            DropIndex("dbo.Employees", new[] { "BankAccountTypeID" });
            DropIndex("dbo.Employees", new[] { "CountryID" });
            DropIndex("dbo.Employees", new[] { "NationalityID" });
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            DropIndex("dbo.Employees", new[] { "DesignationID" });
            DropIndex("dbo.Employees", new[] { "ShiftID" });
            DropIndex("dbo.Employees", new[] { "CompanyID" });
            DropIndex("dbo.Employees", new[] { "BankID" });
            DropIndex("dbo.Customers", new[] { "CountryID" });
            DropIndex("dbo.Customers", new[] { "LocationID" });
            DropIndex("dbo.Companies", new[] { "CountryID" });
            DropIndex("dbo.Banks", new[] { "CountryID" });
            DropIndex("dbo.Banks", new[] { "LocationID" });
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String());
            DropColumn("dbo.Employees", "BankAccountTypeID");
            DropColumn("dbo.Employees", "JoiningDate");
            DropColumn("dbo.Employees", "AccountNumber");
            DropColumn("dbo.Employees", "LeaveBalance");
            DropColumn("dbo.Employees", "MedicalHistory");
            DropColumn("dbo.Employees", "Status");
            DropColumn("dbo.Employees", "PhotoPath");
            DropColumn("dbo.Employees", "InternationalContactNumber");
            DropColumn("dbo.Employees", "ActualDOB");
            DropColumn("dbo.Employees", "DOB");
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Employees", "Gender");
            DropColumn("dbo.Employees", "RegionID");
            DropColumn("dbo.Employees", "CountryID");
            DropColumn("dbo.Employees", "NationalityID");
            DropColumn("dbo.Employees", "ContactPersonRelationship");
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Employees", "ContactPersonName");
            DropColumn("dbo.Employees", "FamilyContactNumber");
            DropColumn("dbo.Employees", "MobileNumber");
            DropColumn("dbo.Employees", "PhoneNumber");
            DropColumn("dbo.Employees", "QualificationDescription");
            DropColumn("dbo.Employees", "WeeklyOff");
            DropColumn("dbo.Employees", "DepartmentID");
            DropColumn("dbo.Employees", "ReportingToID");
            DropColumn("dbo.Employees", "DesignationID");
            DropColumn("dbo.Employees", "ShiftID");
            DropColumn("dbo.Employees", "CompanyID");
            DropColumn("dbo.Employees", "BankID");
            DropColumn("dbo.Employees", "AttendenceReferenceID");
            DropColumn("dbo.Customers", "CountryID");
            DropColumn("dbo.Customers", "LocationID");
            DropTable("dbo.Religions");
            DropTable("dbo.Shifts");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.Companies");
            DropTable("dbo.Locations");
            DropTable("dbo.Countries");
            DropTable("dbo.Banks");
            DropTable("dbo.BankAccountTypes");
        }
    }
}
