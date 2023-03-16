using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Location : BaseEntity
    {
        public Location() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        public string LocationName { get; set; }

    }
}