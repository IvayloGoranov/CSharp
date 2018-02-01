using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

using Twitter.Data.Interfaces;
using Twitter.Models;

namespace Twitter.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        protected BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        protected BaseController(ITwitterData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected ITwitterData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, 
            AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.GetUserName();
                this.UserProfile = this.Data.Users.GetAll()
                        .FirstOrDefault(x => x.UserName == username);
            }

            var result = base.BeginExecute(requestContext, callback, state);

            return result;
        }
    }
}