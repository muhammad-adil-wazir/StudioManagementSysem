using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class EnquiryModel : BaseModel
    {
        public int EnquiryID { get; set; }
        public int EnquiryDate { get; set; }
        public int EnquiryTime { get; set; }
        public int JobID { get; set; }
        public string JobName { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int FunctionDate { get; set; }
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public int FunctionTypeID { get; set; }
        public string FunctionTypeName { get; set; }
        public int SkillID { get; set; }
        public string SkillName { get; set; }
        public int EnquiryTypeID { get; set; }
        public string EnquiryTypeName { get; set; }
        public int Reference { get; set; }
    }
}