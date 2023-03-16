using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Employee : BaseEntity
    {
        public Employee() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        public int? AttendenceReferenceID { get; set; }
        [Required]
        [StringLength(70)]
        public string EmployeeName { get; set; }
        [Required]
        public int BankID { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public int ShiftID { get; set; }
        [Required]
        public int DesignationID { get; set; }
        public int? ReportingToID { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        public int? WeeklyOff { get; set; }
        [StringLength(150)]
        public string QualificationDescription { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string MobileNumber { get; set; }
        [StringLength(20)]
        public string FamilyContactNumber { get; set; }
        [StringLength(20)]
        public string ContactPersonName { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(50)]
        public string ContactPersonRelationship { get; set; }
        [Required]
        public int NationalityID { get; set; }
        public int CountryID { get; set; }
        public int? RegionID { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(70)]
        public string Email { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public DateTime ActualDOB { get; set; }
        [StringLength(20)]
        public string InternationalContactNumber { get; set; }
        public string PhotoPath { get; set; }
        [Required]
        [StringLength(70)]
        // rename to status
        public string Status { get; set; }
        public string MedicalHistory { get; set; }
        public float? LeaveBalance { get; set; }
        public string AccountNumber { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public int BankAccountTypeID { get; set; }
        [ForeignKey("BankAccountTypeID")]
        public virtual BankAccountType BankAccountType { get; set; }
        [ForeignKey("ShiftID")]
        public virtual Shift Shift { get; set; }
        [ForeignKey("DesignationID")]
        public virtual Designation Designation { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }
        //[ForeignKey("NationalityID")]
        //public virtual Nationality Nationality { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }
        [ForeignKey("BankID")]
        public virtual Bank Bank { get; set; }


    }
}