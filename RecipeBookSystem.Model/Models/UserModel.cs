using System.Collections.Generic;

namespace RecipeBookSystem.Model.Models
{
    /// <summary>
    /// The class that describes model of the user
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Identity of the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's email address 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User's private password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// List of the personal dishes
        /// </summary>
        public List<DishModel> Dishes { get; set; }
    }
}
