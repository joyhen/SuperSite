using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Server
{
    using Tools;
    using Common.ADO;
    using Model.Arg;
    using Model.Entity;

    ///代码生成时间：2016-01-21 17:18:46

    public class CategoryService
    {
        /// <summary>
        /// 获取模型Category数据
        /// </summary>
        public List<Category> GetCategoryData()
        {
            var sql = @"SELECT Id,ParentId,Name,Url,SiteModel,ListTemplate,
                               ContentTemplate,Status,TargetBlank,ShowFoot,
                               SortNumber,Img,Content,AddTime,AddUser 
                        FROM Category";
            var ds = DBHelp.ExecuteDataSet(sql);
            if (BaseADOService.CheckDS(ds))
            {
                try
                {
                    var result = ds.Tables[0].MapTo<Category>();
                    return result.ToList();
                }
                catch
                {
                    return null;
                }
            }
            return new List<Category>();
        }

        /// <summary>
        /// 获取单个模型Category数据
        /// </summary>
        public Category GetSingleCategoryData(int id)
        {
            var sql = @"SELECT Id,ParentId,Name,Url,SiteModel,ListTemplate,
                               ContentTemplate,Status,TargetBlank,ShowFoot,
                               SortNumber,Img,Content,AddTime,AddUser 
                        FROM Category
                        WHERE Id=@Id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int)
            };

            parameters[0].Value = id;

            var ds = DBHelp.ExecuteDataSet(sql, parameters);
            if (BaseADOService.CheckDS(ds))
            {
                try
                {
                    var result = ds.Tables[0].MapTo<Category>();
                    return result.ToList().FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
            return new Category();
        }

        /// <summary>
        /// 新增表Category记录
        /// </summary>
        public bool Insert_Category(Category paramArg)
        {
            string sql = @"INSERT INTO [Category] ([ParentId],[Name],[Url],[SiteModel],[ListTemplate],
                                                   [ContentTemplate],[Status],[TargetBlank],[ShowFoot],
                                                   [SortNumber],[Img],[Content],[AddTime],[AddUser]) 
                                           VALUES (@ParentId,@Name,@Url,@SiteModel,@ListTemplate,
                                                   @ContentTemplate,@Status,@TargetBlank,@ShowFoot,
                                                   @SortNumber,@Img,@Content,@AddTime,@AddUser)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ParentId", SqlDbType.Int),
                new SqlParameter("@Name", SqlDbType.NVarChar),
                new SqlParameter("@Url", SqlDbType.NVarChar),
                new SqlParameter("@SiteModel", SqlDbType.Int),
                new SqlParameter("@ListTemplate", SqlDbType.NVarChar),
                new SqlParameter("@ContentTemplate", SqlDbType.NVarChar),
                new SqlParameter("@Status", SqlDbType.Bit),
                new SqlParameter("@TargetBlank", SqlDbType.Bit),
                new SqlParameter("@ShowFoot", SqlDbType.Bit),
                new SqlParameter("@SortNumber", SqlDbType.TinyInt),
                new SqlParameter("@Img", SqlDbType.NVarChar),
                new SqlParameter("@Content", SqlDbType.NVarChar),
                new SqlParameter("@AddTime", SqlDbType.DateTime),
                new SqlParameter("@AddUser", SqlDbType.NVarChar)
            };

            parameters[0].Value = paramArg.ParentId;
            parameters[1].Value = paramArg.Name;
            parameters[2].Value = paramArg.Url;
            parameters[3].Value = paramArg.SiteModel;
            parameters[4].Value = paramArg.ListTemplate;
            parameters[5].Value = paramArg.ContentTemplate;
            parameters[6].Value = paramArg.Status;
            parameters[7].Value = paramArg.TargetBlank;
            parameters[8].Value = paramArg.ShowFoot;
            parameters[9].Value = paramArg.SortNumber;
            parameters[10].Value = paramArg.Img;
            parameters[11].Value = paramArg.Content;
            parameters[12].Value = paramArg.AddTime;
            parameters[13].Value = paramArg.AddUser;

            var result = DBHelp.ExecuteSql(sql, parameters);
            return result > 0;
        }

        /// <summary>
        /// 更新表Category记录
        /// </summary>
        public bool Update_Category(Category paramArg)
        {
            string sql = @"UPDATE [Category]
                             SET [ParentId] = @ParentId
                                ,[Name] = @Name
                                ,[Url] = @Url
                                ,[SiteModel] = @SiteModel
                                ,[ListTemplate] = @ListTemplate
                                ,[ContentTemplate] = @ContentTemplate
                                ,[Status] = @Status
                                ,[TargetBlank] = @TargetBlank
                                ,[ShowFoot] = @ShowFoot
                                ,[SortNumber] = @SortNumber
                                ,[Img] = @Img
                                ,[Content] = @Content
                          WHERE  [id] = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int),
                new SqlParameter("@ParentId", SqlDbType.Int),
                new SqlParameter("@Name", SqlDbType.NVarChar),
                new SqlParameter("@Url", SqlDbType.NVarChar),
                new SqlParameter("@SiteModel", SqlDbType.Int),
                new SqlParameter("@ListTemplate", SqlDbType.NVarChar),
                new SqlParameter("@ContentTemplate", SqlDbType.NVarChar),
                new SqlParameter("@Status", SqlDbType.Bit),
                new SqlParameter("@TargetBlank", SqlDbType.Bit),
                new SqlParameter("@ShowFoot", SqlDbType.Bit),
                new SqlParameter("@SortNumber", SqlDbType.TinyInt),
                new SqlParameter("@Img", SqlDbType.NVarChar),
                new SqlParameter("@Content", SqlDbType.NVarChar)
            };

            parameters[0].Value = paramArg.Id;
            parameters[1].Value = paramArg.ParentId;
            parameters[2].Value = paramArg.Name;
            parameters[3].Value = paramArg.Url;
            parameters[4].Value = paramArg.SiteModel;
            parameters[5].Value = paramArg.ListTemplate;
            parameters[6].Value = paramArg.ContentTemplate;
            parameters[7].Value = paramArg.Status;
            parameters[8].Value = paramArg.TargetBlank;
            parameters[9].Value = paramArg.ShowFoot;
            parameters[10].Value = paramArg.SortNumber;
            parameters[11].Value = paramArg.Img;
            parameters[12].Value = paramArg.Content;

            var result = DBHelp.ExecuteSql(sql, parameters);
            return result > 0;
        }

        /// <summary>
        /// 更新表Category记录
        /// </summary>
        public bool Update_CategoryPage(CategoryPage paramArg)
        {
            string sql = @"UPDATE [Category]
                     SET [Name] = @Name
                        ,[Url] = @Url
                        ,[SortNumber] = @SortNumber
                  WHERE  [id] = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int),
                new SqlParameter("@Name", SqlDbType.NVarChar),
                new SqlParameter("@Url", SqlDbType.NVarChar),
                new SqlParameter("@SortNumber", SqlDbType.TinyInt)
            };

            parameters[0].Value = paramArg.id;
            parameters[1].Value = paramArg.name;
            parameters[2].Value = paramArg.url;
            parameters[3].Value = paramArg.sort;

            var result = DBHelp.ExecuteSql(sql, parameters);
            return result > 0;
        }

        /// <summary>
        /// 更新表Category记录
        /// </summary>
        public bool Update_CategoryStatus(int id, int status)
        {
            string sql = @"UPDATE [Category]
                     SET [Status] = @Status
                  WHERE  [id] = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int),
                new SqlParameter("@Status", SqlDbType.Bit)
            };

            parameters[0].Value = id;
            parameters[1].Value = status;

            var result = DBHelp.ExecuteSql(sql, parameters);
            return result > 0;
        }

        /// <summary>
        /// 删除表Category记录
        /// </summary>
        public bool Delete_Category(int id, bool tag)
        {
            string sql = "DELETE Category WHERE Id=@Id" + (tag ? " OR ParentId=@Id" : "");

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int)
            };

            parameters[0].Value = id;

            var result = DBHelp.ExecuteSql(sql, parameters);
            return result > 0;
        }
    }
}