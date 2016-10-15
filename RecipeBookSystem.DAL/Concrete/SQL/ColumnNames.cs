namespace RecipeBookSystem.DAL.Concrete.SQL
{
    /// <summary>
    /// Class that contains all names of all 
    /// tables in Data Base
    /// </summary>
    public static class ColumnNames
    {
        public const string Name = "Name";

        //Products table
        public const string ProductId = "ProductId";
        public const string Proteins = "Proteins";
        public const string Fats = "Fats";
        public const string Carbohydrates = "Carbohydrates";
        public const string ProductTypeName = "ProductTypeName";
        public const string SmallPhotoLink = "SmallPhotoLink";
        public const string BigPhotoLink = "BigPhotoLink";

        //Users table
        public const string UserId = "UserId";
        public const string Email = "Email";
        public const string Password = "Password";

        //Ingredients table
        public const string IngredientId = "IngredientId";
        public const string Weight = "Weight";

        //Dish table
        public const string DishId = "DishId";
        public const string CookingInstructions = "CookingInstructions";
       
        //Product type table
        public const string ProductTypeId = "ProductTypeId";
    }
}
