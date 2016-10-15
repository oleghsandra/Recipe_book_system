using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    /// <summary>
    /// Declares methods for IngredientRepository class
    /// </summary>
    public interface IIngredientRepository : IGenericRepository<IngredientModel>
    {
        /// <summary>
        /// Method gets all ingredients of some dish
        /// </summary>
        /// <param name="dishId">Id of the dish, that contains ingredients</param>
        /// <returns>List of <IngredientModel></returns>
        IEnumerable<IngredientModel> GetIngredients(int dishId);

        /// <summary>
        /// Method adds new ingredient to Data Base
        /// </summary>
        /// <param name="ingredient">Ingredient to add</param>
        void AddIngredient(IngredientModel ingredient);
    }
}
