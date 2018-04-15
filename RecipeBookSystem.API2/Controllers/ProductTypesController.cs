using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.API.Controllers
{
    public class ProductTypesController : ApiController
    {
        public ProductTypesController(/*ProductTypeProvider productTypeProvider*/)
        {
            this.productTypeProvider = new ProductTypeProvider();
        }

        protected ProductTypeProvider productTypeProvider;

        // GET api/ProductTypes/GetAllProductTypes
        [HttpGet]
        public List<ProductTypeModel> GetAllProductTypes()
        {
            var result = this.productTypeProvider.GetAllProductTypes().ToList();
            return result;
        }
    }
}
