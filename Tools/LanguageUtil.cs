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
        /// <remarks>默认中文</remarks>
        public static EnumCenter.Lang CurrentLanguage()
        {
            string lan = CookiesHelp.GetCookieValue(KeyCenter.KeyCurrentLangCookies);
            if (string.IsNullOrWhiteSpace(lan) || lan.Trim().Length == 0)
                return EnumCenter.Lang.zhcn;

            return EnumUtils.GetEnumBuyStr<EnumCenter.Lang>(lan);
        }

        //...

    }
}