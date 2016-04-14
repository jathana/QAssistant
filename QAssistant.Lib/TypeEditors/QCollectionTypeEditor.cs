using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace QAssistant.Lib.TypeEditors
{
   public class QCollectionTypeEditor:UITypeEditor
   {
      IWindowsFormsEditorService edSvc = null;

      public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
      {
         return UITypeEditorEditStyle.Modal;
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
               frmAvailableSelectedCollectionEditor f = new frmAvailableSelectedCollectionEditor();
               QCollection q = (QCollection)value;               
               if (f.ShowDialog() == DialogResult.OK)
               {
                  value = f.Items;
               }
            }
         }
         
         return value;
      }

      //private void Dbs_Click(object sender, EventArgs e)
      //{
      //   edSvc.CloseDropDown();
      //}
   }
}
