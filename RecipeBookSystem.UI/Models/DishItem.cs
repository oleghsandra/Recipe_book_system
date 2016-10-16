using RecipeBookSystem.Model.Models;
using System.Collections.Generic;
using System.Drawing;

namespace RecipeBookSystem.UI.Models
{
    class DishItem
    {
        /// <summary>
        /// Gets the dish model
        /// </summary>
        public DishModel DishModel
        {
            get;
            private set;
        }

        /// <summary>
        /// Image of item
        /// </summary>
        public Bitmap Image { get; set; }

        /// <summary>
        /// Gets or sets ingredients contained in the dish
        /// </summary>
        public List<IngredientModel> Ingredients { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DishModel"/> class.
        /// </summary>
        /// <param name="dishModel">Dish info model</param>
        public DishItem(DishModel dishModel)
        {
            this.DishModel = dishModel;
        }
    }
}
