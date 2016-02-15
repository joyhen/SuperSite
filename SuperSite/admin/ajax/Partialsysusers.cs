using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace SuperSite.admin.ajax
{
    using Tools;
    using Config;
    using Model.DTO;
    using Model.Arg;
    using Model.Entity;
    using System.Transactions;

    public partial class requestaction
    {
        /// <summary>
        /// 添加单个系统用户
        /// </summary>
        private void AddSysUser()
        {
            var argdata = base.GetActionParamData<PArgSysUser>(true);
            if (argdata == null || !NotEmptyString(argdata.username))
            {
                Outmsg("参数解析错误");
                return;
            }

            var dbexist = new Server.UserService().GetUserByName(argdata.username);
            if (dbexist != null && dbexist.value != null && NotEmptyString(dbexist.value.UserName))
                Outmsg(string.Format("用户{0}已存在", argdata.username));

            var result = new Server.UserService().AddAndReturn<SysUser>(new SysUser
            {
                UserName = argdata.username,
                Password = EncryptAdmin(KeyCenter.KeyDefaultPwd),
                RealName = argdata.realname,
                Gender = argdata.gender,
                State = 1,
                Question = "",
                AddTime = DateTime.Now
            });

            Outmsg(result != null, "添加用户失败！");
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <remarks>参考</remarks>
        private void UpdateSysUser()
        {
            var argdata = base.GetActionParamData<PArgSysUser>(true);
            if (argdata == null || !NotEmptyString(argdata.username))
            {
                Outmsg("参数解析错误");
                return;
            }

            var dbdata = new Server.UserService().GetEntity<SysUser>(argdata.id);
            if (dbdata == null || !NotEmptyString(dbdata.UserName)) Outmsg("无效请求");

            var dbexist = new Server.UserService().GetUserByName(argdata.username);
            if (dbexist != null && dbexist.value != null)
            {
                if (dbexist.value.Id != argdata.id)
                    Outmsg(string.Format("用户{0}已存在", argdata.username));
            }

            var result = new Server.UserService().Update_SysUser(argdata);

            Outmsg(result, "更新用户失败！");
        }
        /// <summary>
        /// 设置用户登录密码
        /// </summary>
        private void SetSysUserPwd()
        {

        }
        /// <summary>
        /// 获取多个用户
        /// </summary>
        private void GetSysUsers()
        {
            var result = new Server.UserService().GetEntitys<SysUser>();
            Outmsg(result != null, "获取系统用户数据失败", outdata: result);
        }
        
        /// <summary>
        /// 删除用户（可以多个）
        /// </summary>
        private void DeleteSysUser()
        {
            var argdata = base.GetActionParamData<PArgCommon>(true);
            if (argdata == null ||
                argdata.ids == null ||
                argdata.ids.Count == 0) Outmsg("参数无效");

            var tag = 0;

            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in argdata.ids)
                {
                    var result = new Server.UserService().Delete_SysUser(item.id);
                    tag += result ? 1 : 0;
                }
                scope.Complete();
            }

            Outmsg(tag == argdata.ids.Count, "删除失败！");
        }

        //...

    }
}