using System;
using System.Text;

namespace Tools
{
    using System.IO;
    using System.Xml.Serialization;
    using System.Text.RegularExpressions;

    public class XmlHelper
    {
        static XmlHelper()
        {

        }

        /// <summary>
        /// 序列化对象为xml文件  
        /// </summary>
        public static void SerializeXml(string xmlFilePath, object sourceObj, Type type, string xmlRootName)
        {
            if (!string.IsNullOrWhiteSpace(xmlFilePath) && sourceObj != null)
            {
                type = type != null ? type : sourceObj.GetType();

                using (StreamWriter writer = new StreamWriter(xmlFilePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrWhiteSpace(xmlRootName) ?
                        new System.Xml.Serialization.XmlSerializer(type) :
                        new System.Xml.Serialization.XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                    xmlSerializer.Serialize(writer, sourceObj);
                }
            }
        }
        /// <summary>
        /// 反序列化XML文件
        /// </summary>
        public static object DeserializeXml(string xmlFilePath, Type type)
        {
            object result = null;

            if (File.Exists(xmlFilePath))
            {
                using (StreamReader reader = new StreamReader(xmlFilePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(type);
                    result = xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }

        public static string Serialize(object value)
        {
            if (value == null)
            {
                return null;
            }

            var sb = new StringBuilder();
            XmlSerializer xs = new XmlSerializer(value.GetType());
            xs.Serialize(new StringWriter(sb), value);

            var reg = new Regex(@"[\s]*xmlns:[\w]*?=""[\w\W]*?""");
            string temp = reg.Replace(sb.ToString(), string.Empty);

            var reg2 = new Regex(@"<[?]xml[\w\W]+?[?]>");
            temp = reg2.Replace(temp, string.Empty);
            temp = ClearSpecialChar(temp);
            // "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>"  

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

        //...

    }
}
