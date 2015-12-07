using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Model.Entity
{
    /// <summary>
    /// 系统用户
    /// </summary>
    [Dapper.Contrib.Extensions.Table("SysUser"), Serializable]
    public class SysUser : ZZLBaseEentity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 用户性别,0女性，1男性，>=2中性
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// 用户图像地址
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 用户角色Id
        /// </summary>
        [System.ComponentModel.DefaultValue(0)]
        public int RoleTag { get; set; }
        /// <summary>
        /// 用户状态：0禁用，1正常，2删除
        /// </summary>
        [System.ComponentModel.DefaultValue(1)]
        public int State { get; set; }
        /// <summary>
        /// 登录口令
        /// </summary>
        /// <remarks>
        /// 不能为Null
        /// http://blog.sina.com.cn/s/blog_455332580101awp6.html
        /// </remarks>
        public Object Question { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 获取用户设置的登录口令
        /// </summary>
        public DTO.TupleIntString GetLoginQuestion()
        {
            if (Question == null) return new DTO.TupleIntString();

            return XmlTransform.Deserialize<DTO.TupleIntString>(Question.ToString());
        }

        //...

    }
}