namespace RecipeBookSystem.UI.Models
{
    /// <summary>
    /// Class contains fields as parameters
    /// to getting dishes stored procedure
    /// </summary>
    public class DishGridOptions
    {
        /// <summary>
        /// Name to search
        /// </summary>
        public string DishName { get; set; }

        /// <summary>
        /// Target count of items
        /// </summary>
        public int ItemsCount { get; set; }

        /// <summary>
        /// Target page
        /// </summary>
        public int PageNumber { get; set; }
    }
}
