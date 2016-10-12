using RecipeBookSystem.Model.Models;
using System.Collections.Generic;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductModel>
    {
        IEnumerable<ProductModel> GetProducts(
            int count,
            int pageNumber, 
            string sortColumnName = null,
            string sortOrder = null, 
            int? filterProductTypeId = null);

        void DeleteProduct(int productId);

        void UpdateProduct(
            int updateProductId,
            string name,
            int productTypeId,
            float proteins,
            float fats,
            float carbohydrates,
            string smallPhotoLink);

        void AddProduct(ProductModel newProduct);

        IEnumerable<ProductModel> SearchProductByName(string name);
    }
}
