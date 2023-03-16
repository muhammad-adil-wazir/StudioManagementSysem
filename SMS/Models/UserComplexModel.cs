using SMS.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class UserComplexModel
    {
        public List<User> User { get; set; }
        public List<Role> Roles { get; set; }
        public List<Employee> Employees { get; set; }
    }
}