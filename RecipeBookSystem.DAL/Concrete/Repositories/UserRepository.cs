using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Concrete.Parsers;
using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System.Data.SqlClient;
using System.Linq;

namespace RecipeBookSystem.DAL.Concrete.Repositories
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(string connection)
            : base(connection)
        {

        }

        public UserModel GetUser(string email, string password)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.Email, email),
                new SqlParameter(StoredProcedureParameters.Password, password)
            };

            var user = base.ExecuteReader(StoredProcedureNames.spGetUser,
                UserParser.MakeBuildingResult, parameters).ToList();

            if (user.Count == 0)
            {
                return null;
            }
            else
            {
                return user.First();
            }

        }

        public bool AddUser(UserModel user)
        {
            var existedUser = GetUser(user.Email, user.Password);

            if (existedUser != null)
            {
                return false;
            }
            else
            {
                var parameters = new[]
                {
                    new SqlParameter(StoredProcedureParameters.Name, user.Name),
                    new SqlParameter(StoredProcedureParameters.Email, user.Email),
                    new SqlParameter(StoredProcedureParameters.Password, user.Password)
            };
                base.ExecuteReader(StoredProcedureNames.spAddUser, null, parameters);
            }
            return true;
        }
    }
}
