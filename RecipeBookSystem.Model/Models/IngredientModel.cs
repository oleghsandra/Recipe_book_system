namespace RecipeBookSystem.Model.Models
{
    public class IngredientModel
    {
        /// <summary>
        /// Identity of the Ingredient
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identity of Dish that contains the ingredient
        /// </summary>
        public int DishId { get; set; }

        /// <summary>
        /// Identity of Product that includes in the dish
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Weight of Product that includes in the dish
        /// </summary>
        public double Weight { get; set; }
    }
}
