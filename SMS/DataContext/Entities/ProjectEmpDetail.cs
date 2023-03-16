using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class ProjectEmpDetail
    {
        public ProjectEmpDetail() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectEmpDetailID { get; set; }
        public int EmployeeID { get; set; }
        public int SkillID { get; set; }
        public bool IsHired { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal HiredCost { get; set; }
        public int Quantity { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public Boolean IsDeleted { get; set; }
        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
        [ForeignKey("SkillID")]
        public virtual Skill Skill { get; set; }
    }
}