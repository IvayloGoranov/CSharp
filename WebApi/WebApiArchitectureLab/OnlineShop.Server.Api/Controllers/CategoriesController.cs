

using OnlineShop.Data;

namespace OnlineShop.Server.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IOnlineShopContext data)
            : base(data)
        {
        }
    }
}
