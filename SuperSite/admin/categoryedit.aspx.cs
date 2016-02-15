﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace SuperSite.admin
{
    using Tools;
    using Config;
    using Model.DTO;

    public partial class categoryedit : App_Code.BasePageBusiness
    {
        protected List<KeyValue> PageParentCategory;
        protected List<KeyValue> PageSiteModelSiteModelStyle;
        protected Model.Entity.Category PageCategory;

        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                PageParentCategory = GetParentCategory() ?? new List<KeyValue>();
                PageSiteModelSiteModelStyle = GetSiteModelStyle();
                PageCategory = GetSingleCategory();
            }
        }

        /// <summary>
        /// 获取父栏目
        /// </summary>
        private List<KeyValue> GetParentCategory()
        {
            var data = new Server.CategoryService().GetCategoryData();
            return data.Where(x => x.Status.Value && !x.ParentId.HasValue || x.ParentId.Value <= 0)
                            .OrderBy(x => x.SortNumber)
                            .Select(x => new KeyValue { key = x.Id.ToString(), value = x.Name })
                            .ToList();
        }

        /// <summary>
        /// 获取栏目模型
        /// </summary>
        private List<KeyValue> GetSiteModelStyle()
        {
            var data = Enum.GetNames(typeof(EnumCenter.SiteModelStyle));
            return data.Select(x => new KeyValue
            {
                value = x,
                key = ((int)EnumUtils.GetEnumBuyStr<EnumCenter.SiteModelStyle>(x)).ToString()
            }).ToList();
        }

        /// <summary>
        /// 获取栏目信息
        /// </summary>
        private Model.Entity.Category GetSingleCategory()
        {
            var data = new Server.CategoryService().GetSingleCategoryData(QInt("id"));
            return data;
        }

        //...

    }
}