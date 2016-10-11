using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Abstraction.UnitOfWork;
using RecipeBookSystem.DAL.Concrete.UnitOfWork;
using RecipeBookSystem.Model.Models;
using System.Collections.Generic;
using System.Configuration;

namespace RecipeBookSystem.BL.ModelProviders
{
    public class IngredientProvider
    {
        private IIngredientRepository _ingredientRepository;

        public IngredientProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _ingredientRepository = unitOfWork.IngredientRepository;
        }

        public IEnumerable<IngredientModel> GetIngredients(int dishId)
        {
            var ingredients = _ingredientRepository.GetIngredients(dishId);

            return ingredients;
        }
    }
}
