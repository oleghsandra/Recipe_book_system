using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Concrete.Parsers
{
    public static class ProductTypeParser
    {
        public static ProductTypeModel MakeBuildingResult(SqlDataReader reader)
        {
            var model = new ProductTypeModel();

            model.Id = reader.Get<int>(ColumnNames.ProductTypeId);
            model.Name = reader.Get<string>(ColumnNames.Name);
            model.SmallPhotoLink = reader.Get<string>(ColumnNames.SmallPhotoLink);
            model.BigPhotoLink = reader.Get<string>(ColumnNames.BigPhotoLink);

            return model;
        }
    }
}
