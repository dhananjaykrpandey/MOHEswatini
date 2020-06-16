using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace MOHEswatini
{
    public class SessionTimeOutAttribute : ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //LogResult("OnActionExecuting", filterContext.RouteData);

            byte[] outvalue = null;
            filterContext.HttpContext.Session.TryGetValue("lgoin", out outvalue);

            var userName = ((ClaimsIdentity)((Microsoft.AspNetCore.Http.DefaultHttpContext)filterContext.HttpContext).User.Identity).Name;
            if (userName == null || userName.ToString().Trim() == "")
            {


                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "controller", "Logins"},
                    {"action", "Index"} });
            }


        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //LogResult("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // LogResult("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //LogResult("OnResultExecuted", filterContext.RouteData);
        }


        private void LogResult(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }
    }
}