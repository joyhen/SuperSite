using System;
using System.Linq;
using System.Collections.Generic;

namespace SuperSite.admin.ajax
{
    using Config;
    using Tools;
    using Model.Arg;

    public partial class requestaction
    {
        /// <summary>
        /// 获取所有通知类型
        /// </summary>
        private void GetNoticeType()
        {
            var serverdata = new Server.NoticeService().GetNoticeTypes();
            if (serverdata.value == null)
            {
                Outmsg(outmsg: serverdata.msg);
                return;
            }

            var data = serverdata.value.Select(x => new //后期换成AutoMap
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                AdvanceDay = x.AdvanceDay,
                Open = x.Open,
                Reserved1 = x.Reserved1,
                AddUser = x.AddUser,
                AddTime = x.AddTime,
                CategoryName = ((Config.EnumCenter.NoticeCategory)(x.Category)).ToString()
            });

            Outmsg(true, outdata: data);
        }

        /// <summary>
        /// 添加一个通知类型
        /// </summary>
        private void AddNoticeType()
        {
            var argdata = base.GetActionParamData<PArgNoticeType>();

            if (argdata == null)
            {
                Outmsg("参数解析错误");
                return;
            }

            var ormdata = new Model.Entity.BizNoticeType
            {
                Name = argdata.typename,
                Description = argdata.desc,
                AdvanceDay = argdata.advday,
                Open = argdata.open == 1,
                Reserved1 = argdata.remark,
                AddUser = CurrentUser.UserName,
                AddTime = DateTime.Now,
                UpdateTime = KeyCenter.KeyStartTime,
                Category = (int)EnumUtils.GetEnumBuyStr<EnumCenter.NoticeCategory>(argdata.category),
            };

            var result = new Server.NoticeService().Insert<Model.Entity.BizNoticeType>(ormdata);
            Outmsg(result, "新增通知类型失败！");
        }

        //...

    }
}