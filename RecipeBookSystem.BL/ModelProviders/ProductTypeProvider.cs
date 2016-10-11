using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Abstraction.UnitOfWork;
using RecipeBookSystem.DAL.Concrete.UnitOfWork;
using RecipeBookSystem.Model.Models;
using System.Collections.Generic;
using System.Configuration;

namespace RecipeBookSystem.BL.ModelProviders
{
    public class ProductTypeProvider
    {
        private IProductTypeRepository _productTypeRepository;

        public ProductTypeProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _productTypeRepository = unitOfWork.ProductTypeRepository;
        }

        public IEnumerable<ProductTypeModel> GetAllProductTypes()
        {
            var productTypes = _productTypeRepository.GetAllProductTypes();

            return productTypes;
        }
    }
}