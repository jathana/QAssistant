using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QDBTableSchema
   {
      private DataTable columns;

      public DataTable Columns
      {
         get
         {
            return columns;
         }

         set
         {
            columns = value;
         }
      }

      public bool Load(QDatabase database, string tableName)
      {
         bool retval = true;
         
         SqlCommand command = new SqlCommand();
         command.CommandText = "SELECT ORDINAL_POSITION, COLUMN_NAME FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE TABLE_NAME = @table_name ORDER BY TABLE_NAME, ORDINAL_POSITION";
         command.Parameters.Add(new SqlParameter("table_name", tableName));
         Columns = database.ExecuteCommand(command);
        
         return retval;
      }

      public bool ContainsColumn(string columnName)
      {
         bool retval = false;

         if(Columns!=null)
         {
            DataRow[] ret= Columns.Select(string.Format("COLUMN_NAME='{0}'",columnName));
            retval = (ret != null && ret.Length > 0);
         }
         return retval;
      }

      public bool ObjectExists()
      {
         return columns != null && columns.Rows.Count>0;
      }
   }
}
