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

        /// <summary>
        /// Gets user from DB
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds new user to DB
        /// </summary>
        /// <param name="user">user to add</param>
        /// <returns>True - if the user does not exist and it has been
        /// successfully added, otherwise - false</returns>
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
