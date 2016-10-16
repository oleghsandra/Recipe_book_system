namespace RecipeBookSystem.Model.Models
{
    /// <summary>
    /// The class that describes model of the product
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Identity of the Product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of the product
        /// </summary>
        public ProductTypeModel ProductTypeModel { get; set; }
        
        /// <summary>
        /// Weight of proteins that contains in this product
        /// </summary>
        public float Proteins { get; set; }

        /// <summary>
        /// Weight of fats that contains in this product
        /// </summary>
        public float Fats { get; set; }

        /// <summary>
        /// Weight of carbohydrates that contains in this product
        /// </summary>
        public float Carbohydrates { get; set; }

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
