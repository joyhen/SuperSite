using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    using Config;
    using Tools;
    using Model.DTO;
    using Model.Entity;

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
                var user = SPExecute.QuerySingle<SysUser>(Business.Sql.UserLogin, new { UserName = username });
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

        //...

    }
}
