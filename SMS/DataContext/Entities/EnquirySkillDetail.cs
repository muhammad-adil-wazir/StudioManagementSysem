using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class EnquirySkillDetail
    {
        public EnquirySkillDetail() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquirySkillDetailID { get; set; }
        public int SkillID { get; set; }
        public int Quantity { get; set; }
        public decimal HiredCost { get; set; }
     
        public bool IsHired { get; set; }
        public Boolean IsDeleted { get; set; }
        public int EnquiryID { get; set; }
        [ForeignKey("SkillID")]
        public virtual Skill Skill{ get; set; }
        [ForeignKey("EnquiryID")]
        public virtual Enquiry Enquiry { get; set; }
    }
}