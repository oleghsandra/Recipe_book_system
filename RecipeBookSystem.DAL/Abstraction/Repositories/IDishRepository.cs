using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    public interface IDishRepository : IGenericRepository<DishModel>
    {
        IEnumerable<DishModel> GetUserDishes(int userId, int count, int pageNumber);
    }
}
