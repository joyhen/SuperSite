using System;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;

namespace Tools
{
    /// <summary>
    /// 通用加密/解密类。
    /// </summary>
    public class Encrypt
    {
        /// <summary>
        /// 秘钥
        /// </summary>
        private static readonly string EncryptKey = "yj{>15^)loveyouever";

        #region ========DES加密========

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="Text">待加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string Text)
        {
            return DESEncrypt(Text, EncryptKey);
        }

        /// <summary> 
        /// DES加密数据 
        /// </summary> 
        /// <param name="Text">待加密的字符串</param> 
        /// <param name="sKey">加密密钥</param> 
        /// <returns>加密后的字符串</returns> 
        public static string DESEncrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);

            string encryptKey = FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8);

            des.Key = ASCIIEncoding.ASCII.GetBytes(encryptKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(encryptKey);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========DES解密========

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="Text">待解密的字符串</param>
        /// <returns>解密后的明文</returns>
        public static string DESDecrypt(string Text)
        {
            return DESDecrypt(Text, EncryptKey);
        }

        /// <summary> 
        /// DES解密数据 
        /// </summary> 
        /// <param name="Text">待解密的字符串</param> 
        /// <param name="sKey">解密密钥</param> 
        /// <returns>解密后的明文</returns> 
        public static string DESDecrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }

            string encryptKey = FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8);

            des.Key = ASCIIEncoding.ASCII.GetBytes(encryptKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(encryptKey);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion

        #region ========MD5加密========
        public static string MD5Encrypt(string paramstr)
        {
            return MD5Encrypt(paramstr, "loveyajuan");
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        public static string MD5Encrypt(string paramstr, string key)
        {
            string tempStr = FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5");
            return FormsAuthentication.HashPasswordForStoringInConfigFile(paramstr + tempStr, "MD5").ToLower();
        }
        #endregion

        #region ======Base64编解码=====

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="code_type">编码类型</param>
        /// <param name="code">待编码的字符串</param>
        public static string Base64Encode(string code_type, string code)
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(code_type).GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }
        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="code_type">编码类型</param>
        /// <param name="code">带解码的字符串</param>
        public static string Base64Decode(string code_type, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }
        #endregion
    }
}