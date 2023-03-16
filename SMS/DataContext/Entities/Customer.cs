using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Customer : BaseEntity
    {
        public Customer() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int LocationID { get; set; }
        public int CountryID { get; set; }
        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
    }
}