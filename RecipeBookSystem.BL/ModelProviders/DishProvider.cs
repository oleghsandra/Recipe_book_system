using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Abstraction.UnitOfWork;
using RecipeBookSystem.DAL.Concrete.UnitOfWork;
using RecipeBookSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace RecipeBookSystem.BL.ModelProviders
{
    public class DishProvider
    {
        private IDishRepository _dishRepository;

        public DishProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _dishRepository = unitOfWork.DishRepository;
        }

        public IEnumerable<DishModel> GetUserDishes(int userId, int count, int pageNumber)
        {
            try
            {
                IEnumerable<DishModel> dishes;
                dishes = _dishRepository.GetUserDishes(userId, count, pageNumber);

                return dishes;
            }
            catch(Exception ex)
            {
                throw new Exception("error while getting dishes: " + ex.Message, ex);  
            }
        }

    }
}
