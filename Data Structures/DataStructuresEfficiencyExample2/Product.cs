using System;

namespace P3CollectionOfProducts
{
    public class Product : IComparable<Product>
    {
        public Product(int id, string title, string supplier, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }
        
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Supplier { get; private set; }

        public decimal Price { get; private set; }

        public int CompareTo(Product otherProduct)
        {
            if (otherProduct == null)
            {
                return -1;
            }

            return this.Id.CompareTo(otherProduct.Id);
        }

        public override bool Equals(object obj)
        {
            Product otherProduct = obj as Product;
            if (otherProduct == null)
            {
                return false;
            }

            return this.Id.Equals(otherProduct.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.Id, this.Title, this.Supplier, this.Price);
        }
    }
}
