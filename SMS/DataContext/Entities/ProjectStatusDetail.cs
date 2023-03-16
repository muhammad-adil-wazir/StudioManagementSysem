using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class ProjectStatusDetail : BaseEntity
    {
        public ProjectStatusDetail() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectStatusDetailID { get; set; }
        public int ProjectStatusID { get; set; }
        public int ProjectID { get; set; }
        [ForeignKey("ProjectStatusID")]
        public virtual ProjectStatus ProjectStatus { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
    }
}