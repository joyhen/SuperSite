using System;
using System.Linq;
using System.Collections.Generic;

namespace SuperSite.admin.ajax
{
    using Config;
    using Tools;
    using Model.Arg;
    using Model.DTO;

    public partial class requestaction
    {
        public void Login()
        {
            var argdata = base.GetActionParamData<PArgUserLogin>();

            if (argdata == null)
            {
                Outmsg("参数解析错误");
                return;
            }

            if (SystemInfo.LoginValidate)
            {
                if (argdata.code != GetSession(KeyCenter.KeyValidateCodeSession))
                {
                    Outmsg("验证码错误");
                    return;
                }
            }

            var serverdata = new Server.LoginService().UserLogin(argdata.name, argdata.pwd);
            if (serverdata.value == null)
            {
                Outmsg(outmsg: serverdata.msg);
                return;
            }

            if (serverdata.value.State == 2)
            {
                Outmsg("没有此用户");
                return;
            }
            if (serverdata.value.State == 0)
            {
                Outmsg("当前用户已禁止登录系统");
                return;
            }

            //判断系统是否启用登录口令校验...

            //获取登录口令
            var question = serverdata.value.GetLoginQuestion(); //Item1问题索引，Item2问题答案（后期再设计吧，先这么测试下）
            if (question == null || question.Item1 <= 0 || string.IsNullOrWhiteSpace(question.Item2))
            {
                SetLogin(serverdata.value);
                Outmsg(true);
            }
            else
            {
                //测下代码，具体后期设计
                var sysquestion = SystemDefaultQuestion().FirstOrDefault(x => x.Item1 == question.Item1);

                //等待回答登录口令问题Session标记（用户,问题答案）
                string keyLoginOk = string.Format("{0}${1}", serverdata.value.UserName, sysquestion.Item3);
                Session[KeyCenter.KeyUserLoginWaitQuestion] = Encrypt.DESEncrypt(keyLoginOk);

                Outmsg(true, outdata: sysquestion.Item2); //口令问题
            }
        }

        /// <summary>
        /// 登录口令校验
        /// </summary>
        public void AnswerQuesion()
        {
            string answer = ((dynamic)(ActionParama.Arg)).answer;

            if (string.IsNullOrWhiteSpace(answer)) Outmsg("参数解析错误");

            var haslogin = GetSession(KeyCenter.KeyUserLoginWaitQuestion) ?? "";

            if (string.IsNullOrWhiteSpace(haslogin.ToString())) Outmsg("您尚未登录");

            var qinfo = Encrypt.DESDecrypt(haslogin);
            if (!NotEmptyString(qinfo)) Outmsg("您尚未登录");

            var checkarr = qinfo.Split('$');
            if (checkarr.Length != 2) Outmsg("您尚未登录");
            if (checkarr[1] != answer) Outmsg("口令回答错误");

            Session.Remove(KeyCenter.KeyUserLoginWaitQuestion); //移除标记

            var serverdata = new Server.UserService().GetUserByName(checkarr[0]);
            SetLogin(serverdata.value);
            Outmsg(true);
        }

        /// <summary>
        /// 登录成功以后干的事
        /// </summary>
        private void SetLogin(Model.Entity.SysUser user)
        {
            //redis http://www.cnblogs.com/cheng5x/p/4736445.html
            //ASP.NET中的Session怎么正确使用 http://www.cr173.com/html/24780_1.html
            //http://blog.163.com/pg_wp/blog/static/5473685620085292915945/

            //用户信息加密后写到缓存中（需要考虑缓存同步的问题）
            Session[KeyCenter.KeyUserLoginNameSession] = user.UserName;
            CookiesHelp.SetCookie(KeyCenter.KeyCookiesLoginUserName, JsonUtils.JsonSerializer(user), expiresDays: 1);
            SetLoginRecord(user.UserName, user.RealName);
        }

        /// <summary>
        /// 记录登录信息
        /// </summary>
        private void SetLoginRecord(string username, string realname)
        {
            var filename = DateTime.Now.ToString("yyyyMM") + KeyCenter.KeyLoginRecordFile;
            var record = BufHelp.ProtoBufDeserialize<List<DLoginRecord>>(filename);

            record = record ?? new List<DLoginRecord>();
            record.Add(new DLoginRecord
            {
                UserName = username,
                RealName = realname,
                LoginTime = DateTime.Now,
                LoginIp = Request.UserHostAddress, //Tools.IPHelp.ClientIP,
                Location = "", //调用api获取...
                ClientInfo = new ClientInfo
                {
                    browser = Request.Browser.Browser + "-" + Request.Browser.Version,
                    platform = Request.Browser.Platform,
                    iscookies = Request.Browser.Cookies,
                    rawurl = Request.UrlReferrer.ToString()
                }
            });

            BufHelp.ProtoBufSerialize<List<DLoginRecord>>(record, filename);
        }

        //...

    }
}