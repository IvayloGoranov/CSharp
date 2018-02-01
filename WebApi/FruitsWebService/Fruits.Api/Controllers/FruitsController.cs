using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using Fruits.Services.Interfaces;

namespace Fruits.Api.Controllers
{
    [Route("api/fruits")]
    public class FruitsController : Controller
    {
        private IFruitsService fruitsService;

        public FruitsController(IFruitsService fruitsService)
        {
            this.fruitsService = fruitsService;
        }

        // GET api/fruits/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var fruit = await this.fruitsService.FindById(id);

                return this.Ok(fruit);
            }
            catch (KeyNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        // DELETE api/fruits/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return this.BadRequest("Id should be a positive integer.");
            }

            try
            {
                await this.fruitsService.Delete(id);

                return this.NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}
