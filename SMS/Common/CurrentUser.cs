using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Common
{
    public static class CurrentUser
    {

        public static int UserID
        {
            get
            {
                var _userId = 0;
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
                {
                    _userId = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0]);
                }
                return _userId;
            }
        }
        public static int RoleID
        {
            get
            {
                var _roleId = 0;
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
                {
                    _roleId = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[1]);
                }
                return _roleId;
            }
        }
        public static string UserName
        {
            get
            {
                var _userName = "";
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
                {
                    _userName = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[2];
                }
                return _userName;
            }
        }
        public static int EmployeeID
        {
            get
            {
                var _employeeId = 0;
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
                {
                    _employeeId = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[3]);
                }
                return _employeeId;
            }
        }
    }
}