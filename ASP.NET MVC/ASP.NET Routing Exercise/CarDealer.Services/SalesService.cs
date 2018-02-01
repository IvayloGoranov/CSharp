using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class SalesService : Service
    {
        public IEnumerable<SaleVm> GetAllSales()
        {
            IEnumerable<Sale> sales = this.Context.Sales;

            IEnumerable<SaleVm> saleVms = Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleVm>>(sales);
            return saleVms;
        }

        public SaleVm GetSale(int id)
        {
            Sale sale = this.Context.Sales.Find(id);

            SaleVm vm = Mapper.Map<Sale, SaleVm>(sale);
            return vm;
        }

        public IEnumerable<SaleVm> GetDiscountedSales(double? percent)
        {
            percent /= 100;
            IEnumerable<Sale> sales = this.Context.Sales.Where(sale => sale.Discount != 0);

            if (percent != null)
            {
                sales = sales.Where(sale => sale.Discount == percent.Value);
            }

            IEnumerable<SaleVm> vms = Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleVm>>(sales);
            return vms;
        }
    }
}
