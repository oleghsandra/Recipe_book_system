using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Concrete.Parsers
{
    public static class UserParser
    {
        public static UserModel MakeBuildingResult(SqlDataReader reader)
        {
            var model = new UserModel();

            model.Id = reader.Get<int>(ColumnNames.UserId);
            model.Name = reader.Get<string>(ColumnNames.Name);
            model.Email = reader.Get<string>(ColumnNames.Email);
            model.Password = reader.Get<string>(ColumnNames.Password);

            return model;
        }
    }
}
