using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using QAssistant.Lib.ChangeRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace QAssistant.Lib.TypeEditors
{
   public class QCrjCodeTypeEditor : UITypeEditor
   {
      IWindowsFormsEditorService edSvc = null;
      private String crjCode = "";

      public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
      {
         return UITypeEditorEditStyle.DropDown;
      }

      public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
      {

         if (context != null
                && context.Instance != null
                && provider != null)
         {

            edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (edSvc != null)
            {
               crjCode = Convert.ToString(value);
               GridControl grd = new GridControl();
               GridView gview = new GridView(grd);
               GridColumn colCode = new GridColumn();
               GridColumn colSourceTable = new GridColumn();
               GridColumn colJoin = new GridColumn();

               colCode.FieldName = "CRJ_CODE";
               colSourceTable.FieldName = "CRJ_SOURCE_TABLE";
               colJoin.FieldName = "CRJ_JOIN";
               colCode.Caption = "Code";
               colSourceTable.Caption = "Source Table";
               colJoin.Caption = "Join";
               colCode.Width = 30;

               colCode.Visible = true;
               colSourceTable.Visible = true;
               colJoin.Visible = true;
               gview.Columns.AddRange(new GridColumn[] { colCode, colSourceTable, colJoin });

               //gview.OptionsBehavior.ReadOnly = true;
               grd.MainView = gview;
               grd.Click += Dbs_Click;
               gview.OptionsCustomization.AllowGroup = false;
               gview.OptionsView.ShowGroupPanel = false;
               //gview.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
               gview.OptionsBehavior.Editable = false;
               //ListBoxControl dbs = new ListBoxControl();               
               //dbs.Click += Dbs_Click;

               try
               {
                  QDatabaseName dbName = (QDatabaseName)context.Instance.GetType().GetProperty("DatabaseName").GetValue(context.Instance, null);
                  string sql = "SELECT CRJ_CODE, CRJ_SOURCE_TABLE, CRJ_JOIN FROM AT_CRITERIA_JOINS ORDER BY CRJ_SOURCE_TABLE";
                  object inst = context.Instance;
                  if (inst.GetType() == typeof(QAddCriterioCR))
                  {
                     string tableName = (string)context.Instance.GetType().GetProperty("WhereTable").GetValue(context.Instance, null);
                     sql = string.Format("SELECT CRJ_CODE, CRJ_SOURCE_TABLE, CRJ_JOIN FROM AT_CRITERIA_JOINS WHERE CRJ_SOURCE_TABLE='{0}' ORDER BY CRJ_SOURCE_TABLE", tableName);
                  }
                  QDatabase db = QInstance.Environments.GetDatabase(dbName);
                  DataSet dbSet = db.ExecuteQuery(sql);
                  //dbs.DisplayMember = "INST_DESC";
                  grd.DataSource = dbSet.Tables[0];
                  edSvc.DropDownControl(grd);
                  value = crjCode;
               }
               catch (Exception ex)
               {

               }
            }
         }

         return value;
      }

      private void Dbs_Click(object sender, EventArgs e)
      {
         try
         {
            GridControl grd = (DevExpress.XtraGrid.GridControl)sender;
            GridView gview = (GridView)grd.MainView;
            crjCode = gview.GetRowCellValue(gview.FocusedRowHandle, "CRJ_CODE").ToString();
         }
         catch(Exception ex)
         {

         }
         edSvc.CloseDropDown();
         
      }

   }
}
