using System.Web.Http;

namespace SoftUniWebAPI.Controllers
{
    using SoftUniWebAPI.Models;

    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        [Route("list")]
        [HttpGet]
        public string ListProducts()
        {
            return "products";
        }

        [Route("{id:int}")]
        public string GetProduct(int id)
        {
            return "product " + id;
        }

        [Route("{name}")]
        public IHttpActionResult GetProductByName(string name)
        {
            var product = new Product(name);

            return this.Ok(product);
        }
    }
}