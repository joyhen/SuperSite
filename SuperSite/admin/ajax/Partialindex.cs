using System;
using System.Linq;

namespace SuperSite.admin.ajax
{
    using Config;
    using Tools;
    using Model.Arg;

    public partial class requestaction
    {
        private void LanguageSet()
        {
            string lang = ((dynamic)(ActionParama.Arg)).lang;
            if (!IsNotEmptyString(lang)) Outmsg("参数错误");

            CookiesHelp.SetCookie(KeyCenter.KeyCurrentLangCookies, lang);
            Outmsg(true);
        }

        //...

    }
}