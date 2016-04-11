using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QAssistant
{
   public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
   {
      public frmMain()
      {
         InitializeComponent();
      }

      void AddNewFieldsForm()
      {
         frmNewFields frm = new frmNewFields();
         frm.Text = string.Format("New Fields");
         frm.MdiParent = this;
         frm.Show();
      }

      private void btnNewFields_ItemClick(object sender, ItemClickEventArgs e)
      {
         AddNewFieldsForm();
      }

      private void btNewFields_ItemClick(object sender, ItemClickEventArgs e)
      {
         frmAddFields frm = new frmAddFields();
         frm.Text = string.Format("Add Fields");
         frm.MdiParent = this;
         frm.Show();
      }

      private void RibbonForm1_Load(object sender, EventArgs e)
      {
         QAssistant.Lib.QInstance.Init("configuration.xml");
      }

      private void RibbonForm1_FormClosing(object sender, FormClosingEventArgs e)
      {
         QAssistant.Lib.QInstance.Dispose();
      }

      private void btnCompare_ItemClick(object sender, ItemClickEventArgs e)
      {
         frmDataCompare frm = new frmDataCompare();
         frm.MdiParent = this;
         frm.Show();
      }

      private void btnOpenCREditor_ItemClick(object sender, ItemClickEventArgs e)
      {
         frmCREditor frm = new frmCREditor();
         frm.MdiParent = this;
         frm.Show();
      }
   }
}