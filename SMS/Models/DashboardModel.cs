using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class DashboardModel
    {
        public int DeviceCount { get; set; }
        public int EnquiryCount { get; set; }
        public int ProjectCount { get; set; }
        public int EnquiryActiveCount { get; set; }
        public int ProjectActiveCount { get; set; }
        public List<Chart> Projects { get; set; }
        public List<Chart> Enquiries { get; set; }
    }
    public class Chart
    {
        public int Month { get; set; }
        public int Count { get; set; }
    }
}