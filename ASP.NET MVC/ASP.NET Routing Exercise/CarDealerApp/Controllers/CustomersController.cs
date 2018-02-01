using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.ViewModels;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("customers")]
    public class CustomersController : Controller
    {
        private CustomersService service;

        public CustomersController()
        {
            this.service = new CustomersService();
        }

        [HttpGet]
        [Route("all/{order:regex(ascending|descending)}")]
        public ActionResult All(string order)
        {
            IEnumerable<AllCustomerVm> viewModels = this.service.GetAllOrderedCustomers(order);
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult About(int id)
        {
            AboutCustomerVm vm = this.service.GetCustomerWithCarData(id);

            return this.View(vm);
        }
    }
}