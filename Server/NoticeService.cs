using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Server
{
    using Model.DTO;
    using Model.Entity;

    public class NoticeService : BaseService
    {
        /// <summary>
        /// 根据用户获取用户信息
        /// </summary>
        public TransferModel<List<BizNoticeType>> GetNoticeTypes()
        {
            var result = new TransferModel<List<BizNoticeType>>();

            try
            {
                var query = base.GetEntitys<BizNoticeType>();

                if (query != null)
                {
                    result.success = true;
                    result.value = query;
                }
                else result.msg = "暂无数据";
            }
            catch (Exception ex)
            {
                result.msg = ex.Message;
                Tools.LogHelp.WriteLog("获取通知类型出错", ex);
            }

            return result;
        }

        //...

    }
}
