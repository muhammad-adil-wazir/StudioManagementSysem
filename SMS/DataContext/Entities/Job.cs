using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Job : BaseEntity
    {
        public Job() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobID { get; set; }
        public string JobName { get; set; }

    }
}