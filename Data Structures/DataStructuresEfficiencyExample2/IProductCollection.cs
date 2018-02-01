using System.Collections.Generic;

namespace P3CollectionOfProducts
{
    public interface IProductCollection
    {
        /// <summary>
        /// Adds a new product to the collection. 
        /// If the id already exists, the new product replaces the old one and the method returns false.
        /// If the id does not exist in the collection, the new product is added to the collection and the method returns true.
        /// </summary>
        bool AddProduct(int id, string title, string supplier, decimal price);

        /// <summary>
        /// The number of products in the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Removes a product from the collection by id. If successfully removed, the method returns true, otherwise - false. 
        /// </summary>
        bool Remove(int id);

        /// <summary>
        /// Finds products in given price range. The products are sorted by id.
        /// </summary>
        IEnumerable<Product> FindProducts(decimal startPrice, decimal endPrice);
        
        /// <summary>
        /// Finds products by title. The products are sorted by id.
        /// </summary>
        IEnumerable<Product> FindProducts(string title);

        /// <summary>
        /// Finds products by title as first search criteria and price as second. The products are sorted by id.
        /// </summary>
        IEnumerable<Product> FindProducts(string title, decimal price);

        /// <summary>
        /// Finds products in given price range corresponding to a certain title. The products are sorted by id.
        /// </summary>
        IEnumerable<Product> FindProducts(string title, decimal startPrice, decimal endPrice);

        /// <summary>
        /// Finds products by supplier as first search criteria and price as second. The products are sorted by id.
        /// </summary>
        IEnumerable<Product> FindProductsBySupplier(string supplier, decimal price);

        /// <summary>
        /// Finds products in given price range corresponding to a certain supplier. The products are sorted by id.
        /// </summary>
        IEnumerable<Product> FindProductsBySupplier(string supplier, decimal startPrice, decimal endPrice);
    }
}
