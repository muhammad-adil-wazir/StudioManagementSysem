using SMS.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class RoleAccessComplexModel
    {
        public List<Role> Roles { get; set; }
        public List<Interface> Interfaces { get; set; }
        public List<RoleAccess> RoleAccess { get; set; }
        public List<EventAccess> EventAccess { get; set; }
    }
}