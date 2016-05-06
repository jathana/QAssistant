using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QDataComparer2
   {

      

      public DataSet CompareQueryData(QDatabaseName sourceDBName,
                                      string sourceStatement,
                                      QDatabaseName destDBName,
                                      string destStatement,
                                      List<string> includeCols,
                                      string orderBy,
                                      out List<string> commonColumns)
      {
         DataSet retval = new DataSet();
         commonColumns = null;
         QDatabase sourceDB = QInstance.Environments.GetDatabase(sourceDBName);
         QDatabase destDB = QInstance.Environments.GetDatabase(destDBName);

         DataSet sourceDS = sourceDB.ExecuteQuery(sourceStatement);
         DataSet destDS = destDB.ExecuteQuery(destStatement);

         DataTable sourceTb = sourceDS.Tables[0];
         DataTable destTb = destDS.Tables[0];

         DataTable initSourceTb = sourceDS.Tables[0].Copy();
         DataTable initDestTb = destDS.Tables[0].Copy();

         initSourceTb.TableName = "SOURCE_INITIAL";
         initDestTb.TableName = "DEST_INITIAL";


         return retval;
      }

   }
}


//      public DataSet CompareQueryData(QDatabaseName sourceDBName, 
//                                      string sourceStatement, 
//                                      QDatabaseName destDBName, 
//                                      string destStatement,
//                                      List<string> includeCols,
//                                      string orderBy,
//                                      out List<string> commonColumns)
//      {
//         DataSet retval = new DataSet();

//         QDatabase sourceDB = QInstance.Environments.GetDatabase(sourceDBName);
//         QDatabase destDB = QInstance.Environments.GetDatabase(destDBName);
//         DataSet sourceDS = sourceDB.ExecuteQuery(sourceStatement);
//         DataSet destDS = destDB.ExecuteQuery(destStatement);

//         DataTable sourceTb = sourceDS.Tables[0];
//         DataTable destTb = destDS.Tables[0];

//         DataTable initSourceTb = sourceDS.Tables[0].Copy();
//         DataTable initDestTb = destDS.Tables[0].Copy();
//         initSourceTb.TableName = "SOURCE_INITIAL";
//         initDestTb.TableName = "DEST_INITIAL";

//         DataTable sourceUnmatched = null;
//         DataTable destUnmatched = null;
//         DataTable matched = null;
//         DataTable info = new DataTable("INFORMATION");
//         info.Columns.Add("SOURCE_ONLY_COLS", typeof(string));
//         info.Columns.Add("DEST_ONLY_COLS", typeof(string));
//         info.Columns.Add("COMMON_COLS", typeof(string));
//         info.Columns.Add("SOURCE_MATCHED", typeof(string));
//         info.Columns.Add("DEST_MATCHED", typeof(string));
//         info.Columns.Add("SOURCE_NOT_MATCHED", typeof(string));
//         info.Columns.Add("DEST_NOT_MATCHED", typeof(string));

//         commonColumns = (sourceTb.Columns.OfType<DataColumn>().Intersect(destTb.Columns.OfType<DataColumn>(), new DataColumnComparer())).ToArray().Select(C => C.ColumnName).ToList();
//         var sourceColsOnly = (sourceTb.Columns.OfType<DataColumn>().Except(destTb.Columns.OfType<DataColumn>(), new DataColumnComparer())).ToArray().Select(C => C.ColumnName).ToArray();
//         var destColsOnly = (destTb.Columns.OfType<DataColumn>().Except(sourceTb.Columns.OfType<DataColumn>(), new DataColumnComparer())).ToArray().Select(C => C.ColumnName).ToArray();

//         if (includeCols != null && includeCols.Count > 0)
//         {
//            IncludeColumns(sourceTb, includeCols);
//            IncludeColumns(destTb, includeCols);
//         }
//         else
//         {
//            foreach (string colName in sourceColsOnly) sourceTb.Columns.Remove(colName);
//            foreach (string colName in destColsOnly) destTb.Columns.Remove(colName);
//            includeCols = commonColumns.Select(i => i).ToList();
//         }

//         try { sourceUnmatched = sourceTb.AsEnumerable().Except(destTb.AsEnumerable(), DataRowComparer.Default).CopyToDataTable(); }
//         catch { sourceUnmatched = new DataTable(); }
//         finally { sourceUnmatched.TableName = "SOURCE_UNMATCHED"; }

//         try { destUnmatched = destTb.AsEnumerable().Except(sourceTb.AsEnumerable(), DataRowComparer.Default).CopyToDataTable(); }
//         catch { destUnmatched = new DataTable(); }
//         finally { destUnmatched.TableName = "DEST_UNMATCHED"; }

//         try { matched = sourceTb.AsEnumerable().Intersect(destTb.AsEnumerable(), DataRowComparer.Default).CopyToDataTable(); }
//         catch { matched = new DataTable(); }
//         finally { matched.TableName = "MATCHED"; }

//         DataRow row = info.NewRow();
//         row["SOURCE_ONLY_COLS"] = string.Join(",", sourceColsOnly);
//         row["DEST_ONLY_COLS"] = string.Join(",", destColsOnly);
//         row["COMMON_COLS"] = string.Join(",", commonColumns);
//         row["SOURCE_MATCHED"] = string.Format("Matched {0} of {1}.", matched.Rows.Count, sourceTb.Rows.Count);
//         row["DEST_MATCHED"] = string.Format("Matched {0} of {1}.", matched.Rows.Count, destTb.Rows.Count);
//         row["SOURCE_NOT_MATCHED"] = string.Format("Source not matched {0} of {1}.", sourceUnmatched.Rows.Count, sourceTb.Rows.Count);
//         row["DEST_NOT_MATCHED"] = string.Format("Dest not matched {0} of {1}.", destUnmatched.Rows.Count, destTb.Rows.Count);
//         info.Rows.Add(row);

//         DataTable sourceUnmatchedFull =  DeleteNotMatchedRows(sourceUnmatched, initSourceTb, includeCols);
//         DataTable destUnmatchedFull = DeleteNotMatchedRows(destUnmatched, initDestTb, includeCols);
//         DataTable sourceMatchedFull = DeleteNotMatchedRows(matched, initSourceTb, includeCols);
//         DataTable destMatchedFull = DeleteNotMatchedRows(matched, initDestTb, includeCols);
//         sourceUnmatchedFull.TableName = "SOURCE_UNMATCHED";
//         destUnmatchedFull.TableName = "DEST_UNMATCHED";
//         sourceMatchedFull.TableName = "SOURCE_MATCHED";
//         destMatchedFull.TableName = "DEST_MATCHED";

//         sourceUnmatchedFull.DefaultView.Sort=orderBy;
//         destUnmatchedFull.DefaultView.Sort=orderBy;
//         sourceMatchedFull.DefaultView.Sort=orderBy;
//         destMatchedFull.DefaultView.Sort=orderBy;

//         sourceUnmatchedFull = sourceUnmatchedFull.DefaultView.ToTable();
//         destUnmatchedFull = destUnmatchedFull.DefaultView.ToTable();
//         sourceMatchedFull = sourceMatchedFull.DefaultView.ToTable();
//         destMatchedFull = destMatchedFull.DefaultView.ToTable();
//         //retval.Tables.Add(sourceUnmatched);
//         //retval.Tables.Add(destUnmatched);
//         //retval.Tables.Add(matched);
//         retval.Tables.Add(sourceUnmatchedFull);
//         retval.Tables.Add(destUnmatchedFull);
//         retval.Tables.Add(sourceMatchedFull);
//         retval.Tables.Add(destMatchedFull);
//         retval.Tables.Add(info);

//         return retval;
//      }

//      /// <summary>
//      /// 
//      /// </summary>
//      /// <param name="src">NOT MATCHED</param>
//      /// <param name="dest">INITIAL TABLE</param>
//      private DataTable DeleteNotMatchedRows(DataTable keepRows, DataTable table, List<string> includeCols)
//      {
//         DataTable ret = new DataTable();
//         ret = table.Copy();
//         List<DataRow> toDelete = new List<DataRow>();

//         foreach(DataRow row in ret.Rows)
//         {
//            if(!RowExists(row,keepRows,includeCols))
//            {
//               row.Delete();
//               //toDelete.Add(row);
//            }
//         }
//         for (int i = toDelete.Count - 1; i >= 0; i--)
//         {
//            toDelete[i].Delete();
//         }
//         ret.AcceptChanges();
//         return ret;
//      }

//      private bool RowExists(DataRow row, DataTable keepRows, List<string> includeCols)
//      {
//         bool ret = false;
//         foreach (DataRow xrow in keepRows.Rows)
//         {
//            bool match = true;
//            foreach (string inclCol in includeCols)
//            {
//               match = xrow[inclCol].ToString() == row[inclCol].ToString() && match;
//            }
//            if (match)
//            {
//               ret = true;
//               break;   
//            }
//         }
//         if (keepRows.Rows.Count == 0)
//         {
//            ret = false;
//         }
//         return ret;
//      }

//      private void IncludeColumns(DataTable dataTable, List<string> columnNames)
//      {
//         if (dataTable != null && columnNames != null)
//         {
//            var allCols = dataTable.Columns.OfType<DataColumn>().ToArray().Select(C => C.ColumnName).ToList();

//            foreach (string col in allCols)
//            {
//               if(!columnNames.Contains(col))
//               {
//                  dataTable.Columns.Remove(col);
//               }
//            }
//         }
//      }


//   }
//}
