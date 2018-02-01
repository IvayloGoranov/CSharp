using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.BindingModels.Customers;
using CarDealer.Models.ViewModels.Customers;
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

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name,BirthDate")] AddCustomerBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddCustomerBm(bind);

                return this.RedirectToAction("All", new { order = "ascending" });
            }

            return this.View();
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            EditCustomerVm vm = this.service.GetEditVm(id);

            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id,Name,BirthDate")] EditCustomerBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditCustomer(bind);
                return this.RedirectToAction("All", new { order = "ascending" });
            }

            return this.View(this.service.GetEditVm(bind.Id));
        }
    }
}