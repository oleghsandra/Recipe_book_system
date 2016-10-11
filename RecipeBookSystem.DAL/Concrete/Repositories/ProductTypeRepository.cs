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

        public IEnumerable<ProductTypeModel> GetAllProductTypes()
        {
            var productTypes = base.ExecuteReader(StoredProcedureNames.spGetAllProductTypes,
                ProductTypeParser.MakeBuildingResult);

            return productTypes;

        }
    }
}
