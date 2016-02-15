using System;

namespace Model.DTO
{
    /// <summary>
    /// 动态输出时忽略此标记的属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IngoreProperty : System.Attribute
    {
    }

    public class MapCondition
    {
        public MapCondition(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
                throw new Exception("对象无效");

            var arr = param.Split('|');
            if (arr == null || arr.Length == 0)
                throw new Exception("对象无效");

            this._orginal = arr[0];
            this._newname = arr.Length > 1 ? arr[1] : null;
        }

        private string _orginal = null;
        private string _newname = null;

        public string Orginal
        {
            get { return _orginal; }
            private set { _orginal = value; }
        }

        public string NewName
        {
            get { return _newname; }
            private set { _newname = value; }
        }

        //public Tuple<string, string> mapProperty { get; set; }
        public Func<object, object> fn { get; set; }
    }
}