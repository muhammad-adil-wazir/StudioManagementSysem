using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class ProjectFunctionTypeDetail
    {
        public ProjectFunctionTypeDetail() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectFunctionTypeDetailID { get; set; }
        public Boolean IsDeleted { get; set; }
        public int FunctionTypeID { get; set; }
        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
        [ForeignKey("FunctionTypeID")]
        public virtual FunctionType FunctionType{ get; set; }
    }
}