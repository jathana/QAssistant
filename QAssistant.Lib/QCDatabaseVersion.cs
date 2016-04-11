using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QCDatabaseVersion
   {
      public QCDatabaseVersion()
      {
      }

      public QCDatabaseVersion(int major, int minor, int patch)
      {
         Major = major;
         Minor = minor;
         Patch = patch;
      }

      public int Major { get; set; }
      public int Minor { get; set; }
      public int Patch { get; set; }


      public bool FromDB(QDatabase database)
      {
         bool retval = true;
         try
         {
            string Sql = "SELECT TOP 1 CLIENT_MAJOR,CLIENT_MINOR,CLIENT_PATCH FROM TLK_DATABASE_VERSIONS ORDER BY CLIENT_MAJOR DESC,CLIENT_MINOR DESC,CLIENT_PATCH DESC";
            DataSet ds = database.ExecuteQuery(Sql);
            if (ds != null && ds.Tables.Count == 1)
            {
               Major = Convert.ToInt32(ds.Tables[0].Rows[0]["CLIENT_MAJOR"]);
               Minor = Convert.ToInt32(ds.Tables[0].Rows[0]["CLIENT_MINOR"]);
               Patch = Convert.ToInt32(ds.Tables[0].Rows[0]["CLIENT_PATCH"]);
            }
         }
         catch(Exception ex)
         {
            retval = false;
         }
         return retval;
      }

      public override string ToString()
      {
         return string.Format("{0}.{1}.{2}", Major, Minor, Patch);
      }

   }
}
