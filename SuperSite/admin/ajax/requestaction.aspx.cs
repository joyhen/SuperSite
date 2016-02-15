using System;
using System.Web;
using System.Reflection;
using System.Collections.Generic;

namespace SuperSite.admin.ajax
{
    using Tools;
    using Model.Arg;
    using System.Linq;

    /// <summary>
    /// ajax请求入口
    /// </summary>
    public partial class requestaction : App_Code.BasePageRequest
    {
        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            switch (base.MapServerAction)
            {
                #region System
                case "Login":
                    Login();
                    break;
                case "AnswerQuesion":
                    AnswerQuesion();
                    break;
                case "GetLoginRecord":
                    GetLoginRecord();
                    break;
                case "LanguageSet":
                    LanguageSet();
                    break;
                case "ClearSystemCache":
                    ClearSystemCache();
                    break;

                case "UploadWebImg":
                    UploadWebImg();
                    break;

                case "GetNoticeType":
                    GetNoticeType();
                    break;
                case "AddNoticeType":
                    AddNoticeType();
                    break;
                #endregion

                #region SysUsers
                case "AddSysUser":
                    AddSysUser();
                    break;
                case "UpdateSysUser":
                    UpdateSysUser();
                    break;
                case "SetSysUserPwd":
                    SetSysUserPwd();
                    break;
                case "GetSysUsers":
                    GetSysUsers();
                    break;
                case "DeleteSysUser":
                    DeleteSysUser();
                    break;
                #endregion

                #region Setting
                case "SaveSystemSetting":
                    SaveSystemSetting();
                    break;
                case "SaveSiteSetting":
                    SaveSiteSetting();
                    break;
                #endregion

                #region Category

                case "PreviewCategory":
                    PreviewCategory();
                    break;
                case "GetCategory":
                    GetCategory();
                    break;
                case "SetCategoryStatus":
                    SetCategoryStatus();
                    break;
                case "SaveCategoryPage":
                    SaveCategoryPage();
                    break;
                case "AddCategory":
                    AddCategory();
                    break;
                case "UpdateCategory":
                    UpdateCategory();
                    break;
                case "DeleteCategory":
                    DeleteCategory();
                    break;

                #endregion

                #region Template

                #endregion

                #region ProgramInfo
                case "SaveSuperProgramInfo":
                    SaveSuperProgramInfo();
                    break;
                case "GetSuperProgramInfo":
                    GetSuperProgramInfo();
                    break;
                #endregion

                //...

                default:
                    Outmsg(false, "请求错误");
                    break;
            }
        }

        /// <summary>
        /// 系统预设的登录口令问题
        /// </summary>
        protected List<Tuple<int, string, string>> SystemDefaultQuestion()
        {
            var query = ParallelEnumerable.Range(1, 100);

            var data = Enumerable.Range(1, 10).Select(x => //取10个问题
            {
                var temp = query.OrderBy(e => Guid.NewGuid()).Take(2).ToArray();
                var p1 = temp[0];
                var p2 = temp[1];
                var question = string.Format("{0}+{1}=?", p1, p2);
                //序号、问题、答案
                return new Tuple<int, string, string>(x, question, temp.Sum().ToString());
            });

            return data.ToList();
        }

        //...

    }
}