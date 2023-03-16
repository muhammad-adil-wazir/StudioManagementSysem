using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Department : BaseEntity
    {
        public Department() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

    }
}