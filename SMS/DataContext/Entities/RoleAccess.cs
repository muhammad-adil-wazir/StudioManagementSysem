using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class RoleAccess : BaseEntity
    {
        public RoleAccess() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleAccessID { get; set; }
        public int InterfaceID { get; set; }
        public int RoleID { get; set; }
        public int EventAccessID { get; set; }


    }
}