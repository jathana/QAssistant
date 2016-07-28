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
   public class QDBTablesViewsTypeEditor : UITypeEditor
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
                  string sql = @"SELECT NAME FROM sysobjects WHERE xtype = 'U' -- Tables
                                 UNION
                                 SELECT NAME FROM sysobjects WHERE xtype = 'V'-- Views
                                 ORDER BY NAME";
                  QDatabase db = QInstance.Environments.GetDatabase(dbName);
                  DataSet dbSet = db.ExecuteQuery(sql);
                  dbs.DisplayMember = "NAME";
                  dbs.DataSource = dbSet.Tables[0];
                  edSvc.DropDownControl(dbs);
                  value = ((DataRowView)dbs.SelectedItem).Row["NAME"];
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
