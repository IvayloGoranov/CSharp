using System.Reflection;
using System.Web.Mvc;

namespace Twitter.Web.CustomAttributes
{
    public class AjaxChildActionOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest() || 
                controllerContext.IsChildAction;
        }
    }
}