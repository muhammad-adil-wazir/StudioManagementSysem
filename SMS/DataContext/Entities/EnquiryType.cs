using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class EnquiryType : BaseEntity
    {
        public EnquiryType() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquiryTypeID { get; set; }
        public string EnquiryTypeName { get; set; }

    }
}