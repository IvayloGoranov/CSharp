using System;

namespace P3CollectionOfProducts
{
    public class CollectionOfProducts
    {
        public static void Main()
        {
            var products = new ProductCollection();
            products.AddProduct(1, "apple", "United Fruit Company", 1.40m);
            Console.WriteLine("Added a product. Count = " + products.Count);

            products.AddProduct(2, "apple", "United Fruit Company", 1.49m);
            Console.WriteLine("Added a product. Count = " + products.Count);

            products.AddProduct(3, "banana", "Dole", 2.40m);
            Console.WriteLine("Added a product. Count = " + products.Count);

            products.AddProduct(4, "orange", "Greek Oranges", 1.00m);
            Console.WriteLine("Added a product. Count = " + products.Count);

            products.AddProduct(5, "apple", "United Fruit Company", 1.51m);
            Console.WriteLine("Added a product. Count = " + products.Count);

            bool isExistingProductRemoved = products.Remove(2);
            Console.WriteLine("Existing product removed successfully: " + isExistingProductRemoved);
            Console.WriteLine("Count = " + products.Count);

            bool isNonExistingProductRemoved = products.Remove(2);
            Console.WriteLine("Non existing product removed successfully: " + isNonExistingProductRemoved);
            Console.WriteLine("Count = " + products.Count);

            var productsInPriceRange = products.FindProducts(1m, 2m);
            Console.WriteLine("Products in price range[1..2]: {0}", string.Join("\r\n", productsInPriceRange));


            var productsByTitle = products.FindProducts("apple");
            Console.WriteLine("Products by title (apple): {0}", string.Join("\r\n", productsByTitle));

            var productsByTitleAndPrice = products.FindProducts("apple", 1.51m);
            Console.WriteLine("Products by title (apple) and price(1.51): {0}", string.Join("\r\n", productsByTitleAndPrice));

            var productsByTitleInPriceRange = products.FindProducts("apple", 1m, 1.49m);
            Console.WriteLine("Products by title (apple) in price range[1..1.49]: {0}", 
                string.Join("\r\n", productsByTitleInPriceRange));
        }
    }
}
