using System;
using System.Linq;

namespace SuperSite.admin.ajax
{
    using Tools;
    using Config;
    using Model.Arg;
    using Model.DTO;

    public partial class requestaction
    {
        /// <summary>
        /// 保存系统设置
        /// </summary>
        private void SaveSystemSetting()
        {
            var argdata = base.GetActionParamData<PArgSystemSetting>(true);

            if (argdata == null)
            {
                Outmsg("参数解析错误");
                return;
            }

            var bufdata = new DSystemSetting
            {
                SiteStatic = argdata.sitestatic,
                PseudoStatic = argdata.pseudostatic,
                LoginValidate = argdata.loginvalidate,
                LoginQustion = argdata.loginqustion,
                MultiLanguage = argdata.multilanguage,
                AllowQQLogin = argdata.allowqqlogin,
                FileCacheTime = argdata.filecachetime <= 0 ? 60 : argdata.filecachetime
            };

            var result = BufHelp.ProtoBufSerialize<DSystemSetting>(bufdata, KeyCenter.KeySystemSettingFile);
            if (result) CacheUtil.Remove(KeyCenter.KeySystemSettingCache);
            Outmsg(result, "保存系统配置信息失败！");
        }

        /// <summary>
        /// 保存站点设置
        /// </summary>
        private void SaveSiteSetting()
        {
            var argdata = base.GetActionParamData<PArgSiteSetting>(true);

            if (argdata == null)
            {
                Outmsg("参数解析错误");
                return;
            }

            var bufdata = new DSiteSetting
            {
                UrlSplit = argdata.urlsplit ?? "-",
                SiteName = argdata.sitename,
                SiteTitle = argdata.sitetitle,
                SiteKeywords = argdata.sitekeywords,
                SiteDescription = argdata.sitedescription
            };

            var result = BufHelp.ProtoBufSerialize<DSiteSetting>(bufdata, KeyCenter.KeySiteSettingFile);
            if (result) CacheUtil.Remove(KeyCenter.KeySiteSettingCache);
            Outmsg(result, "保存站点配置信息失败！");
        }

        //...

    }
}