using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.BindingModels.Parts;
using CarDealer.Models.ViewModels.Parts;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("parts")]
    public class PartsController : Controller
    {
        private PartsService service;

        public PartsController()
        {
            this.service = new PartsService();
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            var vms = this.service.GetAddVm();
            return this.View(vms);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name, Price, Quantity, SupplierId")] AddPartBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddPart(bind);
                return this.RedirectToAction("All", "Cars");
            }

            var vms = this.service.GetAddVm();
            return this.View(vms);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<AllPartVm> vms = this.service.GetAllPartVms();
            return this.View(vms);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            DeletePartVm vm = this.service.GetDeleteVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult Delete([Bind(Include = "PartId")] DeletePartBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeletePart(bind);
                return this.RedirectToAction("All");
            }

            DeletePartVm vm = this.service.GetDeleteVm(bind.PartId);
            return this.View(vm);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            EditPartVm vm = this.service.GetEditVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id, Price, Quantity")] EditPartBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditPart(bind);
                return this.RedirectToAction("All");
            }

            EditPartVm vm = this.service.GetEditVm(bind.Id);
            return this.View(vm);
        }
    }
}
