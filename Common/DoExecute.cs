using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Common
{
    using Dapper;
    using Dapper.Contrib.Extensions;

    public class DoExecute
    {
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <remarks>id is Key</remarks>
        public T GetEntity<T>(int id) where T : Model.Entity.ZZLBaseEentity, new()
        {
            using (var connection = Connection.GetOpenConnection())
            {
                try
                {
                    var entity = connection.Get<T>(id);
                    connection.Close();
                    return entity;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 获取全部实体
        /// </summary>
        public List<T> GetAllEntity<T>() where T : Model.Entity.ZZLBaseEentity, new()
        {
            using (var connection = Connection.GetOpenConnection())
            {
                try
                {
                    var entitys = connection.GetAll<T>();
                    connection.Close();
                    return entitys.ToList();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 添加单个匿名对象
        /// </summary>
        /// <param name="dynamic_entityToInsert">
        /// 匿名对象 eg:
        /// <example>
        /// var c = new
        /// {
        ///     namse = "C#基础",
        ///     des = "sms",
        ///     much = 100,
        ///     dtime = new DateTime(2014, 7, 12)
        /// };
        /// </example>
        /// </param>
        /// <remarks>此方法不够健壮，无法保障dynamic_entityToInsert的完整性，反射又得不偿失了</remarks>
        public bool InsertDynamic<T>(object dynamic_entityToInsert) where T : class
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var id = connection.Insert<T>((T)dynamic_entityToInsert, tran);
                        tran.Commit();
                        connection.Close();
                        return id > 0;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 添加单个对象
        /// </summary>
        public bool Insert<T>(T entityToInsert) where T : Model.Entity.ZZLBaseEentity, new()
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var id = connection.Insert<T>(entityToInsert, tran);
                        tran.Commit();
                        connection.Close();
                        return id > 0;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 添加单个对象并返回当前对象
        /// </summary>
        public T InsertAndReturn<T>(T entityToInsert) where T : Model.Entity.ZZLBaseEentity, new()
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var id = connection.Insert<T>(entityToInsert, tran);
                        tran.Commit();

                        var result = connection.Get<T>(id);
                        connection.Close();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 添加多个对象
        /// </summary>
        public bool InsertMulit<T>(T entityToInsert) where T : class, System.Collections.IList
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var total = connection.Insert(entityToInsert, tran);
                        tran.Commit();
                        connection.Close();
                        return total > 0;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 添加多个对象同时执行其它操作
        /// </summary>
        public bool InsertMulitWithExecute<T>(T entityToInsert, string executeSql, object paramters)
            where T : class, System.Collections.IList
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var rowsAffected = ExecuteQuery(executeSql, paramters);
                        //if (rowsAffected <= 0) return false;

                        var total = connection.Insert(entityToInsert, tran);
                        tran.Commit();
                        connection.Close();
                        return total > 0;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 更新单个对象
        /// </summary>
        /// <remarks>注意：更新的是实体对象（除了key以外的所有字段都会更新）</remarks>
        public bool Update<T>(T entityToUpdate) where T : Model.Entity.ZZLBaseEentity, new()
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var result = connection.Update<T>(entityToUpdate, tran);
                        tran.Commit();
                        connection.Close();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 删除单个或多个对象
        /// </summary>
        /// <remarks>T要带上含有Key的属性</remarks>
        public bool Delete<T>(T entitysToDelete) where T : Model.Entity.ZZLBaseEentity, new()
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        //var usersToDelete = users.Take(10).ToList();
                        //connection.Delete(usersToDelete);
                        bool result = connection.Delete(entitysToDelete, tran);
                        tran.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 删除单个对象
        /// </summary>
        public bool DeleteWithKeyId<T>(int id) where T : Model.Entity.ZZLBaseEentity, new()
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        bool result = connection.Delete(new T { Id = id }, tran);
                        tran.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 删除所有记录
        /// </summary>
        /// <remarks>底层用的delete</remarks>
        public bool DeleteAll<T>() where T : Model.Entity.ZZLBaseEentity, new()
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        connection.DeleteAll<T>(tran);
                        tran.Commit();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 执行 "sql 或 存储过程" 查询
        /// </summary>
        public T QuerySingle<T>(string executeSql, object param = null, bool isprocedure = false) where T : class
        {
            var query = Query<T>(executeSql, param, isprocedure);

            if (query != null && query.Count > 0) return query.FirstOrDefault();

            return null;
        }
        /// <summary>
        /// 执行 "sql 或 存储过程" 查询
        /// </summary>
        /// <param name="executeSql">执行语句</param>
        /// <param name="paramters">参数 eg:<example>new { ID = id }</example></param>
        /// <param name="isProcedure">是否是存储过程</param>
        public List<T> Query<T>(string executeSql, object paramters = null, bool isProcedure = false) where T : class
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var result = connection.Query<T>(
                                        executeSql,
                                        paramters,
                                        tran,
                                        commandType: isProcedure ?
                                            CommandType.StoredProcedure : CommandType.Text
                                     ).ToList();
                        tran.Commit();
                        connection.Close();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 执行 "sql 或 存储过程"，并返回对象
        /// </summary>
        /// <remarks>paramters参数需要带主键id</remarks>
        public T ExecuteQueryAndReturn<T>(string executeSql, object paramters = null, bool isProcedure = false)
            where T : Model.Entity.ZZLBaseEentity, new()
        {
            var rowsAffected = ExecuteQuery(executeSql, paramters, isProcedure);
            if (rowsAffected > 0)
            {
                try
                {
                    var id = ((dynamic)(paramters)).Id ?? ((dynamic)(paramters)).id;
                    var dbid = (int)id;
                    return dbid > 0 ? GetEntity<T>(dbid) : default(T);
                }
                catch (Exception ex) { throw ex; }
            }

            return default(T);
        }

        /// <summary>
        /// 执行 "sql 或 存储过程" 查询
        /// </summary>
        /// <param name="executeSql">执行语句</param>
        /// <param name="paramters">参数 eg:<example>new { ID = id }</example></param>
        /// <param name="isProcedure">是否是存储过程</param>
        public int ExecuteQuery(string executeSql, object paramters = null, bool isProcedure = false)
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var rowsAffected = connection.Execute(
                                        executeSql,
                                        paramters,
                                        tran,
                                        commandType: isProcedure ?
                                            CommandType.StoredProcedure : CommandType.Text
                                     );
                        tran.Commit();
                        connection.Close();
                        return rowsAffected;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 批处理（sql语句 或 存储过程 或 都有）
        /// </summary>
        /// <param name="processingSql">
        /// sql语句or存储过程，匿名参数对象集，是否是存储过程
        /// <example>
        /// "DELETE FROM ProductProductPhoto WHERE ProductID = @ProductID", new{ProductID=1}, false
        /// "DELETE FROM Product WHERE ProductID = @ProductID",  new{ProductID=1}, false
        /// "dbo.uspGetEmployeeManagers", null, true
        /// </example>
        /// </param>
        public int BatchProcessing(List<Tuple<string, object, bool>> processingSql)
        {
            using (var connection = Connection.GetOpenConnection())
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        int rowsAffected = 0;

                        foreach (var item in processingSql)
                        {
                            rowsAffected += connection.Execute(
                                    item.Item1,
                                    item.Item2,
                                    tran,
                                    commandType: item.Item3 ?
                                        CommandType.StoredProcedure : CommandType.Text
                                );
                        }

                        tran.Commit();
                        connection.Close();
                        return rowsAffected;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// TransactionScope回滚 demo
        /// </summary>
        public void TransactionScopeInsert<T>(T entityToInsert) where T : Model.Entity.ZZLBaseEentity, new()
        {
            using (var connection = Connection.GetConnection())
            {
                using (var txscope = new System.Transactions.TransactionScope())
                {
                    connection.Open();  //connection MUST be opened inside the transactionscope

                    var id = connection.Insert(entityToInsert);   //inser entity within transaction

                    txscope.Dispose();  //rollback

                    connection.Get<T>(id).IsNull();   //returns null - entity with that id should not exist
                    connection.Close();
                }
            }
        }

        //...

    }
}
