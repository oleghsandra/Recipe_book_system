using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RecipeBookSystem.DAL.Concrete.SQL
{
    public class SqlCommandWrapper
    {
        private readonly string _connectionString;
        public SqlCommandWrapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object ExecuteReader<T>(
            string commandText,
            SqlParameter[] parameters,
            Func<SqlDataReader, T> callback = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(commandText, connection) { CommandType = CommandType.StoredProcedure })
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    command.CommandTimeout = 0;

                    var reader = command.ExecuteReader();
                    object result;

                    using (reader)
                    {
                        var list = new List<T>();
                        while (reader.Read())
                        {
                            if (callback != null)
                            {
                                var item = callback(reader);
                                if (!Equals(item, default(T)))
                                {
                                    list.Add(item);
                                }
                            }
                        }
                        result = list;
                    }
                    return result;
                }
            }
        }
    }
}
