using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductModel>
    {
        IEnumerable<ProductModel> GetProducts(
            int count,
            int pageNumber, 
            string sortColumnName = null,
            string sortOrder = null, 
            int? filterProductTypeId = null);

        void DeleteProduct(int productId);
    }
}
