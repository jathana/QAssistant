using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QTableFieldsHelper
   {

      public DataTable MergeTable(QDatabases databases, string tableName)
      {
         DataTable result = new DataTable();
         // add columns
         DataColumn col = new DataColumn();
         col.ColumnName = "ORDINAL_POSITION";
         col.DataType = typeof(string);
         col.Unique = true;
         result.Columns.Add(col);
         foreach (QDatabase db in databases)
         {
            result.Columns.Add(new DataColumn(string.Format("{0}.{1}", db.FullName.Name, tableName), typeof(string)));
         }
         // add data
         foreach (QDatabase db in databases)
         {
            QDBTableSchema schema = new QDBTableSchema();
            schema.Load(db, tableName);
            foreach (DataRow row in schema.Columns.Rows)
            {
               DataRow[] crow = result.Select("ORDINAL_POSITION='" + row["ORDINAL_POSITION"].ToString()+ "'");
               if (crow.Length == 1)
               {
                  crow[0][string.Format("{0}.{1}", db.FullName.Name, tableName)] = row["COLUMN_NAME"].ToString();
               }
               else if (crow.Length == 0)
               {
                  DataRow newRow = result.NewRow();
                  newRow["ORDINAL_POSITION"] = row["ORDINAL_POSITION"];
                  newRow[string.Format("{0}.{1}", db.FullName.Name, tableName)] = row["COLUMN_NAME"];
                  result.Rows.Add(newRow);
               }

            }
         }


         return result;
      }

     
   }
}
