namespace LinkedIn.Web.Infrastructure.ActionResults
{
    using System.Web.Mvc;

    public interface IViewResult
    {
        ViewResult View { get; }
    }
}
