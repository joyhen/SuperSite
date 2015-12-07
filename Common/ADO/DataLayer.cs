using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Common.ADO
{
    internal class DataLayer
    {
        private static string SqlConnectionString = string.Empty;

        static DataLayer()
        {
            SqlConnectionString = Connection.ConnectionString;
        }

        internal static string GetConnectionString()
        {
            //...
            return SqlConnectionString;
        }

        internal static int ExecuteNonQueryFromStoredProcedure(string procedureName, Dictionary<string, object> procedureParams)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = GetConnectionString();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    if (procedureParams != null && procedureParams.Count > 0)
                    {
                        foreach (KeyValuePair<string, object> kvp in procedureParams)
                        {
                            command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                        }
                    }

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        internal static int ExecuteNonQueryFromSqlStatement(string sql, params object[] sqlParams)
        {
            int paramNdx = 0;
            int valNdx = 1;
            var paramValDictionary = new Dictionary<string, string>();

            foreach (object param in sqlParams)
            {
                if (param is string)
                {
                    sql = sql.Replace("'{" + paramNdx + "}'", "@val" + valNdx);
                    sql = sql.Replace("{" + paramNdx + "}", "@val" + valNdx);
                    paramValDictionary.Add("@val" + valNdx, (string)param);
                    valNdx++;
                }
                else
                {
                    sql = sql.Replace("{" + paramNdx + "}", param.ToString());
                }
                paramNdx++;
            }

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = GetConnectionString();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sql;
                    foreach (KeyValuePair<string, string> kvp in paramValDictionary)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        internal static DataTable GetDataFromSqlStatement(string sql, params object[] sqlParams)
        {
            int paramNdx = 0;
            int valNdx = 1;
            var paramValDictionary = new Dictionary<string, string>();

            foreach (object param in sqlParams)
            {
                if (param is string)
                {
                    sql = sql.Replace("'{" + paramNdx + "}'", "@val" + valNdx);
                    sql = sql.Replace("{" + paramNdx + "}", "@val" + valNdx);
                    paramValDictionary.Add("@val" + valNdx, (string)param);
                    valNdx++;
                }
                else
                {
                    sql = sql.Replace("{" + paramNdx + "}", param.ToString());
                }
                paramNdx++;
            }

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = GetConnectionString();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sql;
                    foreach (KeyValuePair<string, string> kvp in paramValDictionary)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }

                    connection.Open();
                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = command;
                            adapter.Fill(ds);

                            if (ds.Tables.Count > 0)
                            {
                                return ds.Tables[0];
                            }
                        }
                    }
                }
            }

            return null;
        }

        internal static DataTable GetDataFromStoredProcedure(string procedureName, Dictionary<string, object> procedureParams)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = GetConnectionString();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    if (procedureParams != null && procedureParams.Count > 0)
                    {
                        foreach (KeyValuePair<string, object> kvp in procedureParams)
                        {
                            command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                        }
                    }

                    connection.Open();
                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = command;
                            adapter.Fill(ds);

                            if (ds.Tables.Count > 0)
                            {
                                return ds.Tables[0];
                            }
                        }
                    }
                }
            }

            return null;
        }

        internal static DataTable GetDataFromStoredProcedure(string procedureName)
        {
            return GetDataFromStoredProcedure(procedureName, null);
        }
    }
}
