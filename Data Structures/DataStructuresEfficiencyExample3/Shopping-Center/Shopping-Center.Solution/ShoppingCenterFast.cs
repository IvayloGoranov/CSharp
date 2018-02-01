using System.Collections.Generic;
using System;
using System.Linq;
using Wintellect.PowerCollections;
using System.Text;

namespace ShoppingCenter
{
    public class ShoppingCenterFast
    {
        private const string PRODUCT_ADDED = "Product added";
        private const string X_PRODUCTS_DELETED = " products deleted";
        private const string NO_PRODUCTS_FOUND = "No products found";
        private const string INCORRECT_COMMAND = "Incorrect command";

        private readonly Dictionary<string, OrderedBag<Product>> productsByName =
            new Dictionary<string, OrderedBag<Product>>();
        private readonly Dictionary<string, OrderedBag<Product>> productsByNameAndProducer = 
            new Dictionary<string, OrderedBag<Product>>();
        private readonly Dictionary<string, OrderedBag<Product>> productsByProducer =
            new Dictionary<string, OrderedBag<Product>>();
        private readonly OrderedDictionary<decimal, OrderedBag<Product>> productsByPrice = 
            new OrderedDictionary<decimal, OrderedBag<Product>>();

        public string ProcessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parameterValues = command.Substring(indexOfFirstSpace + 1);
            string[] parameters = parameterValues.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            switch (method)
            {
                case "AddProduct":
                    return this.AddProduct(parameters[0], parameters[1], parameters[2]);
                case "DeleteProducts":
                    if (parameters.Length == 1)
                    {
                        return this.DeleteProductsByProducer(parameters[0]);
                    }
                    else
                    {
                        return this.DeleteProductsByNameAndProducer(parameters[0], parameters[1]);
                    }
                case "FindProductsByName":
                    return this.FindProductsByName(parameters[0]);
                case "FindProductsByPriceRange":
                    return this.FindProductsByPriceRange(parameters[0], parameters[1]);
                case "FindProductsByProducer":
                    return this.FindProductsByProducer(parameters[0]);
                default:
                    return INCORRECT_COMMAND;
            }
        }
        
        private string AddProduct(string name, string price, string producer)
        {
            decimal productPrice = decimal.Parse(price);
            Product product = new Product(name, productPrice, producer);

            this.productsByName.AppendValueToKey(name, product);
            
            string nameAndProducer = this.CombineNameAndProducer(name, producer);
            this.productsByNameAndProducer.AppendValueToKey(nameAndProducer, product);

            this.productsByProducer.AppendValueToKey(producer, product);

            this.productsByPrice.AppendValueToKey(productPrice, product);
            
            return PRODUCT_ADDED;
        }

        private string FindProductsByName(string name)
        {
            var products = this.productsByName.GetValuesForKey(name);
            
            return PrintProducts(products);
        }

        private string FindProductsByProducer(string producer)
        {
            var products = this.productsByProducer.GetValuesForKey(producer);
            
            return PrintProducts(products);
        }

        private string FindProductsByPriceRange(string from, string to)
        {
            decimal rangeStart = decimal.Parse(from);
            decimal rangeEnd = decimal.Parse(to);
            var results = this.productsByPrice.Range(rangeStart, true, rangeEnd, true);
            OrderedBag<Product> products = new OrderedBag<Product>();
            foreach (var priceProductsPair in results)
            {
                foreach (var product in priceProductsPair.Value)
                {
                    products.Add(product);
                }
            }

            return PrintProducts(products);
        }

        private string PrintProducts(IEnumerable<Product> products)
        {
            if (products.Any())
            {
                StringBuilder output = new StringBuilder();
                foreach (var product in products)
                {
                    output.AppendLine(product.ToString());
                }

                // Remove the unneeded last "new line"
                output.Length -= Environment.NewLine.Length;

                return output.ToString();
            }

            return NO_PRODUCTS_FOUND;
        }

        private string DeleteProductsByNameAndProducer(string name, string producer)
        {
            string nameAndProducer = this.CombineNameAndProducer(name, producer);
            if (this.productsByNameAndProducer.ContainsKey(nameAndProducer))
            {
                var productsToBeRemoved = this.productsByNameAndProducer[nameAndProducer];
                int productsCount = productsToBeRemoved.Count;
                this.productsByNameAndProducer.Remove(nameAndProducer);

                foreach (var product in productsToBeRemoved)
                {
                    this.productsByName[product.Name].Remove(product);
                    this.productsByPrice[product.Price].Remove(product);
                    this.productsByProducer[product.Producer].Remove(product);

                    return productsCount + X_PRODUCTS_DELETED;
                }

            }

            return NO_PRODUCTS_FOUND;
        }

        private string DeleteProductsByProducer(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                var productsToBeRemoved = this.productsByProducer[producer];
                int productsCount = productsToBeRemoved.Count;
                this.productsByProducer.Remove(producer);

                foreach (var product in productsToBeRemoved)
                {
                    this.productsByName[product.Name].Remove(product);

                    this.productsByPrice[product.Price].Remove(product);

                    string nameAndProducer = this.CombineNameAndProducer(product.Name, product.Producer);
                    this.productsByNameAndProducer[nameAndProducer].Remove(product);

                    return productsCount + X_PRODUCTS_DELETED;
                }

            }

            return NO_PRODUCTS_FOUND;
        }

        private string CombineNameAndProducer(string name, string producer)
        {
            const string Separator = "|!|";

            return name + Separator + producer;
        }
    }
}
