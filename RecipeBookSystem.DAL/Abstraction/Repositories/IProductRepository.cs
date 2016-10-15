using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    /// <summary>
    /// Declares methods for ProductRepository class
    /// </summary>
    public interface IProductRepository : IGenericRepository<ProductModel>
    {
        /// <summary>
        /// Retrieves list of sorted and filtered products
        /// </summary>
        /// <param name="count">Count of products to retrieve</param>
        /// <param name="pageNumber">Page index</param>
        /// <param name="sortColumnName">Name of column to sort by</param>
        /// <param name="sortOrder">Sort order (asc/desc)</param>
        /// <param name="filterProductTypeId">Product type Id to filter by it</param>
        /// <returns>List of filtered and sorted products</returns>
        IEnumerable<ProductModel> GetProducts(
            int count,
            int pageNumber, 
            string sortColumnName = null,
            string sortOrder = null, 
            int? filterProductTypeId = null);

        /// <summary>
        /// Method removes product
        /// </summary>
        /// <param name="dishId">Id of product to delete</param>
        void DeleteProduct(int productId);

        /// <summary>
        /// Updates available product in DB
        /// </summary>
        /// <param name="updateProductId">Id of the product to update</param>
        /// <param name="name">New name of the product</param>
        /// <param name="productTypeId">New product type id of the product</param>
        /// <param name="proteins">New proteins value of the product</param>
        /// <param name="fats">New fsts value of the product</param>
        /// <param name="carbohydrates">New carbohybrades value of the product</param>
        /// <param name="smallPhotoLink">New image link of the product</param>
        void UpdateProduct(
            int updateProductId,
            string name,
            int productTypeId,
            float proteins,
            float fats,
            float carbohydrates,
            string smallPhotoLink);

        /// <summary>
        /// Adds new product to Data Base
        /// </summary>
        /// <param name="newProduct">New product model</param>
        void AddProduct(ProductModel newProduct);

        /// <summary>
        /// Method searchs all products that begin from some name
        /// </summary>
        /// <param name="name">Name to search</param>
        /// <returns>List of product models that begin from "name"</returns>
        IEnumerable<ProductModel> SearchProductByName(string name);
    }
}
