using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class EnquiryDeviceDetail 
    {
        public EnquiryDeviceDetail() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquiryDeviceDetailID { get; set; }
        public Boolean IsDeleted { get; set; }
        public int DeviceID { get; set; }
        public int Quantity { get; set; }
        public decimal HiredCost { get; set; }
        public bool IsHired { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int EnquiryID { get; set; }
        [ForeignKey("DeviceID")]
        public virtual Device Device { get; set; }
        [ForeignKey("EnquiryID")]
        public virtual Enquiry Enquiry { get; set; }

    }
}