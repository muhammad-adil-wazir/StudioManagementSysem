using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Bank : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int LocationID { get; set; }
        public int CountryID { get; set; }
        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }

    }
}