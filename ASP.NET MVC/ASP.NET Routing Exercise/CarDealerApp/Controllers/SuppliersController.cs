using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.ViewModels;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("suppliers")]
    public class SuppliersController : Controller
    {
        private SuppliersService service;

        public SuppliersController()
        {
            this.service = new SuppliersService();
        }

        [HttpGet]
        [Route("{type:regex(local|importers)}")]
        public ActionResult All(string type)
        {
            IEnumerable<SupplierVm> viewModels = this.service.GetAllSuppliersByType(type);
            return this.View(viewModels);
        }
    }
}
