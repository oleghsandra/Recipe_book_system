using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RecipeBookSystem.BL.ModelProviders;
using RecipeBookSystem.Model.Models;

namespace RecipeBookSystem.API.Controllers
{
    public class ProductsController : ApiController
    {
        public ProductsController(/*ProductProvider productProvider*/)
        {
            this.productProvider = new ProductProvider();
        }

        protected ProductProvider productProvider;

        // GET api/Products/GetProducts?count=10&pageNumber=1...
        [HttpGet]
        public List<ProductModel> GetProducts(
            int count,
            int pageNumber,
            string sortColumnName = null,
            string sortOrder = null,
            int? filterProductTypeId = null)
        {
            var result = this.productProvider.GetProducts(count, pageNumber, sortColumnName, sortOrder, filterProductTypeId).ToList();
            return result;
        }

        // GET api/Products/SearchProductByName?name=apple
        [HttpGet]
        public List<ProductModel> SearchProductByName(string name)
        {
            var result = this.productProvider.SearchProductByName(name).ToList();
            return result;
        }

        // POST api/Products
        [HttpPost]
        public void AddProduct(ProductModel model)
        {
            this.productProvider.AddProduct(model);
        }

        // POST api/Products/DeleteProduct?productId=5
        [HttpPost]
        public void DeleteProduct(ProductModel model)
        {
            this.productProvider.DeleteProduct(model.Id);
        }
    }
}
