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

        /// <summary>
        /// Gets dishes for some user
        /// </summary>
        /// <param name="userId">Owner id</param>
        /// <param name="count">Count of products to retrieve</param>
        /// <param name="pageNumber">Page index</param>
        /// <param name="name">Name for searching</param>
        /// <returns>List of dishes</returns>
        public IEnumerable<DishModel> GetUserDishes(int userId, int count, int pageNumber, string name = null)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.OwnerId, userId),
                new SqlParameter(StoredProcedureParameters.DishCount, count),
                new SqlParameter(StoredProcedureParameters.PageNumber, pageNumber),
                new SqlParameter(StoredProcedureParameters.Name, name)
            };

            var dishIngredients = base.ExecuteReader(StoredProcedureNames.spGetUserDishes,
                DishParser.MakeBuildingResult, parameters);

            return dishIngredients;
        }

        /// <summary>
        /// Adds new user model to DB
        /// </summary>
        /// <param name="dish">Dish model to add</param>
        /// <returns>Id of new dish</returns>
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

        /// <summary>
        /// Method removes dish
        /// </summary>
        /// <param name="dishId">Id of user to delete</param>
        public void DeleteDish(int dishId)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.DishId, dishId)
            };

            base.ExecuteReader(StoredProcedureNames.spDeleteDish, null, parameters);
        }
    }
}
