namespace LinkedIn.Web.Infrastructure.ActionFilters
{
    using Ninject;
    using System.Web.Mvc;
    using System.Web.WebSockets;
    using LinkedIn.Web.Infrastructure.CacheService;

    public class PopulateGroupNamesAttribute : ActionFilterAttribute
    {
        [Inject]
        public ICacheService cacheService { private get; set; }
        
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Groups = this.cacheService.Groups;
            base.OnResultExecuting(filterContext);
        }
    }
}