using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    public interface IIngredientRepository : IGenericRepository<IngredientModel>
    {
        IEnumerable<IngredientModel> GetIngredients(int dishId);
    }
}
