using SMS.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class CustomerComplexModel
    {
        public List<Customer> Customers { get; set; }
        public List<Country> Countries { get; set; }
        public List<Location> Locations { get; set; }
    }
}