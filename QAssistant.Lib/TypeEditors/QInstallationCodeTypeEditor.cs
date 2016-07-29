using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
   public class QInstallationCodeTypeEditor : UITypeEditor
   {
      IWindowsFormsEditorService edSvc = null;
      private String instCode = "";

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
               instCode = Convert.ToString(value);
               GridControl grd = new GridControl();
               GridView gview = new GridView(grd);
               GridColumn colCode = new GridColumn();
               GridColumn colDesc = new GridColumn();
               colCode.FieldName = "INST_CODE";
               colDesc.FieldName = "INST_DESC";
               colCode.Caption = "Code";
               colDesc.Caption = "Description";
               colCode.Width = 30;

               colCode.Visible = true;
               colDesc.Visible = true;
               gview.Columns.AddRange(new GridColumn[] { colDesc, colCode });

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
                  string sql = "SELECT INST_CODE, INST_DESC FROM AT_INSTALLATIONS ORDER BY INST_DESC";
                  QDatabase db = QInstance.Environments.GetDatabase(dbName);
                  DataSet dbSet = db.ExecuteQuery(sql);
                  //dbs.DisplayMember = "INST_DESC";
                  grd.DataSource = dbSet.Tables[0];
                  edSvc.DropDownControl(grd);
                  value = instCode;
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
            instCode = gview.GetRowCellValue(gview.FocusedRowHandle, "INST_CODE").ToString();
         }
         catch(Exception ex)
         {

         }
         edSvc.CloseDropDown();
         
      }

   }
}
