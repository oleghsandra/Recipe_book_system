using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductTypesController : Controller
    {
        public ProductTypesController(ProductTypeProvider productTypeProvider)
        {
            this.productTypeProvider = productTypeProvider;
        }

        protected ProductTypeProvider productTypeProvider;

        // GET api/ProductTypes/GetAllProductTypes
        [HttpGet]
        public IActionResult GetAllProductTypes()
        {
            var result = this.productTypeProvider.GetAllProductTypes();
            return Ok(result);
        }
    }
}
