using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Tools
{
    using Config;
    using Model.DTO;
    using System.Xml.Linq;

    public class SystemTips
    {
        /// <summary>
        /// 系统所有提示内容集
        /// </summary>
        public Dictionary<EnumCenter.TipModel, List<DTip>> SystemMessage()
        {
            var cachedata = CacheUtil.GetCache(KeyCenter.KeyMessageTipsCache)
                as Dictionary<EnumCenter.TipModel, List<DTip>>;

            if (cachedata == null)
            {
                cachedata = new Dictionary<EnumCenter.TipModel, List<DTip>>();
                var xmlpath = KeyCenter.KeyBaseDirectory + "Config\\Message.xml";
                var tipmodelarr = Enum.GetNames(typeof(EnumCenter.TipModel));


                XDocument xdoc;
                try
                {
                    xdoc = XDocument.Load(xmlpath);
                }
                catch
                {
                    return null;
                }

                foreach (var item in tipmodelarr) //后面很多模块的时候，请改用ParallelQuery ...
                {
                    var query = new List<DTip>();
                    var items = xdoc.Root.Elements(item.ToLower()).Elements("item");
                    if (items == null) continue;

                    foreach (var e in items)
                    {
                        query.Add(new DTip
                        {
                            Name = (string)e.Attribute("name"),
                            Language = GetLanguage(e)
                        });
                    }

                    cachedata.Add(EnumUtils.GetEnumBuyStr<EnumCenter.TipModel>(item), query);
                }

                if (cachedata != null && cachedata.Count > 0)
                    CacheUtil.InsertCach(KeyCenter.KeyMessageTipsCache, cachedata, durationMinutes: 60 * 24);
            }

            return cachedata;
        }

        private Model.DTO.CCTuple GetLanguage(XElement e)
        {
            if (e != null)
            {
                return new CCTuple(
                    (string)e.Attribute(EnumCenter.Lang.zhcn.ToString()),
                    (string)e.Attribute(EnumCenter.Lang.zhtw.ToString()),
                    (string)e.Attribute(EnumCenter.Lang.en.ToString())
                );
            }

            return null;
        }

        //...

    }
}