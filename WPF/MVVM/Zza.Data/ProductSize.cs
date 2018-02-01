
namespace Zza.Data
{
    public class ProductSize
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal? PremiumPrice { get; set; }

        public decimal? ToppingPrice { get; set; }

        public bool? IsGlutenFree { get; set; }
    }
}
