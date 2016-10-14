using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Concrete.Parsers;
using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public int AddDish(DishModel dish)
        {
            SqlParameter outputDishIdParam = new SqlParameter(StoredProcedureParameters.DishId, SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.OwnerId, dish.OwnerId),
                new SqlParameter(StoredProcedureParameters.Name, dish.Name),
                new SqlParameter(StoredProcedureParameters.CookingInstructions, dish.CookingInstructions),
                new SqlParameter(StoredProcedureParameters.SmallPhotoLink, dish.SmallPhotoLink),
                new SqlParameter(StoredProcedureParameters.BigPhotoLink, dish.BigPhotoLink),
                outputDishIdParam
            };
            
            base.ExecuteReader(StoredProcedureNames.spAddDish, null, parameters);

            return Convert.ToInt32(outputDishIdParam.Value.ToString());
        }

    }
}
