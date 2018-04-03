using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        public DishesController(DishProvider dishProvider, IngredientProvider ingredientProvider)
        {
            this.dishProvider = dishProvider;
            this.ingredientProvider = ingredientProvider;
        }

        protected DishProvider dishProvider;

        protected IngredientProvider ingredientProvider;

        // GET api/Dishes/GetProducts?count=10&pageNumber=1...
        [HttpGet]
        public IActionResult GetUserDishes(int userId, int count, int pageNumber, string name = null)
        {
            var result = this.dishProvider.GetUserDishes(userId, count, pageNumber, name);
            return Ok(result);
        }

        // POST api/Dishes/AddDish
        [HttpPost]
        public IActionResult AddDish(DishModel model)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var newDishId = dishProvider.AddDish(model);

                foreach (var ingredient in model.Ingredients)
                {
                    ingredient.DishId = newDishId;
                    ingredientProvider.AddIngredient(ingredient);
                }

                // The Complete method commits the transaction. If an exception has been thrown,
                // Complete is not  called and the transaction is rolled back.
                scope.Complete();
            }

            return Ok();
        }

        // POST api/Dishes/DeleteDish?dishId=5
        [HttpPost]
        public IActionResult DeleteDish(int dishId)
        {
            this.dishProvider.DeleteDish(dishId);
            return Ok();
        }
    }
}
