namespace RecipeBookSystem.UI.Models
{
    /// <summary>
    /// Class contains fields as parameters
    /// to getting product stored procedures
    /// </summary>
    public class ProductsGridOptions
    {
        /// <summary>
        /// Name to search
        /// </summary>
        public string searchProductName { get; set; }

        /// <summary>
        /// Target count of items
        /// </summary>
        public int ItemsCount { get; set; }

        /// <summary>
        /// Target page
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Sorted column name
        /// </summary>
        public string SortColumnName { get; set; }

        /// <summary>
        /// Asc or desc sort order
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Id of type to filter 
        /// </summary>
        public int? FilterProductTypeId { get; set; }
    }
}
