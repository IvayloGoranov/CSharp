using System.Web.Http;

using OnlineShop.Data;

namespace OnlineShop.Server.Api.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public BaseApiController(IOnlineShopContext data)
        {
            this.Data = data;
        }

        protected IOnlineShopContext Data { get; set; }
    }
}