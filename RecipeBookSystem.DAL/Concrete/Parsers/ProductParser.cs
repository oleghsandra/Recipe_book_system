using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Concrete.Parsers
{
    public static class ProductParser
    {
        public static ProductModel MakeBuildingResult(SqlDataReader reader)
        {
            var model = new ProductModel();
            model.ProductTypeModel = new ProductTypeModel();

            model.Id = reader.Get<int>(ColumnNames.ProductId);
            model.Proteins = reader.Get<float>(ColumnNames.Proteins);
            model.ProductTypeModel.Id = reader.Get<int>(ColumnNames.ProductTypeId);
            model.Fats = reader.Get<float>(ColumnNames.Fats);
            model.Carbohydrates = reader.Get<float>(ColumnNames.Carbohydrates);
            model.ProductTypeModel.Name = reader.Get<string>(ColumnNames.ProductTypeName);
            model.Name = reader.Get<string>(ColumnNames.Name);
            model.SmallPhotoLink = reader.Get<string>(ColumnNames.SmallPhotoLink);
            model.BigPhotoLink = reader.Get<string>(ColumnNames.BigPhotoLink);

            return model;
        }
    }
}
