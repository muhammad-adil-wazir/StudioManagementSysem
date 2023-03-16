using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class RoleModel: BaseModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}