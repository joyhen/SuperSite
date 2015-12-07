using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Model.DTO
{
    [Serializable]
    public class DTip
    {
        public DTip() { }

        public string Name { get; set; }

        public CCTuple Language { get; set; }
    }

    /// <summary>
    /// 语言集（数据结构后期需要修改）
    /// </summary>
    [Serializable]
    public class CCTuple
    {
        public CCTuple() { }

        public CCTuple(string zhcn, string zhtw, string en)
        {
            _item1 = zhcn;
            _item2 = zhtw;
            _item3 = en;
        }

        public string GetCurrentLan(Config.EnumCenter.Lang elan)
        {
            if (elan == Config.EnumCenter.Lang.zhtw)
                return ChineseTW;
            else if (elan == Config.EnumCenter.Lang.en)
                return English;
            else
                return Chinese;
        }

        private string _item1 = string.Empty;
        public string Chinese
        {
            get { return _item1; }
            set { _item1 = value; }
        }
        private string _item2 = string.Empty;
        public string ChineseTW
        {
            get { return _item2; }
            set { _item2 = value; }
        }
        private string _item3 = string.Empty;
        public string English
        {
            get { return _item3; }
            set { _item3 = value; }
        }
    }
}