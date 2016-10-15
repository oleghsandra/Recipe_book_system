using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Concrete.Parsers;
using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Concrete.Repositories
{
    public class ProductTypeRepository : GenericRepository<ProductTypeModel>, IProductTypeRepository
    {
        public ProductTypeRepository(string connection)
            : base(connection)
        {

        }

        /// <summary>
        /// Gets all types of products
        /// </summary>
        /// <returns>List of all available product types</returns>
        public IEnumerable<ProductTypeModel> GetAllProductTypes()
        {
            var productTypes = base.ExecuteReader(StoredProcedureNames.spGetAllProductTypes,
                ProductTypeParser.MakeBuildingResult);

            return productTypes;

        }
    }
}
