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
using QAssistant.Lib.ChangeRequests;
using DevExpress.XtraVerticalGrid.Rows;
using QAssistant.Lib;

namespace QAssistant
{

   public partial class frmObjectEditor : DevExpress.XtraEditors.XtraForm
   {
      private object obj;
      private object newObj;
      private Dictionary<string, string> errors = new Dictionary<string, string>();
      private bool forAdd = true;

      public object NewObj
      {
         get
         {
            return newObj;
         }

         set
         {
            newObj = value;
         }
      }

      public frmObjectEditor()
      {
         InitializeComponent();
      }

      public DialogResult ShowAddDialog(object newObject)
      {
         forAdd = true;
         this.newObj = newObject;
         propertyGridControl1.SelectedObject = this.newObj;
         DialogResult result = this.ShowDialog();
         return result;
      }

      public DialogResult ShowEditDialog(object obj)
      {
         forAdd = false;
         if (obj is ICloneable)
         {
            this.obj = obj;
            this.newObj = ((ICloneable)obj).Clone();
            propertyGridControl1.SelectedObject = NewObj;
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
         errors.Clear();

         if (NewObj is IValidatable)
         {
            ((IValidatable)newObj).Validate(out errors);

            propertyGridControl1.ClearRowErrors();
            foreach (string Key in errors.Keys)
            {
               propertyGridControl1.SetRowError(propertyGridControl1.GetRowByName("row" + Key).Properties,errors[Key]);
            }
         }
      }

      private void frmObjectEditor_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.None)
         {
            e.Cancel = errors != null && errors.Count > 0;
         }
      }

      private void propertyGridControl1_ValidateRecord(object sender, DevExpress.XtraVerticalGrid.Events.ValidateRecordEventArgs e)
      {
         e.Valid = false;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         errors.Clear();
      }

      private void propertyGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
      {
         btnOK_Click(null, null);
      }
   }
}