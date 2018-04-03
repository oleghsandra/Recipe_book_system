using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Abstraction.UnitOfWork;
using RecipeBookSystem.DAL.Concrete.UnitOfWork;
using RecipeBookSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace RecipeBookSystem.BL.ModelProviders
{
    /// <summary>
    /// The class provides the opportunity to work with products from database
    /// </summary>
    public class ProductProvider
    {
        private IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductProvider"/> class.
        /// </summary>
        public ProductProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _productRepository = unitOfWork.ProductRepository;
        }
        
        /// <summary>
        /// Retrieves list of sorted and filtered products
        /// </summary>
        /// <param name="count">Count of products to retrieve</param>
        /// <param name="pageNumber">Page index</param>
        /// <param name="sortColumnName">Name of column to sort by</param>
        /// <param name="sortOrder">Sort order (asc/desc)</param>
        /// <param name="filterProductTypeId">Product type Id to filter by it</param>
        /// <returns>List of filtered and sorted products</returns>
        public IEnumerable<ProductModel> GetProducts(
            int count, 
            int pageNumber, 
            string sortColumnName = null,
            string sortOrder = null,
            int? filterProductTypeId = null)
        {
            try
            {
                return _productRepository.GetProducts(
                    count,
                    pageNumber,
                    sortColumnName,
                    sortOrder,
                    filterProductTypeId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting products: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Method removes product
        /// </summary>
        /// <param name="dishId">Id of product to delete</param>
        public void DeleteProduct(int productId)
        {
            try
            {
                _productRepository.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting product: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Updates available product in DB
        /// </summary>
        /// <param name="updateProductId">Product to update</param>
        public void UpdateProduct(ProductModel updateProductModel)
        {
            try
            {
                _productRepository.UpdateProduct(
                    updateProductModel.Id,
                    updateProductModel.Name,
                    updateProductModel.ProductTypeModel.Id,
                    updateProductModel.Proteins,
                    updateProductModel.Fats,
                    updateProductModel.Carbohydrates,
                    updateProductModel.SmallPhotoLink);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating product: " + ex.Message, ex);
            }
        }

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
        public void UpdateProduct(
            int updateProductId,
            string name,
            int productTypeId,
            float proteins,
            float fats,
            float carbohydrates,
            string smallPhotoLink = null)
        {
            try
            {
                _productRepository.UpdateProduct(
                    updateProductId,
                    name,
                    productTypeId,
                    proteins,
                    fats,
                    carbohydrates,
                    smallPhotoLink);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating product: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Adds new product to Data Base
        /// </summary>
        /// <param name="newProduct">New product model</param>
        public void AddProduct(ProductModel newProduct)
        { 
            try
            {
                _productRepository.AddProduct(newProduct);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding product: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Method searchs all products that begin from some name
        /// </summary>
        /// <param name="name">Name to search</param>
        /// <returns>List of product models that begin from "name"</returns>
        public IEnumerable<ProductModel> SearchProductByName(string name)
        {
            try
            {
                return _productRepository.SearchProductByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while searching product: " + ex.Message, ex);
            }
        }
    }
}
