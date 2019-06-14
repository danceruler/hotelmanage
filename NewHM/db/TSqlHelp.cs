using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.db
{
    public class TSqlHelp<T>
    {
        private static DatabaseContext db = new DatabaseContext();

        public static List<T> SelectByModel(string[] keys,string proname)
        {
            string sql = SelectByArray(keys, typeof(T).Name, proname);
            return db.Database.SqlQuery<T>(sql).ToList();
        }

        public static string SelectByArray(string[] keys, string tablename, string proname)
        {
            string sql = "select * from " + tablename + " where ";
            for (int i = 0; i < keys.Length; i++)
            {
                if (i > 0)
                {
                    sql += " or ";
                }
                sql += proname + " = " + keys[i] + " ";
            }
            return sql;
        }
        
    }
}
