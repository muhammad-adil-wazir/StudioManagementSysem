using SMS.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class BankComplexModel
    {
        public List<Bank> Banks { get; set; }
        public List<Location> Locations { get; set; }
        public List<Country> Countries { get; set; }
    }
}