namespace RecipeBookSystem.DAL.Concrete.SQL
{
    public class StoredProcedureParameters
    {
        //Common paramerets
        public const string Name = ColumnNames.Name;

        //Paramerets for getting product stored procedure
        public const string ProductId = ColumnNames.ProductId;
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

        //Paramerets for getting user stored procedure
        public const string Email = ColumnNames.Email;
        public const string Password = ColumnNames.Password;

        //Paramerets for getting ingredient stored procedure
        public const string DishId = ColumnNames.DishId;
        public const string IngredientId = ColumnNames.IngredientId;
        public const string Weight = ColumnNames.Weight;

        public const string OwnerId = "OwnerId";
    }
}
