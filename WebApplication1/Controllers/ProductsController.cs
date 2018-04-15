using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ApiController
    {
        public ProductsController(ProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }

        protected ProductProvider productProvider;

        // GET api/Products/GetProducts?count=10&pageNumber=1...
        [HttpGet]
        public HttpResponseMessage GetProducts(
            int count,
            int pageNumber,
            string sortColumnName = null,
            string sortOrder = null,
            int? filterProductTypeId = null)
        {
            var result = this.productProvider.GetProducts(count, pageNumber, sortColumnName, sortOrder, filterProductTypeId);
            return Json(result);
        }

        // GET api/Products/SearchProductByName?name=apple
        [HttpGet]
        public HttpResponseMessage SearchProductByName(string name)
        {
            var result = this.productProvider.SearchProductByName(name);
            return result;
        }

        // POST api/Products
        [HttpPost]
        public IActionResult AddProduct(ProductModel model)
        {
            this.productProvider.AddProduct(model);
            return Ok();
        }

        // POST api/Products/DeleteProduct?productId=5
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            this.productProvider.DeleteProduct(productId);
            return Ok();
        }
    }
}
