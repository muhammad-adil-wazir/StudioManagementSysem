using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Enquiry : BaseEntity
    {
        public Enquiry() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquiryID { get; set; }
        public int EnquiryStatusID { get; set; }
        public DateTime EnquiryDate { get; set; }
        public TimeSpan EnquiryTime { get; set; }
        //public int JobID { get; set; }
        public int CustomerID { get; set; }
        public DateTime FunctionDate { get; set; }
        //public int DeviceID { get; set; }
        public int FunctionTypeID { get; set; }
        //public int SkillID { get; set; }
        public int EnquiryTypeID { get; set; }
        public string Venue { get; set; }
        public string Reference { get; set; }
        public decimal MinCost { get; set; }
        public decimal MaxCost { get; set; }
        public decimal ChargeableCost { get; set; }
        [ForeignKey("EnquiryStatusID")]
        public virtual EnquiryStatus EnquiryStatus { get; set; }
        //[ForeignKey("JobID")]
        //public virtual Job Job { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        //[ForeignKey("DeviceID")]
        //public virtual Device Device { get; set; }
        //[ForeignKey("FunctionTypeID")]
        //public virtual FunctionType FunctionType { get; set; }
        //[ForeignKey("SkillID")]
        //public virtual Skill Skill { get; set; }
        [ForeignKey("EnquiryTypeID")]
        public virtual EnquiryType EnquiryType { get; set; }

    }
}