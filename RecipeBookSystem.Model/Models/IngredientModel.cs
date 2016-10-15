namespace RecipeBookSystem.Model.Models
{
    /// <summary>
    /// The class that describes model of the ingredient
    /// </summary>
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
        /// Name of the product that is ingredient
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Weight of Product that includes in the dish
        /// </summary>
        public double Weight { get; set; }
    }
}
