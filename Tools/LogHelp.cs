using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace Tools
{
    using Config;

    public class LogHelp
    {
        public static void WriteLog(string msg)
        {
            WriteLog(msg, EnumCenter.LogType.NormalError);
        }

        public static void WriteLog(string msg, Exception ex)
        {
            var logmsg = string.Format("[{0}]{1}\r\n{2}\r\n\r\n", msg, ex.Message, ex.StackTrace);
            WriteLog(logmsg, EnumCenter.LogType.NormalError);
        }

        public static void WriteLog(string msg, EnumCenter.LogType logType, Action callbackAction = null)
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadFunc), "param");
            ThreadPool.QueueUserWorkItem((state) =>
            {
                Log(msg, logType);

                if (callbackAction != null)
                {
                    callbackAction.Invoke();
                }
            });
        }

        /// <summary>  
        /// 日志锁定  
        /// </summary>  
        private readonly static Object Lok = new Object();

        /// <summary>  
        /// 记录日志  
        /// </summary>  
        private static void Log(string Txt, EnumCenter.LogType logType = EnumCenter.LogType.NormalError)
        {
            if (string.IsNullOrWhiteSpace(Txt)) return;

            try
            {
                lock (Lok)
                {
                    string logDir = AppDomain.CurrentDomain.BaseDirectory;
                    string logPath = string.Format(@"{0}\Log\{1}", logDir, logType.ToString());
                    string logFile = string.Format(@"{0}\{1}.log", logPath, DateTime.Now.ToString(@"yy-MM-dd"));
                    //  
                    string logContent = string.Format("{0}\t{1}\r\n", DateTime.Now.ToString(@"HH:mm:ss"), Txt);
                    System.IO.Directory.CreateDirectory(logPath);
                    System.IO.File.AppendAllText(logFile, logContent);
                }
            }
            catch (System.Exception ex)
            {
                ex.ToString();
            }
        }

        private void ThreadFunc(object param)
        {

        }

        //...

    }
}
