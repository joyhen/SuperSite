using System;
using System.Linq;
using System.Collections.Generic;

namespace Model
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class AjaxParama : IAjaxParama
    {
        public virtual string Action { get; set; }

        public object Arg { get; set; }

        /// <summary>
        /// js对象 转 c#对象
        /// </summary>
        /// <typeparam name="T">目标c#对象类型</typeparam>
        public T GetArg<T>() where T : Model.Arg.IAjaxArg, new()
        {
            if (Arg == null)
                return default(T);
            try
            {
                if (Arg.GetType() == typeof(Newtonsoft.Json.Linq.JObject))
                {
                    var jobjectAjaxArg = (Newtonsoft.Json.Linq.JObject)Arg;
                    return jobjectAjaxArg.ToObject<T>(new JsonSerializer
                    {
                        Converters = { new AjaxArgConverter<T>() },
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore //add
                    });

                    #region //此方法不健壮（JToken）
                    //string desJson = JsonConvert.SerializeObject(Arg);
                    //return JsonConvert.DeserializeObject<T>(desJson, new JsonSerializerSettings() { });
                    ////return JsonConvert.DeserializeObject<T>(desJson, new AjaxArgConverter());
                    #endregion
                }
                else if (Arg.GetType() == typeof(String))
                {
                    return JsonConvert.DeserializeObject<T>(Arg.ToString());
                }

                return (T)Arg;
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 获取ajax传递过来的对象信息
        /// </summary>
        /// <returns>注意，不可缓存，实时的</returns>
        public List<string> GetAjaxArgName2List<T>() where T : Model.Arg.IAjaxArg, new()
        {
            var jobjectAjaxArg = (Newtonsoft.Json.Linq.JObject)Arg;
            return jobjectAjaxArg.Children().Select(x => x.Path).ToList();
        }

        public class AjaxArgConverter<T> : CustomCreationConverter<T> where T : Model.Arg.IAjaxArg, new()
        {
            public override T Create(System.Type objectType)
            {
                return new T();
            }
        }
    }

    public interface IAjaxParama
    {
        string Action { get; set; }
    }
}
