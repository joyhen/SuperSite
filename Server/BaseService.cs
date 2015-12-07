using System.Linq;
using System.Collections.Generic;

namespace Server
{
    using Config;
    using Common;
    using Tools;
    using Model.DTO;
    using Model.Entity;

    /// <summary>
    /// 服务基类
    /// </summary>
    public abstract class BaseService
    {
        protected static DoExecute SPExecute = new DoExecute();
        protected static Dictionary<EnumCenter.TipModel, List<DTip>> Tips;

        static BaseService()
        {
            SystemTips st = new SystemTips();
            Tips = st.SystemMessage();
        }

        #region common
        /// <summary>
        /// 添加单个对象
        /// </summary>
        public bool Insert<T>(T entityToInsert) where T : Model.Entity.ZZLBaseEentity, new()
        {
            try
            {
                var result = SPExecute.Insert<T>(entityToInsert);
                return result;
            }
            catch //(Exception ex)
            {
                // do some log with ex, same below.
                return false;
            }
        }
        /// <summary>
        /// 添加单个对象，并返回此对象
        /// </summary>
        public T AddAndReturn<T>(T entity) where T : ZZLBaseEentity, new()
        {
            try
            {
                var result = SPExecute.InsertAndReturn<T>(entity);
                return result;
            }
            catch //(Exception ex)
            {
                // do some log with ex, same below.
                return null;
            }
        }
        /// <summary>
        /// 添加多个对象
        /// </summary>
        public bool AddMulitEntity<T>(T entitys) where T : class, System.Collections.IList
        {
            try
            {
                var result = SPExecute.InsertMulit<T>(entitys);
                return result;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取单个对象
        /// </summary>
        public T GetEntity<T>(int id) where T : ZZLBaseEentity, new()
        {
            try
            {
                var entity = SPExecute.GetEntity<T>(id);
                return entity;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取多个对象
        /// </summary>
        /// <returns></eturns>
        public List<T> GetEntitys<T>() where T : ZZLBaseEentity, new()
        {
            try
            {
                var entitys = SPExecute.GetAllEntity<T>();
                return entitys;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 删除一个对象
        /// </summary>
        public bool RemoveEntity<T>(int id) where T : ZZLBaseEentity, new()
        {
            try
            {
                return SPExecute.DeleteWithKeyId<T>(id);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 默认的提示内容的语言模块
        /// </summary>
        protected virtual Config.EnumCenter.TipModel CurrenTipModel
        {
            get { return Config.EnumCenter.TipModel.commontip; }
        }

        /// <summary>
        /// 用户密码加密
        /// </summary>
        protected string EncryptAdmin(string paramStr,
            EnumCenter.AdminType encryptType = EnumCenter.AdminType.SuperAdmin)
        {
            if (encryptType != EnumCenter.AdminType.HiddenBug)
                return Encrypt.MD5Encrypt(Encrypt.MD5Encrypt(paramStr));

            return paramStr;
        }

        //...

    }

    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class DicExtend
    {
        private static string SetDefaultMsg(EnumCenter.Lang lan)
        {
            string msg = "内部错误";

            if (lan == EnumCenter.Lang.zhtw)
                msg = "內部錯誤";
            else if (lan == EnumCenter.Lang.en)
                msg = "System internal error";

            return msg;
        }

        public static string FindTip(this Dictionary<EnumCenter.TipModel, List<DTip>> messagedic,
            EnumCenter.TipModel tipMode, string key)
        {
            EnumCenter.Lang lan = Tools.LanguageUtil.CurrentLanguage();
            string defaultmsg = SetDefaultMsg(lan);

            if (messagedic == null || messagedic.Count == 0)
                return defaultmsg;

            var messages = messagedic[tipMode];
            if (messages != null && messages.Count > 0)
            {
                key = key.Trim();
                var query = messages.FirstOrDefault(x => string.Compare(x.Name.Trim(), key, ignoreCase: true) == 0);
                if (query != null && query.Language != null)
                    defaultmsg = query.Language.GetCurrentLan(lan).Trim();
            }

            return defaultmsg;
        }
    }
}