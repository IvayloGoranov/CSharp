using System;
using System.IO;
using System.Web.Mvc;
using CarDealerApp.Security;

namespace CarDealerApp.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var logTime = DateTime.Now;
            var ip = filterContext.HttpContext.Request.UserHostAddress;
            var username = "Anonymous";
            var cookie = filterContext.HttpContext.Request.Cookies.Get("sessionId");
            if (cookie != null && AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                username = AuthenticationManager.GetAuthenticatedUser(cookie.Value).Username;
            }

            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;

            var log = "";
            if (filterContext.Exception == null)
            {
                log = $"{logTime} - {ip} - {username} - {controllerName}.{actionName}{Environment.NewLine}";
            }
            else
            {
                var exception = filterContext.Exception;
                log = $"[!] {logTime} - {ip} - {username} - {controllerName}.{actionName} - {exception.GetType().Name} - {exception.Message}{Environment.NewLine}";
            }

            File.AppendAllText("E:\\logs.txt", log);
        }
    }
}
