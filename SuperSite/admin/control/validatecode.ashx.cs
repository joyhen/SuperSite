using System;
using System.IO;
using System.Web;

namespace SuperSite.admin.control
{
    using Config;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Drawing2D;
    using System.Web.SessionState;

    /// <summary>
    /// validatecode 的摘要说明
    /// </summary>
    public class validatecode : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string Vnum = MakeValidateCode();
            //Vnum = "1234";
            context.Session[KeyCenter.KeyValidateCodeSession] = Vnum.ToLower();

            CreateCheckCodeImage(context, Vnum);
        }

        private string MakeValidateCode(int len = 4)
        {
            //char[] s = new char[]{'2','3','4','6','7','8','9','b'
            //,'c','d','e','f','g','h','j','k','m','n','p','q'
            //,'a','r','t','w','x','y','A','C','D','E','F','G'
            //,'H','J','K','M','N','P','Q','R','S','T','U','W'
            //,'X','Y'};
            char[] s = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            string num = "";
            len = Math.Max(4, len);

            Random r = new Random();

            for (int i = 0; i < len; i++)
            {
                num += s[r.Next(0, s.Length)].ToString();
            }

            return num.ToLower();//注意是小写的哦
        }

        private void CreateCheckCodeImage(HttpContext context, string checkCode)
        {
            if (string.IsNullOrWhiteSpace(checkCode) || checkCode.Trim().Length == 0)
                return;

            Bitmap image = new Bitmap((int)Math.Ceiling((checkCode.Length * 14.5)), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //重置背景色
                g.Clear(Color.FromArgb(251, 251, 251));

                Font font = new System.Drawing.Font("Arial", 12, (FontStyle.Regular | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(0, 0, image.Width, image.Height),
                    Color.Black,
                    Color.Black,
                    1.2f,
                    true
                );
                g.DrawString(checkCode, font, brush, 6, 2);

                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);

                context.Response.ClearContent();
                context.Response.ContentType = "image/Gif";
                context.Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}