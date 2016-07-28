using DevExpress.XtraEditors;
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
   public class QCriterioCategoryTypeEditor:UITypeEditor
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

               try
               {
                  QDatabaseName dbName = (QDatabaseName)context.Instance.GetType().GetProperty("DatabaseName").GetValue(context.Instance, null);
                  string sql = "select LOV_CODE, LOV_DESC from vw_at_lst_of_val where lov_type='CRITERIA_CATEGORIES' order by lov_desc";
                  QDatabase db = QInstance.Environments.GetDatabase(dbName);
                  DataSet dbSet = db.ExecuteQuery(sql);
                  dbs.DisplayMember = "LOV_DESC";
                  dbs.DataSource = dbSet.Tables[0];
                  edSvc.DropDownControl(dbs);
                  value = ((DataRowView)dbs.SelectedItem).Row["LOV_DESC"];
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
         edSvc.CloseDropDown();
      }

   }
}
