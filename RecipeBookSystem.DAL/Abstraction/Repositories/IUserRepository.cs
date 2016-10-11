using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        UserModel GetUser(string email, string password);

        bool AddUser(UserModel user);
    }
}
