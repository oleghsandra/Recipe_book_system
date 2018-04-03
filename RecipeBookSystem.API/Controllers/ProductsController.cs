using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public ProductsController(ProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }

        protected ProductProvider productProvider;

        // GET api/Products/GetProducts?count=10&pageNumber=1...
        [HttpGet]
        public IActionResult GetProducts(
            int count,
            int pageNumber,
            string sortColumnName = null,
            string sortOrder = null,
            int? filterProductTypeId = null)
        {
            var result = this.productProvider.GetProducts(count, pageNumber, sortColumnName, sortOrder, filterProductTypeId);
            return Ok(result);
        }

        // GET api/Products/SearchProductByName?name=apple
        [HttpGet]
        public IActionResult SearchProductByName(string name)
        {
            var result = this.productProvider.SearchProductByName(name);
            return Ok(result);
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
