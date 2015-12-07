using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tools
{
    public class HttpUtils
    {
        /// <summary>
        /// Http method方式：POST/GET
        /// </summary>
        public enum HttpMethod
        {
            [Description("POST")]
            POST,
            [Description("GET")]
            GET,
            [Description("PUT")]
            PUT,
            [Description("DELETE")]
            DELETE
        }

        /// <summary>
        /// http headers Content-Type
        /// </summary>
        public enum HttpContentType
        {
            [Description("application/json")]
            JSON,
            [Description("application/x-www-form-urlencoded")]
            FORM
        }

        /// <summary>
        /// http post提交数据
        /// </summary>
        /// <param name="url">提交地址</param>
        /// <param name="data">Json格式请求正文</param>
        /// <returns>响应正文</returns>
        public static string DoPost(string url, string data, int timeOut)
        {
            return DoPost(url, data, HttpContentType.JSON, timeOut);
        }
        /// <summary>
        /// http post提交数据
        /// </summary>
        /// <param name="url">提交地址</param>
        /// <param name="data">请求正文(form格式/json格式)，与contentType对应</param>
        /// <param name="contentType">请求正文类型（form/json）</param>
        /// <returns>响应正文</returns>
        public static string DoPost(string url, string data, HttpContentType contentType, int timeOut)
        {
            return Do(url, data, HttpMethod.POST, contentType, timeOut);
        }
        /// <summary>
        /// http 请求基础方法
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">请求正文</param>
        /// <param name="method">get/post</param>
        /// <param name="contentType">请求正文类型</param>
        /// <returns>响应正文</returns>
        private static string Do(string url, string data, HttpMethod method,
            HttpContentType contentType, int timeOut, bool requesterHeader = false)
        {
            string strRe = null;
            Stream reqStream = null, resStream = null;
            StreamReader streamReader = null;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Timeout = timeOut;
                //request.Method = method.GetDescription();
                request.Method = EnumUtils.GetDescription(method);
                //request.ContentType = contentType.GetDescription();
                request.ContentType = EnumUtils.GetDescription(contentType);
                if (HttpMethod.POST.Equals(method))
                {
                    byte[] byData = Encoding.UTF8.GetBytes(data);
                    request.ContentLength = byData.Length;
                    reqStream = request.GetRequestStream();
                    reqStream.Write(byData, 0, byData.Length);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    resStream = response.GetResponseStream();
                    streamReader = new StreamReader(resStream, Encoding.GetEncoding("UTF-8"));
                    strRe = streamReader.ReadToEnd();
                }
            }
            catch (WebException wex)
            {
                if (wex.Response == null) throw;

                resStream = wex.Response.GetResponseStream();
                streamReader = new StreamReader(resStream, Encoding.GetEncoding("UTF-8"));
                strRe = streamReader.ReadToEnd();
                if (!string.IsNullOrEmpty(strRe))
                {
                    LogHelp.WriteLog(url, Config.EnumCenter.LogType.NormalError);
                    throw new Exception(strRe);
                }
            }
            catch (Exception ex)
            {
                LogHelp.WriteLog(url, ex);
                throw;
            }
            finally
            {
                if (null != reqStream) reqStream.Close();
                if (null != streamReader) streamReader.Close();
                if (null != resStream) resStream.Close();

                sw.Stop();

                string logmsg = string.Format("{0} exec time:{1}ms", url, sw.ElapsedMilliseconds.ToString());
                LogHelp.WriteLog(logmsg);
            }

            return strRe;
        }

        /// <summary>
        /// http get请求数据(默认json格式的请求正文)
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns>响应正文</returns>
        public static string DoGet(string url, int timeOut, bool requesterHeader = true)
        {
            return DoGet(url, HttpContentType.JSON, timeOut, requesterHeader);
        }

        /// <summary>
        /// http get请求数据
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="contentType">请求正文类型</param>
        /// <returns>响应正文</returns>
        public static string DoGet(string url, HttpContentType contentType, int timeOut, bool requesterHeader = true)
        {
            return Do(url, null, HttpMethod.GET, contentType, timeOut, requesterHeader);
        }

        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <param name="url">URL.</param>
        public string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = true;

            WebResponse response = null;
            string responseStr = null;

            try
            {
                response = request.GetResponse();

                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                request = null;
                response = null;
            }

            return responseStr;
        }

        /// <summary>
        /// HTTP POST方式请求数据
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="param">POST的数据</param>
        /// <returns></returns>
        public static string HttpPost(string url, string param)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + param);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;

            StreamWriter requestStream = null;
            WebResponse response = null;
            string responseStr = null;

            try
            {
                requestStream = new StreamWriter(request.GetRequestStream());
                requestStream.Write(param);
                requestStream.Close();

                response = request.GetResponse();
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                request = null;
                requestStream = null;
                response = null;
            }

            return responseStr;
        }

        //...

    }
}
