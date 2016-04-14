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

namespace QAssistant.Lib
{
   public partial class frmAvailableSelectedCollectionEditor : DevExpress.XtraEditors.XtraForm
   {
      #region fields
      private QCollection items;
      #endregion

      #region properties
      public QCollection Items
      {
         get
         {
            return items;
         }

         set
         {
            items = value;
         }
      }
      #endregion

      public frmAvailableSelectedCollectionEditor()
      {
         InitializeComponent();
      }

      public new DialogResult ShowDialog()
      {
         lstAvailable.DataSource = items.AvailableItems;
         lstSelected.DataSource = items;
         DialogResult retval = ShowDialog();

         return retval;
      }

      private void btnSelectAll_Click(object sender, EventArgs e)
      {
         items.Clear();
         foreach(object obj in items.AvailableItems)
         {
            items.Add(obj);
         }
      }

      private void btnSelect_Click(object sender, EventArgs e)
      {

      }

      private void btnDeselect_Click(object sender, EventArgs e)
      {

      }

      private void btnDeselectAll_Click(object sender, EventArgs e)
      {

      }
   }
}