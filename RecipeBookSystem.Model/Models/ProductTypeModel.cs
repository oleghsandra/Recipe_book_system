namespace RecipeBookSystem.Model.Models
{
    /// <summary>
    /// The class that describes model of the product type
    /// </summary>
    public class ProductTypeModel
    {
        /// <summary>
        /// Identity of the product type
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the product type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Link on the small photo(icon) in the internet
        /// </summary>
        public string SmallPhotoLink { get; set; }

        /// <summary>
        /// Link on the big photo in the internet
        /// </summary>
        public string BigPhotoLink { get; set; }
    }
}
