using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.Infrastructure.ActionResults
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    public class AutoMappedQueryViewResult<TSource, TResult> : ActionResult, IViewResult
    {
        public AutoMappedQueryViewResult(ViewResult view)
        {
            this.View = view;
        }

        public ViewResult View { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var queryable = this.View.ViewData.Model as IQueryable<TSource>;
            this.View.ViewData.Model = queryable.Project().To<TResult>();
            this.View.ExecuteResult(context);
        }
    }
}