using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Project : BaseEntity
    {
        public Project() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Venue { get; set; }
        public string ParticipantOne { get; set; }
        public string ParticipantTwo{ get; set; }
        public string FilesPath { get; set; }
        public int EnquiryID { get; set; }
        public int ProjectStatusID { get; set; }
        public DateTime ProjectDate { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public TimeSpan ProjectTime { get; set; }
        public double HoursRequired { get; set; }
        public double ActualCost { get; set; }
        public double MaxCost { get; set; }
        public double Discount { get; set; }
        public double Payment1 { get; set; }
        public double Payment2 { get; set; }
        public double Payment3 { get; set; }
        public double Payment4 { get; set; }
        public DateTime? PaymentDate1 { get; set; }
        public DateTime? PaymentDate2 { get; set; }
        public DateTime? PaymentDate3 { get; set; }
        public DateTime? PaymentDate4 { get; set; }
        public double Vat { get; set; }
        public string ContractName { get; set; }
        public string ContractNumber { get; set; }
        public double Balance { get; set; }
        public double ChargeableAmount { get; set; }
        public int FunctionTypeID { get; set; }
        //public double NoOfUnits { get; set; }
        public double TotalCost { get; set; }
        [ForeignKey("ProjectStatusID")]
        public virtual ProjectStatus ProjectStatus { get; set; }
        [ForeignKey("EnquiryID")]
        public virtual Enquiry Enquiry { get; set; }
        [ForeignKey("FunctionTypeID")]
        public virtual FunctionType FunctionType{ get; set; }

    }
}