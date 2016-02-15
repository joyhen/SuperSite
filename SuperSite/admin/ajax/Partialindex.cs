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

    public partial class requestaction
    {
        /// <summary>
        /// 设置当前系统语言
        /// </summary>
        private void LanguageSet()
        {
            string lang = ((dynamic)(ActionParama.Arg)).lang;
            if (!NotEmptyString(lang)) Outmsg("参数错误");

            CookiesHelp.SetCookie(KeyCenter.KeyCurrentLangCookies, lang);
            Outmsg(true);
        }
        /// <summary>
        /// 清除系统缓存
        /// </summary>
        private void ClearSystemCache()
        {
            CacheUtil.Clear();
            Outmsg(true);
        }

        /// <summary>
        /// 上传远程图片
        /// </summary>
        private void UploadWebImg()
        {
            var ajaxdata = base.GetActionParamData<PArgUploadWebImg>();
            if (ajaxdata == null || ajaxdata.imgs == null || ajaxdata.imgs.Count == 0)
                Outmsg(false, outmsg: "未获取到图片地址");

            var len = ajaxdata.imgs.Count;
            var tempurl = new List<KeyValueDesc>();
            var stkimg = new Stack<KeyValue>(len); //上传栈列

            for (int i = 0; i < len; i++)
            {
                var img = ajaxdata.imgs[i].k.Trim();

                if (stkimg.Any(x => x.value == img))  //刚刚上传过了（说明有重复的图片要上传）
                {
                    var loadedpath = stkimg.First(x => x.value == img).value;
                    tempurl.Add(new KeyValueDesc
                    {
                        key = i.ToString(),
                        value = loadedpath,
                        desc = (int)EnumCenter.UploadImgStatus.Repeat
                    });
                    continue;
                }

                var tb = DownLoadWebImg(img);
                stkimg.Push(new KeyValue { key = i.ToString(), value = tb.Item2 }); //推入栈
                tempurl.Add(new KeyValueDesc
                {
                    key = i.ToString(),
                    value = tb.Item2,
                    desc = tb.Item1 ?
                    (int)EnumCenter.UploadImgStatus.OK :
                    (int)EnumCenter.UploadImgStatus.Error
                });
            }

            Outmsg(true, outdata: tempurl);
        }
        private Tuple<bool, string> DownLoadWebImg(string url)
        {
            try
            {
                var dt = DateTime.Now;
                var folder = "/upload/image/" + dt.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo) + "/";
                var newfile = dt.ToString("HHmmss_ffff", DateTimeFormatInfo.InvariantInfo)
                            + url.Substring(url.LastIndexOf('.')); //扩展名（带.号）
                var filepath = Server.MapPath(folder);

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                using (WebClient mywebclient = new WebClient())
                {
                    mywebclient.DownloadFile(url, filepath + newfile);
                    return new Tuple<bool, string>(true, folder + newfile);
                }
            }
            catch (Exception ex)
            {
                Tools.LogHelp.WriteLog("下载远程图片失败", ex);
                return new Tuple<bool, string>(false, url); //返回原图地址
            }
        }

        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        private void GetLoginRecord()
        {
            var filename = DateTime.Now.ToString("yyyyMM") + KeyCenter.KeyLoginRecordFile;
            var record = BufHelp.ProtoBufDeserialize<List<DLoginRecord>>(filename); //当月记录

            var username = GetSession(KeyCenter.KeyUserLoginNameSession);
            var result = (record ?? new List<DLoginRecord>())
                        .Where(x => x.UserName == username)
                        .OrderByDescending(x => x.LoginTime)
                        .Take(2);
            Outmsg(record != null, "没有记录", outdata: result);
        }

        //...

    }
}