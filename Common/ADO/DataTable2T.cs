using System.Data;
using System.Dynamic;
using System.Collections.Generic;

namespace Common.ADO
{
    public class DataTable2T
    {
        public static List<T> GetListFromDataTable<T>(DataTable dt) where T : class, new()
        {
            var objects = new List<dynamic>();

            foreach (DataRow row in dt.Rows)
            {
                dynamic obj = new ExpandoObject();

                foreach (DataColumn column in dt.Columns)
                {
                    var x = (IDictionary<string, object>)obj;
                    x.Add(column.ColumnName, row[column.ColumnName]);
                }
                objects.Add(obj);
            }

            var retval = new List<T>();
            foreach (dynamic item in objects)
            {
                var o = new T();
                Mapper<T>.Map(item, o);
                retval.Add(o);
            }

            return retval;
        }

        public static T GetTFromDataRow<T>(DataRow row) where T : class, new()
        {
            dynamic obj = new ExpandoObject();

            foreach (DataColumn column in row.Table.Columns)
            {
                var x = (IDictionary<string, object>)obj;
                x.Add(column.ColumnName, row[column.ColumnName]);
            }

            var retval = new List<T>();

            var o = new T();
            Mapper<T>.Map(obj, o);
            retval.Add(o);

            return o;
        }

        //...

    }
}
