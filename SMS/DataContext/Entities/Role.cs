using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Role : BaseEntity
    {
        public Role() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }
        public string RoleName { get; set; }


    }
}