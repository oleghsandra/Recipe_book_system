namespace RecipeBookSystem.DAL.Concrete.SQL
{
    /// <summary>
    /// Class that contains parameters to all
    /// stored procedures in data base.
    /// </summary>
    public static class StoredProcedureParameters
    {
        //Common paramerets
        public const string Name = ColumnNames.Name;

        //Paramerets for product SP
        public const string ProductId = ColumnNames.ProductId;
        public const string UpdateProductId = "UpdateProductId";
        public const string ProductTypeId = "ProductTypeId";
        public const string Proteins = ColumnNames.Proteins;
        public const string Fats = ColumnNames.Fats;
        public const string Carbohydrates = ColumnNames.Carbohydrates;
        public const string ProductTypeName = ColumnNames.ProductTypeName;
        public const string ProductCount = "ProductCount";
        public const string PageNumber = "PageNumber";
        public const string SortColumn = "SortColumn";
        public const string SortOrder = "SortOrder";
        public const string FilterProductTypeId = "FilterProductTypeId";
        public const string FilterBestMealTimeId = "FilterBestMealTimeId";
        public const string SmallPhotoLink = ColumnNames.SmallPhotoLink;
        public const string BigPhotoLink = ColumnNames.BigPhotoLink;

        //Paramerets for user SP
        public const string Email = ColumnNames.Email;
        public const string Password = ColumnNames.Password;

        //Paramerets for ingredient SP
        public const string DishId = ColumnNames.DishId;
        public const string IngredientId = ColumnNames.IngredientId;
        public const string Weight = ColumnNames.Weight;

        //Paramerets for dish SP
        public const string OwnerId = "OwnerId";
        public const string DishCount = "DishCount";
        public const string CookingInstructions = ColumnNames.CookingInstructions;
        
    }
}
