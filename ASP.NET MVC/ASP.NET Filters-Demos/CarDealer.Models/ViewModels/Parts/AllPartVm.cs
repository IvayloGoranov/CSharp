namespace CarDealer.Models.ViewModels.Parts
{
    public class AllPartVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int Quantity { get; set; }

        public string SupplierName { get; set; }
    }
}
