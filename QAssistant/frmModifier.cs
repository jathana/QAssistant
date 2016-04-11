using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QAssistant.Lib;

namespace QAssistant
{
   public partial class frmModifier : DevExpress.XtraEditors.XtraForm
   {
      private object obj;

      public frmModifier()
      {
         InitializeComponent();
      }

      public DialogResult ShowDialog(object obj)
      {
         if (obj != null)
         {
            this.obj = obj;
            propertyGridControl1.SelectedObject = obj;
            DialogResult result = this.ShowDialog();
            return result;
         }
         else
         {
            throw new Exception("Only ICloneable objects are supported.");
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         ((IModifier)this.obj).Modify();
      }
   }
}