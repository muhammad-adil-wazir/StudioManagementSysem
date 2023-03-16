using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class UserModel : BaseModel
    {
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}