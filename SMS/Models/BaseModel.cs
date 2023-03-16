using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class BaseModel
    {
        public int CreatedByID { get; set; }
        public DateTime CreatedByDate { get; set; }
        public int UpdatedByID { get; set; }
        public DateTime updatedByDate { get; set; }
        public string Remarks { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}