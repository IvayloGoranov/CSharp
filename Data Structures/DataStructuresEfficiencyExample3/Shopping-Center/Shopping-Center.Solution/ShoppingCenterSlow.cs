using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCenter
{

    public class ShoppingCenterSlow
    {
        private const string PRODUCT_ADDED = "Product added";
        private const string X_PRODUCTS_DELETED = " products deleted";
        private const string NO_PRODUCTS_FOUND = "No products found";
        private const string INCORRECT_COMMAND = "Incorrect command";

        private readonly List<Product> products = new List<Product>();

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
            this.products.Add(product);
            return PRODUCT_ADDED;
        }

        private string FindProductsByName(string name)
        {
            var products = this.products
                .Where(p => p.Name == name)
                .OrderBy(p => p);
            return PrintProducts(products);
        }

        private string FindProductsByProducer(string producer)
        {
            var products = this.products
                .Where(p => p.Producer == producer)
                .OrderBy(p => p);
            return PrintProducts(products);
        }

        private string FindProductsByPriceRange(string from, string to)
        {
            decimal rangeStart = decimal.Parse(from);
            decimal rangeEnd = decimal.Parse(to);
            var products = this.products
                .Where(p => p.Price >= rangeStart && p.Price <= rangeEnd)
                .OrderBy(p => p);
            return PrintProducts(products);
        }

        private string PrintProducts(IEnumerable<Product> products)
        {
            if (products.Any())
            {
                return string.Join(Environment.NewLine, products);
            }

            return NO_PRODUCTS_FOUND;
        }

        private string DeleteProductsByNameAndProducer(string name, string producer)
        {
            int countOfRemovedProducts =
                this.products.RemoveAll(p => p.Name == name && p.Producer == producer);
            if (countOfRemovedProducts > 0)
            {
                return countOfRemovedProducts + X_PRODUCTS_DELETED;
            }

            return NO_PRODUCTS_FOUND;
        }

        private string DeleteProductsByProducer(string producer)
        {
            int countOfRemovedProducts =
                this.products.RemoveAll(p => p.Producer == producer);
            if (countOfRemovedProducts > 0)
            {
                return countOfRemovedProducts + X_PRODUCTS_DELETED;
            }

            return NO_PRODUCTS_FOUND;
        }
    }
}
