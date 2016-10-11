using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Concrete.Parsers;
using RecipeBookSystem.DAL.Concrete.SQL;
using RecipeBookSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookSystem.DAL.Concrete.Repositories
{
    public class ProductRepository : GenericRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(string connection)
            : base(connection)
        {

        }

        /// <summary>
        /// Retrieves list of sorted and filtered products
        /// </summary>
        /// <param name="count">Count of products to retrieve</param>
        /// <param name="pageNumber">Page index</param>
        /// <param name="sortColumnName">Name of column to sort by</param>
        /// <param name="sortOrder">Sort order (asc/desc)</param>
        /// <param name="filterProductTypeId">Product type Id to filter by it</param>
        /// <returns>List of filtered and sorted products</returns>
        public IEnumerable<ProductModel> GetProducts(
            int count,
            int pageNumber,
            string sortColumnName = null,
            string sortOrder = null,
            int? filterProductTypeId = null)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.PageNumber, pageNumber),
                new SqlParameter(StoredProcedureParameters.ProductCount, count),
                new SqlParameter(StoredProcedureParameters.SortColumn, sortColumnName),
                new SqlParameter(StoredProcedureParameters.SortOrder, sortOrder),
                new SqlParameter(StoredProcedureParameters.FilterProductTypeId, filterProductTypeId)
            };

            var products = base.ExecuteReader(
                StoredProcedureNames.spGetProduct,
                ProductParser.MakeBuildingResult, 
                parameters);

            return products;

        }

        public void DeleteProduct(int productId)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.ProductId, productId)
            };

           base.ExecuteReader(
               StoredProcedureNames.spDeleteProduct, 
               ProductParser.MakeBuildingResult,
               parameters);
        }
    }
}
