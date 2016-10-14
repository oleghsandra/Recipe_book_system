using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Concrete.Parsers;
using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Concrete.Repositories
{
    public class DishRepository : GenericRepository<DishModel>, IDishRepository
    {
        public DishRepository(string connection)
            : base(connection)
        {

        }

        public IEnumerable<DishModel> GetUserDishes(int userId, int count, int pageNumber)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.OwnerId, userId),
                new SqlParameter(StoredProcedureParameters.DishCount, count),
                new SqlParameter(StoredProcedureParameters.PageNumber, pageNumber)
            };

            var dishIngredients = base.ExecuteReader(StoredProcedureNames.spGetUserDishes,
                DishParser.MakeBuildingResult, parameters);

            return dishIngredients;
        }
        
    }
}
