using System;
using System.Web;
using System.Linq;
using System.Transactions;
using System.Collections.Generic;

namespace SuperSite.admin.ajax
{
    using Tools;
    using Config;
    using Model.Arg;
    using Model.DTO;
    using Model.Entity;

    public partial class requestaction
    {
        /// <summary>
        /// 预览栏目
        /// </summary>
        private void PreviewCategory()
        {
            var data = new Server.CategoryService().GetCategoryData();
            if (data == null) Outmsg(false, "获取栏目数据失败", data);

            var result = new List<DCategory>();
            var parentCategory = data.Where(x => x.Status.Value && !x.ParentId.HasValue || x.ParentId.Value <= 0)
                                    .OrderBy(o => o.SortNumber);    //父级栏目

            var strb = new System.Text.StringBuilder();
            var templateP = @"
<li class=""mainmenu"">
    <a target=""_blank"" href=""{0}"">{1}</a>
    {2}
</li>";
            var templateC = @"
<li>
    <a target=""_blank"" href=""{0}"">{1}</a>
</li>";

            foreach (var x in parentCategory)
            {
                var childCategory = data.Where(c => c.ParentId == x.Id)
                                        .OrderBy(o => o.SortNumber);//子级栏目

                var strbb = new System.Text.StringBuilder();
                if (childCategory.Count() > 0)
                {
                    strbb.Append("<ul class=\"childcategory\">");
                    foreach (var c in childCategory)
                        strbb.AppendFormat(templateC, NotEmptyString(c.Url) ? c.Url : FormatUrl(x.Url, c.Id), c.Name);
                    strbb.Append("</ul>");
                }

                strb.AppendFormat(templateP, x.Url, x.Name, strbb.ToString());
            }

            Outmsg(true, outdata: strb.ToString());
        }
        /// <summary>
        /// 获取所有栏目
        /// </summary>
        private void GetCategory()
        {
            var data = new Server.CategoryService().GetCategoryData();
            if (data == null) Outmsg(false, "获取数据失败", data);

            var result = new List<DCategory>();
            var parentCategory = data.Where(x => x.Status.Value && !x.ParentId.HasValue || x.ParentId.Value <= 0)
                                    .OrderBy(o => o.SortNumber);    //父级栏目
            foreach (var x in parentCategory)
            {
                result.Add(new DCategory
                {
                    classname = " isparent",
                    id = x.Id,
                    parentid = x.ParentId,
                    name = x.Name,
                    url = x.Url,
                    sortnumber = x.SortNumber,
                    status = x.Status,
                    sitemodel = (x.SiteModel ?? 0) <= 0 ?
                    "" : ((EnumCenter.SiteModelStyle)x.SiteModel.Value).ToString()
                });

                var childCategory = data.Where(c => c.ParentId == x.Id)
                                        .OrderBy(o => o.SortNumber);//子级栏目
                result.AddRange(childCategory.Select(c => new DCategory
                {
                    classname = " ischilad class_" + x.Id,
                    id = c.Id,
                    parentid = c.ParentId,
                    name = c.Name,
                    url = NotEmptyString(c.Url) ? c.Url : FormatUrl(x.Url, c.Id),
                    sortnumber = c.SortNumber,
                    status = c.Status,
                    sitemodel = (c.SiteModel ?? 0) <= 0 ?
                    "" : ((EnumCenter.SiteModelStyle)c.SiteModel.Value).ToString()
                }));
            }

            Outmsg(data != null, "获取数据失败", result);
        }
        /// <summary>
        /// 子栏目URL处理
        /// </summary>
        /// <param name="url">子栏目父级的url</param>
        /// <param name="id">子栏目id</param>
        private string FormatUrl(string url, int id)
        {
            if (!NotEmptyString(url)) return "";

            var arr = url.Split('.');
            var lastprv = arr[arr.Length - 2];
            return url.Replace(lastprv, lastprv + id.ToString());
        }

        /// <summary>
        /// 设置栏目状态
        /// </summary>
        private void SetCategoryStatus()
        {
            int id = ((dynamic)(ActionParama.Arg)).id;
            bool st = ((dynamic)(ActionParama.Arg)).st;
            if (id <= 0) Outmsg("参数错误");

            var result = new Server.CategoryService().Update_CategoryStatus(id, st ? 1 : 0);
            Outmsg(result, outmsg: "设置栏目状态失败");
        }

        /// <summary>
        /// 栏目页面保存当前栏目状态
        /// </summary>
        private void SaveCategoryPage()
        {
            var argdata = base.GetActionParamData<PArgCategoryPage>(true);

            if (argdata == null || argdata.items == null)
            {
                Outmsg("参数解析错误");
                return;
            }

            var tag = 0;

            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in argdata.items)
                {
                    var result = new Server.CategoryService().Update_CategoryPage(item);
                    tag += result ? 1 : 0;
                }
                scope.Complete();
            }

            Outmsg(tag == argdata.items.Count, "保存栏目信息失败！");
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        private void AddCategory()
        {
            var argdata = base.GetActionParamData<PArgCategory>(true);
            if (argdata == null)
            {
                Outmsg("参数解析错误");
                return;
            }

            var dbdata = new Model.Entity.Category
            {
                ParentId = argdata.parentid.ToPositiveInt(),
                Name = argdata.name.Trim(),
                SiteModel = argdata.sitemodel,
                Url = argdata.url.Trim().Replace("。", "."),
                ListTemplate = argdata.listtemplate.Trim(),
                ContentTemplate = argdata.contenttemplate.Trim(),
                Status = argdata.status.ToNullableBoolean(),
                TargetBlank = argdata.targetblank.ToNullableBoolean(),
                ShowFoot = argdata.showfoot.ToNullableBoolean(),
                SortNumber = argdata.sortnumber,
                Content = HttpUtility.HtmlDecode(argdata.content),
                AddTime = DateTime.Now,
                AddUser = CurrentUser.UserName
            };

            var result = new Server.CategoryService().Insert_Category(dbdata);
            if (result) CacheUtil.Remove(KeyCenter.KeySystemSettingCache);
            Outmsg(result, "添加栏目失败！");
        }

        /// <summary>
        /// 更新栏目
        /// </summary>
        private void UpdateCategory()
        {
            var argdata = base.GetActionParamData<PArgCategory>(true);
            if (argdata == null || argdata.id <= 0)
            {
                Outmsg("参数解析错误");
                return;
            }

            var dbdata = new Server.CategoryService().GetSingleCategoryData(argdata.id);
            if (dbdata == null || dbdata.Id != argdata.id || string.IsNullOrWhiteSpace(dbdata.Name))
            {
                Outmsg("数据校验失败");
                return;
            }

            var result = new Server.CategoryService().Update_Category(new Category
            {
                Id = argdata.id,
                ParentId = argdata.parentid.ToPositiveInt(),
                Name = argdata.name.Trim(),
                SiteModel = argdata.sitemodel,
                Url = argdata.url.Trim().Replace("。", "."),
                ListTemplate = argdata.listtemplate.Trim(),
                ContentTemplate = argdata.contenttemplate.Trim(),
                Status = argdata.status.ToNullableBoolean(),
                TargetBlank = argdata.targetblank.ToNullableBoolean(),
                ShowFoot = argdata.showfoot.ToNullableBoolean(),
                SortNumber = argdata.sortnumber,
                Content = argdata.content,
            });

            Outmsg(result, "更新栏目信息失败");
        }

        /// <summary>
        /// 删除现有栏目
        /// </summary>
        private void DeleteCategory()
        {
            int id = ((dynamic)(ActionParama.Arg)).id;
            bool tag = ((dynamic)(ActionParama.Arg)).tag;
            if (id <= 0) Outmsg("参数错误");

            Outmsg("您无权删除" + id.ToString() + " " + tag.ToString());

            //var result = new Server.CategoryService().Delete_Category(id, tag);
            //Outmsg(result, outmsg: "删除栏目失败");
        }

        //...

    }
}