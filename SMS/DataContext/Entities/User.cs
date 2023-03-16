using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class User : BaseEntity
    {
        public User() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

    }
}