using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Server
{
    internal class BaseADOService
    {
        /// <summary>
        /// 校验数据集
        /// </summary>
        public static bool CheckDS(DataSet ds)
        {
            return ds != null && ds.Tables.Count > 0;
        }
    }
}