namespace RecipeBookSystem.UI.Models
{
    public class ProductsGridOptions
    {
        public string searchProductName { get; set; }
        public int ItemsCount { get; set; }
        public int PageNumber { get; set; }
        public string SortColumnName { get; set; }
        public string SortOrder { get; set; }
        public int? FilterProductTypeId { get; set; }
    }
}
