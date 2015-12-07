namespace Model.Arg
{
    /// <summary>
    /// 用户登录客户端参数对象
    /// </summary>
    public class PArgUserLogin : IAjaxArg
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string code { get; set; }
    }
}
