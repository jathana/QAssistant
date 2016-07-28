using DevExpress.XtraEditors;
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
   public class QDBTableViewFieldsTypeEditor : UITypeEditor
   {
      IWindowsFormsEditorService edSvc = null;

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
               ListBoxControl dbs = new ListBoxControl();
               dbs.Click += Dbs_Click;
               object inst = context.Instance;
               if (inst.GetType() == typeof(QAddCriterioCR))
               {
                  value = InitDropDown_Criterio(context, dbs);
               }
            }
         }

         return value;
      }

      private void Dbs_Click(object sender, EventArgs e)
      {
         edSvc.CloseDropDown();
      }

      private object InitDropDown_Criterio(ITypeDescriptorContext context, ListBoxControl dbs)
      {
         object retval = null;
         try
         {
            QDatabaseName dbName = (QDatabaseName)context.Instance.GetType().GetProperty("DatabaseName").GetValue(context.Instance, null);
            string tableName = (string)context.Instance.GetType().GetProperty("WhereTable").GetValue(context.Instance, null);
            string sql = string.Format(@"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{0}' ORDER BY COLUMN_NAME", tableName);
            QDatabase db = QInstance.Environments.GetDatabase(dbName);
            DataSet dbSet = db.ExecuteQuery(sql);
            dbs.DisplayMember = "COLUMN_NAME";
            dbs.DataSource = dbSet.Tables[0];
            edSvc.DropDownControl(dbs);
            retval = ((DataRowView)dbs.SelectedItem).Row["COLUMN_NAME"];
         }
         catch (Exception ex)
         {

         }
         return retval;
      }

   }
}
