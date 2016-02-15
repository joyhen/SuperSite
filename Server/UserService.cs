using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Server
{
    using Tools;
    using Config;
    using Model.DTO;
    using Model.Entity;
    using Common.ADO;

    public class UserService : BaseService
    {
        protected override EnumCenter.TipModel CurrenTipModel
        {
            get
            {
                return EnumCenter.TipModel.usertip;
            }
        }

        /// <summary>
        /// 根据用户获取用户信息
        /// </summary>
        public TransferModel<SysUser> GetUserByName(string username)
        {
            var result = new TransferModel<SysUser>();

            if (string.IsNullOrWhiteSpace(username))
            {
                result.msg = "用户名不能为空";
                return result;
            }

            try
            {
                var user = SPExecute.QuerySingle<SysUser>(Business.Sql.UserLogin, new
                {
                    UserName = username
                });
                if (user != null)
                {
                    result.success = true;
                    result.value = user;
                }
                else
                    result.msg = "户名不存在";
            }
            catch (Exception ex)
            {
                result.msg = ex.Message;
                LogHelp.WriteLog("登录错误", ex);
            }

            return result;
        }

        /// <summary>
        /// 更新表SysUser记录
        /// </summary>
        public bool Update_SysUser(Model.Arg.PArgSysUser paramArg)
        {
            string sql = @"UPDATE [SysUser]
                     SET [UserName] = @UserName
                        ,[RealName] = @RealName
                        ,[Gender] = @Gender
                  WHERE  [id] = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int),
                new SqlParameter("@UserName", SqlDbType.NVarChar),
                new SqlParameter("@RealName", SqlDbType.NVarChar),
                new SqlParameter("@Gender", SqlDbType.TinyInt)
            };

            parameters[0].Value = paramArg.id;
            parameters[1].Value = paramArg.username;
            parameters[2].Value = paramArg.realname;
            parameters[3].Value = paramArg.gender;

            var result = DBHelp.ExecuteSql(sql, parameters);
            return result > 0;
        }

        /// <summary>
        /// 删除表SysUser记录
        /// </summary>
        public bool Delete_SysUser(int id)
        {
            string sql = "DELETE SysUser WHERE Id=@Id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int)
            };

            parameters[0].Value = id;

            var result = DBHelp.ExecuteSql(sql, parameters);
            return result > 0;
        }

        //...

    }
}
