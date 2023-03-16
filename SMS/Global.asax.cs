//using AutoMapper;
using SMS.DataContext.Entities;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<User, UserModel>();
            //    cfg.CreateMap<Role, RoleModel>();
            //    cfg.CreateMap<Employee, EmployeeModel>();
            //});
        }
    }
}
