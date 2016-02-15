using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace SuperSite.admin.ajax
{
    using Tools;
    using Config;
    using Model.Arg;
    using Model.DTO;
    using Model.Entity;
    using System.Transactions;

    public partial class requestaction
    {
        /// <summary>
        /// 保存当前程序配置信息
        /// </summary>
        private void SaveSuperProgramInfo()
        {
            var argdata = base.GetActionParamData<PArgSuperProgramInfo>(true);
            if (argdata == null)
            {
                Outmsg("参数解析错误");
                return;
            }

            Outmsg("您无权操作"); //发布时候添加

            var bufdata = new DSuperProgramInfo
            {
                Name = argdata.name,
                Version = argdata.version,
                System = argdata.system,
                AspNet = argdata.aspnet,
                SqlServer = argdata.sqlserver,
                Author = argdata.author
            };

            var result = BufHelp.ProtoBufSerialize<DSuperProgramInfo>(bufdata, KeyCenter.KeySuperSiteProgramFile);
            Outmsg(result, "保存当前程序配置信息失败！");
        }

        /// <summary>
        /// 获取本程序配置信息
        /// </summary>
        private void GetSuperProgramInfo()
        {
            var filename = KeyCenter.KeySuperSiteProgramFile;
            var result = BufHelp.ProtoBufDeserialize<DSuperProgramInfo>(filename)
                            ?? new DSuperProgramInfo();
            Outmsg(result != null, "未获取到序配置信息！", result);
        }

        //...

    }
}