using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class EmployeeSkillDetail
    {
        public EmployeeSkillDetail() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeSkillDetailID { get; set; }
        public int EmployeeID { get; set; }
        public int SkillID { get; set; }
        public Boolean IsDeleted { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("SkillID")]
        public virtual Skill Skill { get; set; }
    }
}