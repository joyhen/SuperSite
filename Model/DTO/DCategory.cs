using System;
using System.Linq;
using System.Collections.Generic;

namespace Model.DTO
{
    public class DCategory
    {
        /// <summary>
        /// 样式表
        /// </summary>
        public string classname { get; set; }
        public int id { get; set; }
        public int? parentid { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int sortnumber { get; set; }
        public string sitemodel { get; set; }
        public bool? status { get; set; }
    }
}