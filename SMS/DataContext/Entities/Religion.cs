using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Religion : BaseEntity
    {
        public Religion() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReligionID { get; set; }
        public string ReligionName { get; set; }

    }
}