using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.API.Controllers
{
    public class DishesController : ApiController
    {
        public DishesController(/*DishProvider dishProvider, IngredientProvider ingredientProvider*/)
        {
            this.dishProvider = new DishProvider();
            this.ingredientProvider = new IngredientProvider();
        }

        protected DishProvider dishProvider;

        protected IngredientProvider ingredientProvider;

        // GET api/Dishes/GetProducts?count=10&pageNumber=1...
        [HttpGet]
        public List<DishModel> GetUserDishes(int userId, int count, int pageNumber, string name = null)
        {
            var result = this.dishProvider.GetUserDishes(userId, count, pageNumber, name).ToList();
            return result;
        }

        // POST api/Dishes/AddDish
        [HttpPost]
        public void AddDish(DishModel model)
        {
            var newDishId = dishProvider.AddDish(model);
            foreach (var ingredient in model.Ingredients)
            {
                ingredient.DishId = newDishId;
                ingredientProvider.AddIngredient(ingredient);
            }
        }

        // POST api/Dishes/DeleteDish?dishId=5
        [HttpPost]
        public void DeleteDish(int dishId)
        {
            this.dishProvider.DeleteDish(dishId);
        }
    }
}
