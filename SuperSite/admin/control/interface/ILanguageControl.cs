using System;

namespace SuperSite.admin.control
{
    /// <summary>
    /// 涉及到多语言显示的标签控件接口
    /// </summary>
    public interface ILanguageControl
    {
        LanguageLabel Language { get; set; }
    }
}