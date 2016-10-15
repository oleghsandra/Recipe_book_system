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

        /// <summary>
        /// Executes database query
        /// </summary>
        /// <param name="spName">Name of the SP</param>
        /// <param name="callback">Function for parsing results</param>
        /// <param name="parameters">Parameters for executing queury</param>
        /// <returns>List of <TEntity></returns>
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

        public void AddIngredient(IngredientModel ingredient)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.DishId, ingredient.DishId),
                new SqlParameter(StoredProcedureParameters.ProductId, ingredient.ProductId),
                new SqlParameter(StoredProcedureParameters.Weight, ingredient.Weight),
            };

            base.ExecuteReader(StoredProcedureNames.spAddDishIngredients, null, parameters);
        }
    }
}
