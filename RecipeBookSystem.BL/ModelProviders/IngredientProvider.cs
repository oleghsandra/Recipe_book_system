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
    /// The class provides the opportunity to work with ingredients from database
    /// </summary>
    public class IngredientProvider
    {
        private IIngredientRepository _ingredientRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientProvider"/> class.
        /// </summary>
        public IngredientProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _ingredientRepository = unitOfWork.IngredientRepository;
        }

        /// <summary>
        /// Method gets all ingredients of some dish
        /// </summary>
        /// <param name="dishId">Id of the dish, that contains ingredients</param>
        /// <returns>List of <IngredientModel></returns>
        public IEnumerable<IngredientModel> GetIngredients(int dishId)
        {
            try
            {
                return _ingredientRepository.GetIngredients(dishId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting ingredients: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Method adds new ingredient to Data Base
        /// </summary>
        /// <param name="ingredient">Ingredient to add</param>
        public void AddIngredient(IngredientModel ingredient)
        {
            try
            {
                _ingredientRepository.AddIngredient(ingredient);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding ingredient: " + ex.Message, ex);
            }
        }
    }
}
