using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    /// <summary>
    /// Declares methods for ProductTypeRepository class
    /// </summary>
    public interface IProductTypeRepository : IGenericRepository<ProductTypeModel>
    {
        /// <summary>
        /// Gets all types of products
        /// </summary>
        /// <returns>List of all available product types</returns>
        IEnumerable<ProductTypeModel> GetAllProductTypes();
    }
}
