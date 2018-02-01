using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.BindingModels.Suppliers;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels.Suppliers;
using CarDealer.Services;
using CarDealerApp.Security;

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
        [Route("{type:regex(local|importers)?}")]
        public ActionResult All(string type)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                IEnumerable<SupplierVm> viewModels = this.service.GetAllSuppliersByType(type);
                return this.View(viewModels);
            }

            User user = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);
            ViewBag.Username = user.Username;
            IEnumerable<SupplierAllVm> vm = this.service.GetAllSuppliersByTypeForUsers(type);
            return this.View("AllSuppliersForUser", vm);
        }

        [HttpGet]
        [Route("add/")]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name, IsImporter")] AddSupplierBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }
            User loggedInUser = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);

            this.service.AddSupplier(bind, loggedInUser.Id);
            return this.RedirectToAction("All");
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            EditSupplierVm vm = this.service.GetEditSupplierVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id, Name, IsImporter")] EditSupplierBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            if (!this.ModelState.IsValid)
            {
                EditSupplierVm vm = this.service.GetEditSupplierVm(bind.Id);
                return this.View(vm);
            }

            User loggedInUser = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);

            this.service.EditSupplier(bind, loggedInUser.Id);
            return this.RedirectToAction("All");
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            DeleteSuplierVm vm = this.service.GetDeleteSupplierVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public ActionResult Delete([Bind(Include = "Id")]DeleteSupplierBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            if (!this.ModelState.IsValid)
            {
                DeleteSuplierVm vm = this.service.GetDeleteSupplierVm(bind.Id);
                return this.View(vm);
            }

            User loggedInUser = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);

            this.service.DeleteSupplier(bind, loggedInUser.Id);
            return this.RedirectToAction("All");
        }
    }
}
