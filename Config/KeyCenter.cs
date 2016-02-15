using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Config
{
    /// <summary>
    /// 键值名配置中心
    /// </summary>
    public class KeyCenter
    {
        /// <summary>
        /// 当前cookis作用域
        /// </summary>
        public const string KeyCookiesDomain = ""; //本地测试用的（发布以后，请使用发布地址）

        /// <summary>
        /// 应用程序根目录
        /// </summary>
        public static readonly string KeyBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 系统提示文件缓存键
        /// </summary>
        public const string KeyMessageTipsCache = "sp_MessageTipsCache";
        /// <summary>
        /// 系统标签语言集合
        /// </summary>
        public const string KeyLanguageLabelCache = "sp_LanguageLabelCache";

        /// <summary>
        /// 系统当前语言
        /// </summary>
        public const string KeyCurrentLangCookies = "sp_SystemCurrentLang";
        /// <summary>
        /// 系统当前配置信息缓存键
        /// </summary>
        public const string KeySystemSettingCache = "sp_SystemSettingCache";
        /// <summary>
        /// 站点当前配置信息缓存键
        /// </summary>
        public const string KeySiteSettingCache = "sp_SiteSettingCache";

        /// <summary>
        /// 验证码session键
        /// </summary>
        public const string KeyValidateCodeSession = "sp_ValidateCodeSession";
        /// <summary>
        /// 数据库连接字符串键
        /// </summary>
        public static readonly string KeyDataBaseConnectionKey = "SuperSiteConnection";
        /// <summary>
        /// 数据库连接字符串换成键
        /// </summary>
        public const string KeyDataBaseConnectionSession = "sp_DataBaseConnectionSession";


        /// <summary>
        /// 存储用户登录名session键
        /// </summary>
        public const string KeyUserLoginNameSession = "sp_UserLoginNameSession";
        /// <summary>
        /// 用户登录成功等待校验登录口令时，设置session
        /// </summary>
        public const string KeyUserLoginWaitQuestion = "sp_UserLoginWaitQuestion";
        /// <summary>
        /// 登录用户名和密码信息存储到cookies里面的键
        /// </summary>
        public const string KeyCookiesLoginUserName = "sp_CookiesLoginUserName";

        /// <summary>
        /// Ajax GET方式参数对象名
        /// </summary>
        public const string KeyAjaxActionNameWhenGet = "ajaxparam";
        /// <summary>
        /// ajax方法客户端对应方法名的签名秘钥
        /// </summary>
        public const string KeyClientAjaxFnSecretkey = "sp_jon1987";
        /// <summary>
        /// 数据默认初始时间
        /// </summary>
        public static DateTime KeyStartTime = new DateTime(2000, 1, 1);
        /// <summary>
        /// 系统默认密码
        /// </summary>
        public const string KeyDefaultPwd = "123456";


        #region Files
        ///// <summary>
        ///// 用户头像文件夹名
        ///// </summary>
        //public readonly static string KeyUserPhotoFolder = "Config";

        /// <summary>
        /// 系统当前信息配置文件
        /// </summary>
        public const string KeySystemSettingFile = "system.bin";
        /// <summary>
        /// 站点当前信息配置文件
        /// </summary>
        public const string KeySiteSettingFile = "site.bin";
        /// <summary>
        /// 当前程序信息配置说明
        /// </summary>
        public const string KeySuperSiteProgramFile = "supersite.bin";
        /// <summary>
        /// 用户登录信息文件
        /// </summary>
        public readonly static string KeyLoginRecordFile = "login.bin";

        #endregion

    }
}
