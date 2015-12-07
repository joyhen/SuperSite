using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace SuperSite.admin.control
{
    /// <summary>
    /// 语言用户控件数据源对象
    /// </summary>
    public class LanguageLabel
    {
        public BaseUserControl.RenderType Lan { get; set; }
        public string LabelName { get; set; }
        public Model.DTO.CCTuple LanguageList { get; set; }
    }
}