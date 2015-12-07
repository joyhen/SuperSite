using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Model
{
    internal class XmlTransform
    {
        public static string Serialize(object value)
        {
            if (value == null)
            {
                return null;
            }

            XmlSerializer xs = new XmlSerializer(value.GetType());
            StringBuilder sb = new StringBuilder();
            xs.Serialize(new StringWriter(sb), value);

            var reg1 = new Regex(@"[\s]*xmlns:[\w]*?=""[\w\W]*?""");
            string temp = reg1.Replace(sb.ToString(), string.Empty);

            var reg2 = new Regex(@"<[?]xml[\w\W]+?[?]>");
            temp = reg2.Replace(temp, string.Empty);
            temp = ClearSpecialChar(temp);

            return temp;
        }

        public static T Deserialize<T>(string xml)
        {
            try
            {
                if (!string.IsNullOrEmpty(xml))
                {
                    XmlSerializer xs;
                    StringReader sr = new StringReader(xml);
                    xs = new XmlSerializer(typeof(T));
                    return (T)xs.Deserialize(sr);
                }
                else
                {
                    return default(T);
                }
            }
            catch //(Exception ex)  
            {
                return default(T);
            }
        }

        /// <summary>  
        /// 清除特殊字符  
        /// </summary>  
        private static string ClearSpecialChar(string sourceString)
        {
            string pattern = @"[\u0000-\u0008]|[\u000B-\u000C]|[\u000E-\u001F]";
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

            string temp = reg.Replace(sourceString, "");
            //&#x{0:X};   
            return Regex.Replace(temp, "&#x[0-9a-f]{1,6};", "", RegexOptions.IgnoreCase);
        }
    }
}
