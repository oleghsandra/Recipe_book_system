namespace RecipeBookSystem.Model.Models
{
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
    }
}
