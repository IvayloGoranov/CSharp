namespace LinkedIn.Web.Infrastructure.CacheService
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using LinkedIn.Data;
    using LinkedIn.Web.ViewModels;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly LinkedInData data;

        public MemoryCacheService(LinkedInData data)
        {
            this.data = data;
        }

        public IList<GroupViewModel> Groups
        {
            get
            {
                return this.Get<IList<GroupViewModel>>("Groups", () => 
                    this.data.Groups.All()
                        .Project()
                        .To<GroupViewModel>()
                        .ToList());
            }
        }
    }
}