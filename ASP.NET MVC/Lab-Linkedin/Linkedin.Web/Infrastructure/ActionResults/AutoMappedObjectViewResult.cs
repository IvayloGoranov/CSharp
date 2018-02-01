namespace LinkedIn.Web.Infrastructure.ActionResults
{
    using System.Web.Mvc;

    using AutoMapper;

    public class AutoMappedObjectViewResult<TSource, TResult> : ActionResult, IViewResult
        where TSource : class
    {
        public AutoMappedObjectViewResult(ViewResult view)
        {
            this.View = view;
        }

        public ViewResult View { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var model = this.View.ViewData.Model as TSource;
            this.View.ViewData.Model = Mapper.Map<TResult>(model);
            this.View.ExecuteResult(context);
        }
    }
}