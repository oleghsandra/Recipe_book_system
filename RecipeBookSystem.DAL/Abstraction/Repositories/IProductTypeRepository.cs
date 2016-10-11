using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    public interface IProductTypeRepository : IGenericRepository<ProductTypeModel>
    {
        IEnumerable<ProductTypeModel> GetAllProductTypes();
    }
}
