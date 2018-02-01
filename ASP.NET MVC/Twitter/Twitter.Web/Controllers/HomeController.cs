using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

using PagedList;

using Twitter.Data.Interfaces;
using Twitter.Models;
using Twitter.Web.ViewModels;

namespace Twitter.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ITwitterData data)
            : base(data)
        { 
        }

        public HomeController(ITwitterData data, User userProfile)
            : base(data, userProfile)
        {
        }

        public ActionResult Index(int? page, string searchString)
        {
            int pageSize = 5;
            int pageNumber = 1;
            if (page != null)
            {
                pageNumber = (int)page;
            }

            if (this.HttpContext.Cache["allPosts"] == null)
            {
                var allPostsQuery = this.Data.Posts.GetAll().
                Include(x => x.PostFavourites).
                Include(x => x.Answers).
                Where(x => x.Question == null).
                Select(PostViewModel.ViewModel).
                OrderByDescending(x => x.CreatedOn).ToList();

                this.HttpContext.Cache["allPosts"] = allPostsQuery;
            }

            var allPostsPagedList = 
                ((List<PostViewModel>)this.HttpContext.Cache["allPosts"]).
                                ToPagedList(pageNumber, pageSize);

            if (!string.IsNullOrEmpty(searchString))
            {
                var allPostsQuery = this.Data.Posts.GetAll().
                    Include(x => x.PostFavourites).
                    Include(x => x.Answers).
                    Where(x => x.Question == null && x.PostedBy.UserName.Contains(searchString)).
                    Select(PostViewModel.ViewModel).
                    OrderByDescending(x => x.CreatedOn).ToList();

                allPostsPagedList = allPostsQuery.ToPagedList(pageNumber, pageSize);
            }

            return this.View(allPostsPagedList);
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}