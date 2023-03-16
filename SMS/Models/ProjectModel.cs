using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class ProjectModel : BaseModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int EnquiryID { get; set; }
        public string EnquiryName { get; set; }
        public DateTime ProjectDateTime { get; set; }
        public int JobID { get; set; }
        public string JobName { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public double HoursRequired { get; set; }
        public double ActualCost { get; set; }
        public double MaxCost { get; set; }
        public double Discount { get; set; }
        public double ChargeableAmount { get; set; }
        public double NoOfUnits { get; set; }
        public double TotalCost { get; set; }
    }
}