using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Abstraction.UnitOfWork;
using RecipeBookSystem.DAL.Concrete.UnitOfWork;
using RecipeBookSystem.Model.Models;
using System.Configuration;

namespace RecipeBookSystem.BL.ModelProviders
{
    public class UserProvider
    {
        private IUserRepository _userRepository;

        public UserProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _userRepository = unitOfWork.UserRepository;
        }

        public UserModel GetUser(string email, string password)
        {
            var user = _userRepository.GetUser(email, password);

            return user;
        }

        public bool AddUser(UserModel user)
        {
            return _userRepository.AddUser(user);
        }
    }
}
