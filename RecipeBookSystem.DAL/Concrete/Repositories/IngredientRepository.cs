using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Concrete.Parsers;
using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Concrete.Repositories
{
    public class IngredientRepository : GenericRepository<IngredientModel>, IIngredientRepository
    {
        public IngredientRepository(string connection)
            : base(connection)
        {

        }

        public IEnumerable<IngredientModel> GetIngredients(int dishId)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.DishId, dishId),
            };

            var dishIngredients = base.ExecuteReader(StoredProcedureNames.spGetDishIngredients,
                IngredientParser.MakeBuildingResult, parameters);

            return dishIngredients;
        }
    }
}
