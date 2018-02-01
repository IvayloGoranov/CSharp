using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.MVC.ViewEngine;
using SimpleMVC.App.MVC.ViewEngine.Generic;
using System.Runtime.CompilerServices;

namespace SimpleMVC.App.MVC.Controllers
{
    public class Controller
    {
        protected IActionResult View([CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult(fullQualifedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult(fullQualifedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllersSuffix, string.Empty);
            string fullQualifedName = string.Format(
               "{0}.{1}.{2}.{3}",
               MvcContext.Current.AssemblyName,
               MvcContext.Current.ViewsFolder,
               controllerName,
               callee);

            return new ActionResult<T>(fullQualifedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            string fullQualifedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(fullQualifedName, model);
        }

        protected void Redirect(HttpResponse response, string location)
        {
            response.Header.Location = location;
            response.StatusCode = ResponseStatusCode.Found;
        }
    }
}
