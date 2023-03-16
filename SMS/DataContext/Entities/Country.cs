using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Country : BaseEntity
    {
        public Country() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }
        [Required]
        [StringLength(70)]
        public string CountryName { get; set; }
        [StringLength(10)]
        public string ShortForm { get; set; }
        [StringLength(10)]
        public string Currency { get; set; }

    }
}