using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Concrete.Parsers
{
    public static class IngredientParser
    {
        public static IngredientModel MakeBuildingResult(SqlDataReader reader)
        {
            var model = new IngredientModel();

            model.Id = reader.Get<int>(ColumnNames.IngredientId);
            model.DishId = reader.Get<int>(ColumnNames.DishId);
            model.ProductId = reader.Get<int>(ColumnNames.ProductId);
            model.ProductName = reader.Get<string>(ColumnNames.Name);
            model.Weight = reader.Get<float>(ColumnNames.Weight);

            return model;
        }
    }
}
