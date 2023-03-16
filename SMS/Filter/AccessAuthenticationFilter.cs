using SMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace SMS.Filter
{
    public class AccessAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {

        public string InterfaceName { get; set; }
        public string EventAccess { get; set; }

        void IAuthenticationFilter.OnAuthentication(AuthenticationContext filterContext)
        {
            try
            {
            var Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = filterContext.ActionDescriptor.ActionName;
            //var User = filterContext.HttpContext.User;
            //var IP = filterContext.HttpContext.Request.UserHostAddress;
            if ("AdminRole".GetConfigByKey<int>() != CurrentUser.RoleID)
            {
                var _interfaces = InterfaceName.Split(',');
                var _eventAccessID = Utilities.EventAccess.FirstOrDefault(x => x.EventAccessName.Contains(EventAccess)).EventAccessID;
                var _interfaceID = Utilities.Interfaces.FirstOrDefault(x => x.InterfaceName.RemoveAllWhiteSpaces().ToLower() == InterfaceName.ToLower()).InterfaceID;
                for (int i = 0; i < _interfaces.Count(); i++)
                {
                    var _userAccess = Utilities.RoleAccess.Where(ua => ua.EventAccessID == _eventAccessID && ua.InterfaceID == _interfaceID && ua.RoleID == CurrentUser.RoleID).FirstOrDefault();
                    if (_userAccess == null)
                    {
                        filterContext.HttpContext.Response.StatusCode = 403;
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            filterContext.Result = new EmptyResult();
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult("~/Home/UnAuthorized");
                        }

                    }
                }

            }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Account/LogOut");
            }
            // throw new NotImplementedException();
        }

        void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                new System.Web.Routing.RouteValueDictionary{
                {"controller", "Account"},
                {"action", "Login"},
                {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                });
            }
        }
    }
}