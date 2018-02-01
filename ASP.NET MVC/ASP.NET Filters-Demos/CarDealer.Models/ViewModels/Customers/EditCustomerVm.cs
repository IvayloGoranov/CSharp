using System;

namespace CarDealer.Models.ViewModels.Customers
{
    public class EditCustomerVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
