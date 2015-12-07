using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Server
{
    using Config;
    using Tools;
    using Model.DTO;
    using Model.Entity;

    public class LoginService : BaseService
    {
        protected override EnumCenter.TipModel CurrenTipModel
        {
            get
            {
                return EnumCenter.TipModel.logintip;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        public TransferModel<SysUser> UserLogin(string username, string userpwd, bool encryptpwd = true)
        {
            var result = new TransferModel<SysUser>();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(userpwd))
            {
                result.msg = Tips.FindTip(CurrenTipModel, "NameOrPassworldNull");
                return result;
            }

            try
            {
                var pwd = encryptpwd ? EncryptAdmin(userpwd) : userpwd;
                var user = SPExecute.QuerySingle<SysUser>(Business.Sql.UserLogin, new { UserName = username });
                if (user != null)
                {
                    if (string.Compare(user.Password, pwd) == 0)
                    {
                        result.success = true;
                        result.value = user;
                    }
                    else
                        result.msg = Tips.FindTip(CurrenTipModel, "UserNameNotMatchUserPwd");
                }
                else
                    result.msg = Tips.FindTip(CurrenTipModel, "LoginError");
            }
            catch (Exception ex)
            {
                result.msg = Tips.FindTip(CurrenTipModel, "LoginError"); //ex.Message;
                LogHelp.WriteLog("登录错误", ex);
            }

            return result;
        }

        //...

    }
}