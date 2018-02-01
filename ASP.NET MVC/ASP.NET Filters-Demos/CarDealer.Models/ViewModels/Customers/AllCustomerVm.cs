using System;

namespace CarDealer.Models.ViewModels.Customers
{
    public class AllCustomerVm
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }
    }
}
