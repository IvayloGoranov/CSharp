namespace LinkedIn.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data;
    using LinkedIn.Models;
    using LinkedIn.Web.Infrastructure.ActionResults;

    public abstract class BaseController : Controller
    {
        private LinkedInData data;
        private User userProfile;

        protected BaseController(LinkedInData data)
        {
            this.Data = data;
        }

        protected BaseController(LinkedInData data, User userProfile)
            :this(data)
        {
            this.UserProfile = userProfile;
        }

        protected LinkedInData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == username);
               
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }

        protected AutoMappedQueryViewResult<TSource, TResult> AutoMapperQueryView<TSource, TResult>(ViewResult view)
        {
            return new AutoMappedQueryViewResult<TSource, TResult>(view);
        }

        protected AutoMappedObjectViewResult<TSource, TResult> AutoMapperObjectView<TSource, TResult>(ViewResult view)
            where TSource : class
        {
            return new AutoMappedObjectViewResult<TSource, TResult>(view);
        } 
    }
}