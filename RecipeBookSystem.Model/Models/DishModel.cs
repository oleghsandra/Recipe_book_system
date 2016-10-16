using System.Collections.Generic;

namespace RecipeBookSystem.Model.Models
{
    /// <summary>
    /// The class that describes model of the dish
    /// </summary>
    public class DishModel
    {
        /// <summary>
        /// Identity of the dish
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the dish
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identity of user that has the dish
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Description of cooking proccess
        /// </summary>
        public string CookingInstructions { get; set; }

        /// <summary>
        /// Link on the small photo(icon) in the internet
        /// </summary>
        public string SmallPhotoLink { get; set; }

        /// <summary>
        /// Link on the big photo in the internet
        /// </summary>
        public string BigPhotoLink { get; set; }

        /// <summary>
        /// List of the included ingredients
        /// </summary>
        public List<IngredientModel> Ingredients { get; set; }
    }
}
