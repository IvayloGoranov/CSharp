using System;
using System.Text;

class Product : IComparable<Product>
{
    public Product(string name, decimal price, string producer)
    {
        this.Name = name;
        this.Price = price;
        this.Producer = producer;
    }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Producer { get; set; }
    
    public bool IsDeleted { get; set; }

    public override string ToString()
    {
        return String.Format("{{{0};{1};{2:0.00}}}",
            this.Name, this.Producer, this.Price);
    }

    public int CompareTo(Product otherProduct)
    {
        if (this == otherProduct)
        {
            return 0;
        }

        int result = this.Name.CompareTo(otherProduct.Name);
        if (result == 0)
        {
            result = this.Producer.CompareTo(otherProduct.Producer);
        }

        if (result == 0)
        {
            result = this.Price.CompareTo(otherProduct.Price);
        }

        return result;
    }
}