namespace Config
{
    /// <summary>
    /// 系统枚举中心
    /// </summary>
    public class EnumCenter
    {
        /// <summary>
        /// 通知类别
        /// </summary>
        public enum NoticeCategory
        {
            资金类 = 0,
            运营类 = 1,
            代金券类 = 2,
            其他 = 3
        }

        /// <summary>
        /// 图片上传状态
        /// </summary>
        /// <remarks>编辑器粘贴内容包含图片，远程上传</remarks>
        public enum UploadImgStatus
        {
            /// <summary>
            /// 重复图片
            /// </summary>
            Repeat = 0,
            /// <summary>
            /// 上传成功
            /// </summary>
            OK = 1,
            /// <summary>
            /// 上传失败
            /// </summary>
            Error = 2
        }

        /// <summary>
        /// 栏目模型
        /// </summary>
        public enum SiteModelStyle
        {
            /// <summary>
            /// 单篇模型
            /// </summary>
            单篇模型 = 1,
            /// <summary>
            /// 文章模型
            /// </summary>
            文章模型 = 2,
            /// <summary>
            /// 产品模型
            /// </summary>
            产品模型 = 3,
            /// <summary>
            /// 案例模型
            /// </summary>
            案例模型 = 4,
            /// <summary>
            /// 视频模型
            /// </summary>
            视频模型 = 5
        }

        /// <summary>
        /// 用户类别
        /// <remarks>非系统用户角色</remarks>
        /// </summary>
        public enum AdminType
        {
            /// <summary>
            /// 普通浏览者
            /// </summary>
            Client = 0,
            /// <summary>
            /// 系统用户
            /// </summary>
            User = 1,
            /// <summary>
            /// 普通管理员
            /// <remarks>部分系统级功能没有</remarks>
            /// </summary>
            Admin = 2,
            /// <summary>
            /// 超级管理员
            /// <remarks>拥有系统所有功能</remarks>
            /// </summary>
            SuperAdmin = 4,
            /// <summary>
            /// 系统后门用户
            /// <remarks>以防万一，你懂的</remarks>
            /// </summary>
            HiddenBug = 8
        }

        /// <summary>
        /// 日志类别
        /// </summary>
        /// <remarks>需要修改</remarks>
        public enum LogType
        {
            NormalError = 0,
            DeserializeObject = 1,
            HttpForbidden = 2,
        }

        /// <summary>
        /// 提示模块
        /// </summary>
        public enum TipModel
        {
            /// <summary>
            /// 公用模块
            /// </summary>
            commontip = 0,
            /// <summary>
            /// 登录模块
            /// </summary>
            logintip = 1,
            /// <summary>
            /// 用户模块
            /// </summary>
            usertip = 2
        }

        /// <summary>
        /// 语言
        /// </summary>
        public enum Lang
        {
            /// <summary>
            /// 简体中文
            /// </summary>
            zhcn = 0,
            /// <summary>
            /// 繁体中文
            /// </summary>
            zhtw = 1,
            /// <summary>
            /// 英文
            /// </summary>
            en = 2
        }

        //...


    }
}