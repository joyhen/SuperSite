using System;
using System.ComponentModel;
using System.Reflection;

namespace Tools
{
    public class EnumUtils
    {
        /// <summary>
        /// 获取枚举类型的DescriptionAttribute(扩展方法)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetDescription(Enum obj)
        {
            Type _enumType = obj.GetType();

            FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, obj));
            var dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

            if (dna != null && !string.IsNullOrEmpty(dna.Description))
                return dna.Description;

            return obj.ToString();
        }

        /// <summary>
        /// /字符串转枚举
        /// </summary>
        public static T GetEnumBuyStr<T>(string str)
        {
            try
            {
                T enumOne = (T)Enum.Parse(typeof(T), str);
                return enumOne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //...

    }
}
