using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace QAssistant.Lib.TypeEditors
{
   public class QDatabaseNameTypeEditor:UITypeEditor
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
               
               dbs.DisplayMember = "FullName";
               dbs.DataSource = QInstance.Environments.GetDatabaseNames(QEnvironmentType.All);
               edSvc.DropDownControl(dbs);
               value = dbs.SelectedItem;
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
