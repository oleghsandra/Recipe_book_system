using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    /// <summary>
    /// Declares methods for UserRepository class
    /// </summary>
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        /// <summary>
        /// Gets user from DB
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns></returns>
        UserModel GetUser(string email, string password);

        /// <summary>
        /// Adds new user to DB
        /// </summary>
        /// <param name="user">user to add</param>
        /// <returns>True - if the user does not exist and it has been
        /// successfully added, otherwise - false</returns>
        bool AddUser(UserModel user);
    }
}
