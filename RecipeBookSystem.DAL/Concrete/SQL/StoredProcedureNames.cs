namespace RecipeBookSystem.DAL.Concrete.SQL
{
    /// <summary>
    /// Class that contains names of the all
    /// stored procedures in the data base.
    /// </summary>
    public static class StoredProcedureNames
    {
        //Users SP
        public const string spAddUser = "[dbo].[spUsers_Add]";
        public const string spGetUser = "[dbo].[spUser_Get]";

        //Prodcut SP
        public const string spAddProduct = "[dbo].[spProduct_AddNew]";
        public const string spGetProduct = "[dbo].[spProduct_Get]";
        public const string spUpdateProduct = "[dbo].[spProduct_Update]";
        public const string spGetProductById = "[dbo].[sp_Product_GetById]";
        public const string spSearchProductByName = "[dbo].[spProduct_SearchByName]";
        public const string spDeleteProduct = "[dbo].[spProduct_Delete]";

        //Dish SP
        public const string spAddDish = "[dbo].[spDish_Add]";
        public const string spGetUserDishes = "[dbo].[spDishes_Get]";
        public const string spDeleteDish = "[dbo].[spDish_Delete]";

        //Ingredients SP
        public const string spAddDishIngredients = "[dbo].[spIngredient_Add]";
        public const string spGetDishIngredients = "[dbo].[spDishIngrediends_Get]";

        //ProductTypes SP
        public const string spGetAllProductTypes = "[dbo].[spProductType_GetAll]";
    }
}

