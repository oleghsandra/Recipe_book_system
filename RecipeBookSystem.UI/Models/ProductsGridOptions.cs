namespace RecipeBookSystem.UI.Models
{
    class ProductsGridOptions
    {
        public int ItemsCount { get; set; }
        public int PageNumber { get; set; }
        public string SortColumnName { get; set; }
        public string SortOrder { get; set; }
        public int? FilterProductTypeId { get; set; }
    }
}
