using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Nationality : BaseEntity
    {
        public Nationality() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NationalityID { get; set; }
        public string NationalityName { get; set; }

    }
}