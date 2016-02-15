using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Common.ADO
{
    using Tools;

    /// <summary>
    /// 单机，简单数据库操作
    /// </summary>
    public sealed class DBHelp
    {
        /// <summary>
        /// 链接字符串
        /// </summary>
        private static string ConnectionString
        {
            get
            {
                return Connection.ConnectionString;
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数，select类型的语句此方法不可行。
        /// </summary>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlTransaction tran = connection.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = tran;
                        try
                        {
                            cmd.CommandText = SQLString;
                            int rows = cmd.ExecuteNonQuery(); //-1
                            tran.Commit();
                            return rows;
                        }
                        catch (Exception ex)
                        {
                            LogHelp.WriteLog(ex.Message);

                            tran.Rollback();
                            connection.Close();
                            return 0;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 执行带参数的SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlTransaction tran = connection.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        try
                        {
                            PrepareCommand(cmd, connection, tran, SQLString, cmdParms);
                            int rows = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            tran.Commit();
                            return rows;
                        }
                        catch (SqlException ex)
                        {
                            LogHelp.WriteLog(ex.Message);
                            tran.Rollback();
                            connection.Close();
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        public static DataSet ExecuteDataSet(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var ds = new DataSet();
                try
                {
                    connection.Open();

                    var command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds);

                    connection.Close();
                    return ds;
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        public static DataSet ExecuteDataSet(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    var ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                        cmd.Parameters.Clear();
                        return ds;
                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条sql语句，带事务
        /// </summary>
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tran = conn.BeginTransaction();
                cmd.Transaction = tran;

                try
                {
                    conn.Open();

                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    conn.Close();
                    return count;
                }
                catch
                {
                    tran.Rollback();
                    conn.Close();
                    return 0;
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn,
            SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open) conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null) cmd.Transaction = trans;

            cmd.CommandType = CommandType.Text; //cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput ||
                        parameter.Direction == ParameterDirection.Input)
                        && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}