using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.DataContext.Entities
{
    public class FunctionType : BaseEntity
    {
        public FunctionType() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FunctionTypeID { get; set; }
        public string FunctionTypeName { get; set; }

    }
}