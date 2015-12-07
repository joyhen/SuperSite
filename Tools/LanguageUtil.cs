using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Tools
{
    using Config;

    /// <summary>
    /// 语言设置
    /// </summary>
    public class LanguageUtil
    {
        /// <summary>
        /// 当前系统语言
        /// </summary>
        public static EnumCenter.Lang CurrentLanguage()
        {
            string lan = CookiesHelp.GetCookieValue(KeyCenter.KeyCurrentLangCookies);
            if (string.IsNullOrWhiteSpace(lan) || lan.Trim().Length == 0)
                return EnumCenter.Lang.en;

            EnumCenter.Lang elan = EnumUtils.GetEnumBuyStr<EnumCenter.Lang>(lan);
            return elan;
        }

        //...

    }
}