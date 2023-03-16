using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class Skill : BaseEntity
    {
        public Skill() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillID { get; set; }
        public string SkillName { get; set; }

    }
}