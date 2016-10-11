using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Abstraction.UnitOfWork;
using RecipeBookSystem.DAL.Concrete.UnitOfWork;
using RecipeBookSystem.Model.Models;
using System.Collections.Generic;
using System.Configuration;

namespace RecipeBookSystem.BL.ModelProviders
{
    public class ProductProvider
    {
        private IProductRepository _productRepository;

        public ProductProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _productRepository = unitOfWork.ProductRepository;
        }

        public IEnumerable<ProductModel> GetProducts(
            int count, 
            int pageNumber, 
            string sortColumnName = null,
            string sortOrder = null,
            int? filterProductTypeId = null)
        {
            var products = _productRepository.GetProducts(count, pageNumber, sortColumnName, sortOrder, filterProductTypeId);

            return products;
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }
    }
}
