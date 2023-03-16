using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class EnquiryJobDetail 
    {
        public EnquiryJobDetail() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquiryJobDetailID { get; set; }
        public int JobID { get; set; }
        public Boolean IsDeleted { get; set; }
        public int EnquiryID { get; set; }
        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }
        [ForeignKey("EnquiryID")]
        public virtual Enquiry Enquiry { get; set; }
    }
}