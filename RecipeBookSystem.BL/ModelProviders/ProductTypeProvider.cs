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
    /// The class provides the opportunity to work with product types from database
    /// </summary>
    public class ProductTypeProvider
    {
        private IProductTypeRepository _productTypeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeProvider"/> class.
        /// </summary>
        public ProductTypeProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _productTypeRepository = unitOfWork.ProductTypeRepository;
        }

        /// <summary>
        /// Gets all types of products
        /// </summary>
        /// <returns>List of all available product types</returns>
        public IEnumerable<ProductTypeModel> GetAllProductTypes()
        {
            try
            {
                return _productTypeRepository.GetAllProductTypes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while  geting all product types: " + ex.Message, ex);
            }
        }
    }
}