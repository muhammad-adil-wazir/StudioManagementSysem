using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class EnquiryStatusDetail 
    {
        public EnquiryStatusDetail() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquiryStatusDetailID { get; set; }
        public int EnquiryStatusID { get; set; }
        public int EnquiryID { get; set; }
        [ForeignKey("EnquiryStatusID")]
        public virtual EnquiryStatus EnquiryStatus { get; set; }
        [ForeignKey("EnquiryID")]
        public virtual Enquiry Enquiry { get; set; }
    }
}