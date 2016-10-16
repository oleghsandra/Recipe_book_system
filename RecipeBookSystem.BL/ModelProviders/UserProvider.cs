using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Abstraction.UnitOfWork;
using RecipeBookSystem.DAL.Concrete.UnitOfWork;
using RecipeBookSystem.Model.Models;
using System;
using System.Configuration;

namespace RecipeBookSystem.BL.ModelProviders
{
    /// <summary>
    /// The class provides the opportunity to work with users from database
    /// </summary>
    public class UserProvider
    {
        private IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProvider"/> class.
        /// </summary>
        public UserProvider()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _userRepository = unitOfWork.UserRepository;
        }

        /// <summary>
        /// Gets user from DB
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns></returns>
        public UserModel GetUser(string email, string password)
        {
            try
            {
                return _userRepository.GetUser(email, password);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while geting user: " + ex.Message, ex);
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
            try
            {
                return _userRepository.AddUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding user: " + ex.Message, ex);
            }
        }
    }
}
