using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Interface : BaseEntity
    {
        public Interface() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterfaceID { get; set; }
        public int? ParentInterfaceID { get; set; }
        public string InterfaceName { get; set; }
        [ForeignKey("ParentInterfaceID")]
        public virtual Interface ParentInterface { get; set; }

    }
}