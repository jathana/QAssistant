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
using QAssistant.Lib;

namespace QAssistant
{
   public partial class frmScriptCriteria : DevExpress.XtraEditors.XtraForm
   {

      public QDocumentCR docCR;
      private DataTable Criteria = new DataTable();
      public  List<QAddCriterioCR> SelectedCriteria = new List<QAddCriterioCR>();
      public string SelectedPath;




      public frmScriptCriteria()
      {
         InitializeComponent();
      }


      public DialogResult ShowDialog(QDocumentCR doc)
      {
         docCR = doc;
         InitTable();
         LoadCriteria(doc);
         txtPath.Text = QInstance.ProjectsPath;
         gridControl1.DataSource = Criteria;
         SelectedCriteria.Clear();
         DialogResult retval = ShowDialog();
         if(retval == DialogResult.OK)
         {
            foreach(DataRow row in Criteria.Rows)
            {
               if(Convert.ToBoolean(row["Checked"]))
               {
                  SelectedCriteria.Add((QAddCriterioCR)row["ObjCR"]);
               }
            }
            SelectedPath = txtPath.Text;
         }
         return retval;

      }

      private void InitTable()
      {
         Criteria.Columns.Add("Checked", typeof(bool));
         Criteria.Columns.Add("Name", typeof(string));
         Criteria.Columns.Add("CriUniqueId", typeof(string));
         Criteria.Columns.Add("CheckResultType", typeof(string));
         Criteria.Columns.Add("DatabaseName", typeof(string));
         Criteria.Columns.Add("ObjCR", typeof(QChangeRequest));
      }

      private void LoadCriteria(QChangeRequest cr)
      {
         if(cr != null)
         {
            if (cr.GetType() == typeof(QAddCriterioCR))
            {
               QAddCriterioCR criterio = (QAddCriterioCR)cr;
               DataRow row=Criteria.NewRow();
               row["Checked"] = criterio.CheckResultType == QCRCheckResultType.WellImplemented;
               row["Name"] = criterio.Name;
               row["CriUniqueId"] = criterio.CriUniqueId;
               row["CheckResultType"] = criterio.CheckResultType;
               row["DatabaseName"] = criterio.DatabaseName;
               row["ObjCR"] = criterio;
               Criteria.Rows.Add(row);
            }
            foreach (QChangeRequest child in cr.Children)
            {
               LoadCriteria(child);
            }
         }

      }

      private void btnBrowse_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog d = new FolderBrowserDialog();
         d.SelectedPath = QInstance.ProjectsPath;
         if(d.ShowDialog()==DialogResult.OK)
         {
            txtPath.Text = d.SelectedPath;

         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {

      }
   }
}