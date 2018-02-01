using System.Web.Mvc;
using CarDealer.Models.ViewModels;
using System.Collections.Generic;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private SalesService service;

        public SalesController()
        {
            this.service = new SalesService();
        }

        [HttpGet]
        [Route]
        public ActionResult All()
        {
            IEnumerable<SaleVm> vms = this.service.GetAllSales();        
            return this.View(vms);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult About(int id)
        {
            SaleVm saleVm = this.service.GetSale(id);

            return this.View(saleVm);
        }

        [HttpGet]
        [Route("discounted/{percent?}/")]
        public ActionResult Discounted(double? percent)
        {
            IEnumerable<SaleVm> sales = this.service.GetDiscountedSales(percent);
            return this.View(sales);
        }



    }
}
