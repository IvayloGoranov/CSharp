using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace P3CollectionOfProducts
{
    public class ProductCollection : IProductCollection
    {
        private OrderedDictionary<int, Product> productsById;
        private OrderedDictionary<decimal, SortedSet<Product>> productsByPrice;
        private Dictionary<string, SortedSet<Product>> productsByTitle;
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByPriceAndTitle;
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByPriceAndSupplier;

        public ProductCollection()
        {
            this.productsById = new OrderedDictionary<int, Product>();
            this.productsByPrice = new OrderedDictionary<decimal, SortedSet<Product>>();
            this.productsByTitle = new Dictionary<string, SortedSet<Product>>();
            this.productsByPriceAndTitle = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
            this.productsByPriceAndSupplier = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
        }

        public bool AddProduct(int id, string title, string supplier, decimal price)
        {
            Product newProduct = new Product(id, title, supplier, price);
            if (!this.productsById.ContainsKey(id))
            {
                this.productsById.Add(id, newProduct);

                this.productsByPrice.AppendValueToKey(price, newProduct);

                this.productsByTitle.AppendValueToKey(title, newProduct);

                this.productsByPriceAndTitle.EnsureKeyExists(title);
                this.productsByPriceAndTitle[title].AppendValueToKey(price, newProduct);

                this.productsByPriceAndSupplier.EnsureKeyExists(supplier);
                this.productsByPriceAndSupplier[supplier].AppendValueToKey(price, newProduct);

                return true;
            }

            this.productsById[id] = newProduct;

            this.productsByPrice.AppendValueToKey(price, newProduct);

            this.productsByTitle.AppendValueToKey(title, newProduct);

            this.productsByPriceAndTitle.EnsureKeyExists(title);
            this.productsByPriceAndTitle[title].AppendValueToKey(price, newProduct);

            this.productsByPriceAndSupplier.EnsureKeyExists(supplier);
            this.productsByPriceAndSupplier[supplier].AppendValueToKey(price, newProduct);

            return false;
        }

        public int Count
        {
            get 
            { 
                return this.productsById.Count; 
            }
        }

        public bool Remove(int id)
        {
            if (!this.productsById.ContainsKey(id))
            {
                return false;
            }
            
            var product = this.productsById[id];
            this.productsById.Remove(id);

            decimal productPrice = product.Price;
            this.productsByPrice[productPrice].Remove(product);

            string productTitle = product.Title;
            this.productsByTitle[productTitle].Remove(product);

            this.productsByPriceAndTitle[productTitle][productPrice].Remove(product);

            string productSupplier = product.Supplier;
            this.productsByPriceAndSupplier[productSupplier][productPrice].Remove(product);

            return true;
        }

        public IEnumerable<Product> FindProducts(decimal startPrice, decimal endPrice)
        {
            var productsByPriceRange = this.productsByPrice.Range(startPrice, true, endPrice, true);
            SortedSet<Product> results = new SortedSet<Product>();
            foreach (var priceProductsPair in productsByPriceRange)
            {
                foreach (var product in priceProductsPair.Value)
                {
                    results.Add(product);
                }
            }

            return results;
        }

        public IEnumerable<Product> FindProducts(string title)
        {
            return this.productsByTitle.GetValuesForKey(title);
        }

        public IEnumerable<Product> FindProducts(string title, decimal price)
        {
            return this.productsByPriceAndTitle[title][price];
        }

        public IEnumerable<Product> FindProducts(string title, decimal startPrice, decimal endPrice)
        {
            var productsByTitleInPriceRange = this.productsByPriceAndTitle[title].Range(startPrice, true, endPrice, true);
            SortedSet<Product> results = new SortedSet<Product>();
            foreach (var priceProductsPair in productsByTitleInPriceRange)
            {
                foreach (var product in priceProductsPair.Value)
                {
                    results.Add(product);
                }
            }

            return results;
        }

        public IEnumerable<Product> FindProductsBySupplier(string supplier, decimal price)
        {
            return this.productsByPriceAndTitle[supplier][price];
        }

        public IEnumerable<Product> FindProductsBySupplier(string supplier, decimal startPrice, decimal endPrice)
        {
            var productsBySupplierInPriceRange = this.productsByPriceAndTitle[supplier].Range(startPrice, true, endPrice, true);
            SortedSet<Product> results = new SortedSet<Product>();
            foreach (var priceProductsPair in productsBySupplierInPriceRange)
            {
                foreach (var product in priceProductsPair.Value)
                {
                    results.Add(product);
                }
            }

            return results;
        }
    }
}
