namespace LinkedIn.Web.Infrastructure.CacheService
{
    using System.Collections.Generic;

    using LinkedIn.Web.ViewModels;

    public interface ICacheService
    {
        IList<GroupViewModel> Groups { get; }
    }
}
