using System.Collections.Generic;

namespace CarDealer.Models.ViewModels.Sales
{
    public class AddSaleVm
    {
        public IEnumerable<AddSaleCustomerVm> Customers { get; set; }

        public IEnumerable<AddSaleCarVm> Cars { get; set; }

        public IEnumerable<int> Discounts { get; set; }

    }
}
