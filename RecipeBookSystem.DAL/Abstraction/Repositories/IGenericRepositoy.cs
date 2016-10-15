using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Abstraction.Repositories
{
    /// <summary>
    /// Declares methods for GenericRepository class
    /// </summary>
    /// <typeparam name="TEntity">Type of the model</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Method for getting all <TEntity> models 
        /// </summary>
        /// <returns>List of <TEntity></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Executes database query
        /// </summary>
        /// <param name="spName">Name of the SP</param>
        /// <param name="callback">Function for parsing results</param>
        /// <param name="parameters">Parameters for executing queury</param>
        /// <returns>List of <TEntity></returns>
        IEnumerable<TEntity> ExecuteReader(string spName, Func<SqlDataReader, TEntity> callback,
           SqlParameter[] parameters = null);
    }
}
