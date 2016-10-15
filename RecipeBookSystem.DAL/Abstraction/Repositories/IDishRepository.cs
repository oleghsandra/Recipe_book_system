using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    /// <summary>
    /// Declares methods for DishRepository class
    /// </summary>
    public interface IDishRepository : IGenericRepository<DishModel>
    {
        /// <summary>
        /// Gets dishes for some user
        /// </summary>
        /// <param name="userId">Owner id</param>
        /// <param name="count">Count of products to retrieve</param>
        /// <param name="pageNumber">Page index</param>
        /// <param name="name">Name for searching</param>
        /// <returns>List of dishes</returns>
        IEnumerable<DishModel> GetUserDishes(int userId, int count, int pageNumber, string name = null);

        /// <summary>
        /// Adds new user model to DB
        /// </summary>
        /// <param name="dish">Dish model to add</param>
        /// <returns>Id of new dish</returns>
        int AddDish(DishModel dish);

        /// <summary>
        /// Method removes dish
        /// </summary>
        /// <param name="dishId">Id of user to delete</param>
        void DeleteDish(int dishId);
    }
}
