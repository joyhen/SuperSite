using System.Collections.Generic;

namespace Common.ADO
{
    public class ExecuteNonQuery
    {
        public static int FromSqlStatement(string sql, params object[] sqlParams)
        {
            return DataLayer.ExecuteNonQueryFromSqlStatement(sql, sqlParams);
        }

        public static int FromStoredProcedure(string procedureName, Dictionary<string, object> procedureParams)
        {
            return DataLayer.ExecuteNonQueryFromStoredProcedure(procedureName, procedureParams);
        }

        public static int FromStoredProcedure(string procedureName)
        {
            return FromStoredProcedure(procedureName, null);
        }
    }
}