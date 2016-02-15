using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace SuperSite.App_Code
{
    using Tools;
    using Config;
    using Model;
    using Model.Arg;
    using admin.ajax;

    /// <summary>
    /// ajax处理请求基类
    /// </summary>
    public class BasePageRequest : BasePage
    {
        #region 属性

        /// <summary>
        /// 当前操作需要的参数对象
        /// </summary>
        protected AjaxParama ActionParama = null;
        /// <summary>
        /// 当前操作方法名的客户端签名
        /// </summary>
        protected string ClientAction
        {
            get
            {
                if (ActionParama == null)
                    return string.Empty;

                return ActionParama.Action ?? string.Empty;
            }
        }
        /// <summary>
        /// 客户端签名方法映射的服务端方法
        /// </summary>
        protected string MapServerAction { get; set; }

        #endregion

        /// <summary>
        /// 进行初始化
        /// </summary>
        /// <remarks>注意，ajax参数对象必须是json格式</remarks>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddMilliseconds(-1);
            Response.Expires = 0;
            Response.Cache.SetNoStore();                        // 禁用缓存
            Response.Clear();                                   // 清除输出
            Response.CacheControl = "no-cache";
            Response.AppendHeader("Pragma", "No-Cache");

            if (HttpContext.Current.Request.UrlReferrer == null ||
                HttpContext.Current.Request.UrlReferrer.Host != HttpContext.Current.Request.Url.Host)
            {
                Outmsg(false, "非正常请求");
            }

            string requestData = string.Empty;                  //请求参数
            string requestType = Request.RequestType.ToUpper(); //请求方式

            if (requestType == "POST")
            {
                var iptStream = HttpContext.Current.Request.InputStream;
                var byts = new byte[iptStream.Length];
                HttpContext.Current.Request.InputStream.Read(byts, 0, byts.Length);
                requestData = System.Text.Encoding.UTF8.GetString(byts);
            }
            else if (requestType == "GET")
            {
                requestData = Q(KeyCenter.KeyAjaxActionNameWhenGet);
            }

            if (!string.IsNullOrWhiteSpace(requestData))
            {
                ActionParama = JsonUtils.DeserializeObject<AjaxParama>(requestData);
                if (ActionParama == null)
                {
                    Outmsg(false, "请求错误");
                }
                if (string.IsNullOrWhiteSpace(ClientAction))
                {
                    Outmsg(false, "请求无效");
                }
            }

            CheckAction();
        }
        /// <summary>
        /// 加载
        /// </summary>
        public virtual void Page_Load(object sender, EventArgs e)
        {
            //do something...
        }

        /// <summary>
        /// 请求方法校验，并执行对应方法
        /// <remarks>校验当前操作权限</remarks>
        /// </summary>
        private void CheckAction()
        {
            //var datawithcache = basepage.GetDataWithCache<RightAction>("SP_SystemAction", () =>
            //{
            //    return GetActionHandlerInfo();
            //});

            //var queryRightAction = GetActionHandlerInfo();
            var queryRightAction = GetActionHandlerInfo;
            if (queryRightAction == null || queryRightAction.Count == 0) Outmsg(false, "内部错误");

            var currentAction = queryRightAction.FirstOrDefault(x => x.ClientName == ClientAction);
            if (currentAction == null) Outmsg(false, "请求无效");
            if (currentAction.CheckLogin && !base.CheckUserLogin()) Outmsg(false, "请先登录");

            MapServerAction = currentAction.ActionName;
        }
        /// <summary>
        /// 执行方法
        /// <remarks>暂时没有用到</remarks>
        /// </summary>
        /// <param name="ddlpath">eg: .admin.ajax.requestaction</param>
        protected virtual void ExecuteAction(string ddlpath)
        {
            const string assembly = "SuperSite";

            var asm = System.Reflection.Assembly.Load(assembly).CreateInstance(assembly + ddlpath);
            var method = asm.GetType().GetMethod(MapServerAction);

            try
            {
                method.Invoke(asm, new object[] { ActionParama });
            }
            catch (Exception ex)
            {
                LogHelp.WriteLog("反射方法调用出错", ex);
                Outmsg(outmsg: "内部错误");
            }
        }

        /// <summary>
        /// 获取ajax参数对象
        /// </summary>
        /// <param name="checkParam">是否校验（如果有参数，建议校验）</param>
        protected T GetActionParamData<T>(bool checkParam = false) where T : class, IAjaxArg, new()
        {
            if (checkParam)
            {
                var listAjaxParamName = ActionParama.GetAjaxArgName2List<T>();
                if (listAjaxParamName == null) Outmsg(false, "参数解析错误");

                var listAjaxParamTargetModelFieldName = ReflectionMapr<T>.GetAjaxParamName();
                bool exist = listAjaxParamTargetModelFieldName.All(x => listAjaxParamName.Contains(x));

                if (!exist) Outmsg(false, "非正常请求");
            }

            var ajaxPraramData = ActionParama.GetArg<T>();
            return ajaxPraramData;
        }

        /// <summary>
        /// 获取系统所有ajax操作方法信息
        /// </summary>
        protected List<RightAction> GetActionHandlerInfo
        {
            get
            {
                var action = new List<RightAction>();
                action.Add(new RightAction { ActionName = "Login", CheckLogin = false });
                action.Add(new RightAction { ActionName = "AnswerQuesion", CheckLogin = false });
                action.Add(new RightAction { ActionName = "GetLoginRecord" });
                action.Add(new RightAction { ActionName = "LanguageSet" });
                action.Add(new RightAction { ActionName = "ClearSystemCache" });
                action.Add(new RightAction { ActionName = "UploadWebImg" });

                action.Add(new RightAction { ActionName = "GetNoticeType" });
                action.Add(new RightAction { ActionName = "AddNoticeType" });


                action.Add(new RightAction { ActionName = "GetMenu" });

                action.Add(new RightAction { ActionName = "AddSysUser" });
                action.Add(new RightAction { ActionName = "UpdateSysUser" });
                action.Add(new RightAction { ActionName = "SetSysUserPwd" });
                action.Add(new RightAction { ActionName = "GetSysUsers" });
                action.Add(new RightAction { ActionName = "DeleteSysUser" });

                action.Add(new RightAction { ActionName = "SaveSystemSetting" });
                action.Add(new RightAction { ActionName = "SaveSiteSetting" });


                action.Add(new RightAction { ActionName = "PreviewCategory" });
                action.Add(new RightAction { ActionName = "GetCategory" });
                action.Add(new RightAction { ActionName = "SetCategoryStatus" });
                action.Add(new RightAction { ActionName = "SaveCategoryPage" });
                action.Add(new RightAction { ActionName = "AddCategory" });
                action.Add(new RightAction { ActionName = "UpdateCategory" });
                action.Add(new RightAction { ActionName = "DeleteCategory" });

                action.Add(new RightAction { ActionName = "SaveSuperProgramInfo" });
                action.Add(new RightAction { ActionName = "GetSuperProgramInfo" });
                
                //...

                return action;
            }
        }


        //...

    }
}