namespace SuperSite.admin.ajax
{
    using Tools;
    using Config;

    public class RightAction
    {
        /// <summary>
        /// 操作名
        /// <remarks>每一个操作必须有操作名，不可为空</remarks>
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 客户端调用的方法签名
        /// </summary>
        public string ClientName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ActionName))
                    return string.Empty;

                return Encrypt.MD5Encrypt(ActionName, KeyCenter.KeyClientAjaxFnSecretkey);
            }
        }

        private bool _checklogin = true;
        /// <summary>
        /// 当前操作是否要验证用户的登录状态
        /// </summary>
        public bool CheckLogin
        {
            get { return _checklogin; }
            set { _checklogin = value; }
        }
    }
}