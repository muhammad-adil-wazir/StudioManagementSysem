using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class ProjectJobDetail
    {
        public ProjectJobDetail() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectJobDetailID { get; set; }
        public int JobID { get; set; }
        public bool IsHired { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal HiredCost { get; set; }
        public int Quantity { get; set; }
        public Boolean IsDeleted { get; set; }
        public int ProjectID { get; set; }
        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
    }
}