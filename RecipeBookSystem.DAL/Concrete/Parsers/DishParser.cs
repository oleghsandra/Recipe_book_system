using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Concrete.Parsers
{
    public static class DishParser
    {
        public static DishModel MakeBuildingResult(SqlDataReader reader)
        {
            var model = new DishModel();

            model.Id = reader.Get<int>(ColumnNames.DishId);
            model.Name = reader.Get<string>(ColumnNames.Name);
            model.CookingInstructions = reader.Get<string>(ColumnNames.CookingInstructions);
            model.SmallPhotoLink = reader.Get<string>(ColumnNames.SmallPhotoLink);
            model.BigPhotoLink = reader.Get<string>(ColumnNames.BigPhotoLink);

            return model;
        }
    }
}
