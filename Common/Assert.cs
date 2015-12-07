using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//#if DNXCORE50
//using ApplicationException = global::System.InvalidOperationException;
//#endif

namespace Common
{
    /// <summary>
    /// Assert extensions borrowed from Sam's code in DapperTests
    /// </summary>
    static internal class Assert
    {
        public static void IsEqualTo<T>(this T obj, T other)
        {
            if (!obj.Equals(other))
            {
                throw new ApplicationException(string.Format("{0} should be equals to {1}", obj, other));
            }
        }

        public static void IsMoreThan(this int obj, int other)
        {
            if (obj < other)
            {
                throw new ApplicationException(string.Format("{0} should be larger than {1}", obj, other));
            }
        }

        public static void IsMoreThan(this long obj, int other)
        {
            if (obj < other)
            {
                throw new ApplicationException(string.Format("{0} should be larger than {1}", obj, other));
            }
        }

        public static void IsSequenceEqualTo<T>(this IEnumerable<T> obj, IEnumerable<T> other)
        {
            if (!obj.SequenceEqual(other))
            {
                throw new ApplicationException(string.Format("{0} should be equals to {1}", obj, other));
            }
        }

        public static void IsFalse(this bool b)
        {
            if (b)
            {
                throw new ApplicationException("Expected false");
            }
        }

        public static void IsTrue(this bool b)
        {
            if (!b)
            {
                throw new ApplicationException("Expected true");
            }
        }

        public static void IsNull(this object obj)
        {
            if (obj != null)
            {
                throw new ApplicationException("Expected null");
            }
        }
        public static void IsNotNull(this object obj)
        {
            if (obj == null)
            {
                throw new ApplicationException("Expected not null");
            }
        }

    }

    static internal class CollectioncExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> genericEnumerable)
        {
            return ((genericEnumerable == null) || (!genericEnumerable.Any()));
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> genericCollection)
        {
            return (genericCollection == null || genericCollection.Count < 1);
        }
    }

    static internal class StringExtension
    {
        public static string KeepQueryStringSafe(this string sqlQueryString)
        {
            return ConvertToSafeSQL(sqlQueryString);
        }

        /// <summary>
        /// 转换危险SQL标识字符
        /// </summary>
        /// <returns></returns>
        private static string ConvertToSafeSQL(string text)
        {
            text = Regex.Replace(text, "where", "wh&#101;re", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "select", "sel&#101;ct", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "insert", "ins&#101;rt", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "create", "cr&#101;ate", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "delete", "del&#101;te", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "count", "c&#111;unt", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "drop", "dro&#112", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "truncate", "truncat&#101;", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "asc", "as&#99;", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "mid", "m&#105;d", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "char", "ch&#97;r", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "xp_cmdshell", "xp_cmdsh&#101;ll", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "exec", "ex&#101;c", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "administrators", "administr&#97;tors", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "and", "a&#110;d", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "user", "us&#101;r", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "update", "up&#100;ate", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "or", "o&#114;", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "net", "n&#101;t", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text,"*", "", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text,"-", "", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "script", "s&#99;ript", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "alter", "alt&#101;r", RegexOptions.IgnoreCase);
            return text;
        }
        /// <summary>
        //　转换成过虑前的SQL字符串
        /// </summary>
        private static string ConvertToOriginalSql(string text)
        {
            //删除与数据库相关的词
            /*
                 return str.Replace("<br />\r\n", "\r\n").Replace("&", "&amp;").Replace("'", "&apos;")
             *             .Replace("\"", "&quot;").Replace(" ", "&nbsp;").Replace("<", "&lt;").Replace(">", "&gt;")
             *             .Replace(" ", "&nbsp;").Replace(" where ", " wh&#101;re ").Replace(" select ", " sel&#101;ct ")
             *             .Replace(" insert ", " ins&#101;rt ").Replace(" create ", " cr&#101;ate ")
             *             .Replace(" drop ", " dro&#112 ").Replace(" alter ", " alt&#101;r ").Replace(" delete ", " del&#101;te ")
             *             .Replace(" update ", " up&#100;ate ").Replace(" or ", " o&#114; ").Replace("\"", "&#34;").Replace("\r\n", "<br />\r\n");
             */
            text = Regex.Replace(text, "wh&#101;re", "where", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "sel&#101;ct", "select", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "ins&#101;rt", "insert", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "cr&#101;ate", "create", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "del&#101;te", "delete", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "c&#111;unt", "count", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "dro&#112", "drop", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "truncat&#101;", "truncate", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "asc", "as&#99;", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "m&#105;d", "mid", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "ch&#97;r", "char", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "xp_cmdsh&#101;ll", "xp_cmdshell", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "ex&#101;c", "exec", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "administr&#97;tors", "administrators", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "a&#110;d", "and", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "us&#101;r", "user", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "up&#100;ate", "update", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "o&#114;", "or", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "n&#101;t", "net", RegexOptions.IgnoreCase);
            //text =  Regex.Replace(text,"*", "", RegexOptions.IgnoreCase);
            //text =  Regex.Replace(text,"-", "", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, "s&#99;ript", "script", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "alt&#101;r", "alter", RegexOptions.IgnoreCase);
            return text;
        }
    }

    //...

}