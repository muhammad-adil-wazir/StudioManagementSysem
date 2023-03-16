using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class ProjectStatus : BaseEntity
    {
        public ProjectStatus() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectStatusID { get; set; }
        public string ProjectStatusName { get; set; }

    }
}