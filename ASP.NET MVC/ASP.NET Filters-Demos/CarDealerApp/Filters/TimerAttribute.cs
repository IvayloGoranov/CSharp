using System;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace CarDealerApp.Filters
{
    public class TimerAttribute : ActionFilterAttribute
    {
        private Stopwatch timer = new Stopwatch();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.timer.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.timer.Stop();
            var timePassed = this.timer.Elapsed;
            this.timer.Reset();

            var logTimeStamp = DateTime.Now;
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;

            string log = $"{logTimeStamp} - {controllerName}.{actionName} - {timePassed}{Environment.NewLine}";
            File.AppendAllText("E:\\action-times.txt", log);
            base.OnActionExecuted(filterContext);
        }
    }
}
