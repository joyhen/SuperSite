using Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Tools
{
    /// <summary>
    /// 序列化、反序列化 处理类
    /// </summary>
    public class JsonUtils
    {
        private static readonly IsoDateTimeConverter _timeFormat;
        static JsonUtils()
        {
            _timeFormat = _timeFormat = new IsoDateTimeConverter()
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
        }

        /// <summary>
        /// 序列化
        /// </summary>
        public static string JsonSerializer(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings()
            {
                //驼峰结构，和js的写法保存一致
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Converters = new JsonConverter[1] { _timeFormat }
            });
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        public static T DeserializeObject<T>(string str)
        {
            if (string.IsNullOrEmpty(str)) return default(T);

            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (System.Exception ex)
            {
                LogHelp.WriteLog(ex.Message, EnumCenter.LogType.DeserializeObject);
                return default(T);
            }
        }
    }
}
