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

namespace QAssistant
{
   

   public partial class frmCollectionEditor : DevExpress.XtraEditors.XtraForm
   {
      private object obj;
      private object newObj;
      private QValidateHandler handler;
      private List<string> errors=new List<string>();
      private bool forAdd = true;

      //public object Obj
      //{
      //   get
      //   {
      //      return obj;
      //   }

      //   set
      //   {
      //      obj = value;
      //   }
      //}

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

      public frmCollectionEditor()
      {
         InitializeComponent();
      }

      public DialogResult ShowAddDialog(object newObject, QValidateHandler handler)
      {
         forAdd = true;
         this.handler = handler;
         this.newObj = newObject;         
         propertyGridControl1.SelectedObject = this.newObj;
         DialogResult result = this.ShowDialog();
         return result;
      }

      public DialogResult ShowEditDialog(object obj, QValidateHandler handler)
      {
         forAdd = false;
         if (obj is ICloneable)
         {
            this.handler = handler;
            this.obj = obj;
            this.newObj = ((ICloneable)obj).Clone();
            propertyGridControl1.SelectedObject = NewObj;
            DialogResult result = this.ShowDialog();
            return result;
         }
         else
         {
            throw new Exception ("Only ICloneable objects are supported.");
         }
      }


      private void btnOK_Click(object sender, EventArgs e)
      {
         errors.Clear();
         
         if (handler != null)
         {
            handler(NewObj, out errors);
            listBoxControl1.DataSource = errors;
         }

         //BaseRow r = propertyGridControl1.GetRowByName("rowCRName");
         
         //propertyGridControl1.ClearRowErrors();
         //if (string.IsNullOrEmpty(Convert.ToString(r.Properties.Value)))
         //{
         //   propertyGridControl1.SetRowError(propertyGridControl1.GetRowByName("rowCRName").Properties, "invalid name");
         //}
         //errors.Add("RR");

      }

      private void propertyGridControl1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
      {
         //if(propertyGridControl1.FocusedRow.Name=="rowCRName" && string.IsNullOrEmpty(Convert.ToString(e.Value)))
         //{
         //   e.Valid = false;
         //   e.ErrorText = "CRName is required.";
         //}
      }

      private void frmObjectEditor_FormClosing(object sender, FormClosingEventArgs e)
      {
         e.Cancel = errors != null && errors.Count > 0;
      }

      private void propertyGridControl1_ValidateRecord(object sender, DevExpress.XtraVerticalGrid.Events.ValidateRecordEventArgs e)
      {
         e.Valid = false;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         errors.Clear();
      }
   }
}