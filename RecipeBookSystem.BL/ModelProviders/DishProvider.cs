using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Abstraction.UnitOfWork;
using RecipeBookSystem.DAL.Concrete.UnitOfWork;
using RecipeBookSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace RecipeBookSystem.BL.ModelProviders
{
    /// <summary>
    /// The class provides the opportunity to work with dishes from database
    /// </summary>
    public class DishProvider
    {
        private IDishRepository _dishRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DishProvider"/> class.
        /// </summary>
        public DishProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _dishRepository = unitOfWork.DishRepository;
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
            try
            {
                return _dishRepository.GetUserDishes(userId, count, pageNumber, name);
            }
            catch(Exception ex)
            {
                throw new Exception("error while getting dishes: " + ex.Message, ex);  
            }
        }

        /// <summary>
        /// Adds new user model to DB
        /// </summary>
        /// <param name="dish">Dish model to add</param>
        /// <returns>Id of new dish</returns>
        public int AddDish(DishModel dish)
        {
            try
            {
                return _dishRepository.AddDish(dish);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding dish: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Method removes dish
        /// </summary>
        /// <param name="dishId">Id of user to delete</param>
        public void DeleteDish(int dishId)
        {
            try
            {
                _dishRepository.DeleteDish(dishId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting dish: " + ex.Message, ex);
            }
        }
    }
}
