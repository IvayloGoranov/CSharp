namespace LinkedIn.Web.Infrastructure.CacheService
{
    using System.Web;

    using Antlr.Runtime.Misc;

    public class BaseCacheService
    {
        protected T Get<T>(string cacheId, Func<T> getItemcallback) where T : class
        {
            var item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemcallback();
                HttpContext.Current.Cache.Insert(cacheId, item);
                return item;
            }

            return item;
        }
    }
}