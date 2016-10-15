using RecipeBookSystem.DAL.Abstraction.Repositories;
using RecipeBookSystem.DAL.Concrete.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Concrete.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly SqlCommandWrapper _sqlWrapper;

        public GenericRepository(string connection)
        {
            _sqlWrapper = new SqlCommandWrapper(connection);
        }

        public SqlCommandWrapper SqlWrapper
        {
            get { return _sqlWrapper; }
        }

        public IEnumerable<TEntity> ExecuteReader(
            string spName,
            Func<SqlDataReader, TEntity> callback, 
            SqlParameter[] parameters = null)
        {
            var result = SqlWrapper.ExecuteReader(spName, parameters, callback);
            return (IEnumerable<TEntity>)result;
        }

        /// <summary>
        /// Method for getting all <TEntity> models 
        /// </summary>
        /// <returns>List of <TEntity></returns>
        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
