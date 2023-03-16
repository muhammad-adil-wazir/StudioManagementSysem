using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Designation : BaseEntity
    {
        public Designation() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }

    }
}