using System.Web.Http;
using RecipeBookSystem.BL.Helpers;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.API.Controllers
{
    public class UsersController : ApiController
    {
        public UsersController(/*UserProvider userProvider*/)
        {
            this.userProvider = new UserProvider();
        }

        protected UserProvider userProvider;

        // GET api/Users/GetUser?login=oleg&password=1234...
        [HttpGet]
        public UserModel GetUser(string login, string password)
        {
            var result = this.userProvider.GetUser(login, PasswordEncryptionProvider.EncryptPassword(password));
            return result;
        }

        // POST api/Users
        [HttpGet]
        public void AddUser(UserModel model)
        {
            this.userProvider.AddUser(model);
        }
    }
}
