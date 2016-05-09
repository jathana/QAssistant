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
using DevExpress.XtraEditors.Controls;

namespace QAssistant
{
   public partial class frmDataCompare : DevExpress.XtraEditors.XtraForm
   {
      bool dirtyQueries = true;
      private DataSet resultDS = null;
      private List<string> commonCols = null;
      private List<string> selectedCols = new List<string>();


      public frmDataCompare()
      {
         InitializeComponent();
         PopulateDataBasesList();
      }

      private void PopulateDataBasesList()
      {
         // databases

         // cbo Target database
         cboSourceDB.Properties.DisplayMember = "FullName";
         cboSourceDB.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName"));
         cboSourceDB.Properties.DataSource = QInstance.Environments.GetDatabaseNames(QEnvironmentType.All);

         cboDestDB.Properties.DisplayMember = "FullName";
         cboDestDB.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName"));
         cboDestDB.Properties.DataSource = QInstance.Environments.GetDatabaseNames(QEnvironmentType.All);
      }

      private void SetMatchedCols()
      {
         if (dirtyQueries || lstIncludeCols.CheckedItems == null || lstIncludeCols.CheckedItems.Count == 0)
         {
            lstIncludeCols.DataSource = commonCols;
            for (int i = 0; i < lstIncludeCols.ItemCount; i++)
            {
               lstIncludeCols.SetItemCheckState(i, CheckState.Checked);
            }
         }
      }

      private void btnCompare_Click(object sender, EventArgs e)
      {
         QDataComparer comparer = new QDataComparer();

         try
         {
            List<string> checkedCols = commonCols == null ? null : lstIncludeCols.CheckedItems.Cast<string>().Select(c=>c).ToList();
            resultDS = comparer.CompareQueryData((QDatabaseName)cboSourceDB.EditValue, memSource.Text, 
                                                 (QDatabaseName)cboDestDB.EditValue, memDest.Text, 
                                                 checkedCols,  txtOrderBy.Text, out commonCols);
            SetMatchedCols();
            dirtyQueries = false;
            if (cboFilter.EditValue == null || string.IsNullOrEmpty(cboFilter.EditValue.ToString()))
            {
               cboFilter.EditValue = "Matched";
            }
            else
            {
               cboFilter_SelectedValueChanged(null, null);
            }
         }
         catch(Exception ex)
         {
            XtraMessageBox.Show(ex.Message);
         }
      }

      private void cboResultTable_EditValueChanged(object sender, EventArgs e)
      {
         
      }

      private void btnExcelExport_Click(object sender, EventArgs e)
      {
         grdDest.ExportToXls("compare.xls");
      }

      private void cboFilter_SelectedValueChanged(object sender, EventArgs e)
      {
         grdSource.BeginUpdate();
         try
         {
            viewSource.Columns.Clear();
            grdSource.DataSource = null;

            if (Convert.ToString(cboFilter.EditValue) == "Matched")
            {
               grdSource.DataSource = resultDS.Tables["SOURCE_MATCHED"];
            }
            else if (Convert.ToString(cboFilter.EditValue) == "Not Matched")
            {
               grdSource.DataSource = resultDS.Tables["SOURCE_UNMATCHED"];
            }
         }
         finally
         {
            grdSource.EndUpdate();
         }

         
         grdDest.BeginUpdate();
         try
         {
            viewDest.Columns.Clear();
            grdDest.DataSource = null;

            if (Convert.ToString(cboFilter.EditValue) == "Matched")
            {
               grdDest.DataSource = resultDS.Tables["DEST_MATCHED"];
            }
            else if (Convert.ToString(cboFilter.EditValue) == "Not Matched")
            {
               grdDest.DataSource = resultDS.Tables["DEST_UNMATCHED"];
            }
         }
         finally
         {
            grdDest.EndUpdate();
         }
         //info
         grdInformation.BeginUpdate();
         try
         {
            viewInfo.Columns.Clear();
            grdInformation.DataSource = null;
            grdInformation.DataSource = resultDS.Tables["INFORMATION"];
         }
         finally
         {
            grdInformation.EndUpdate();
         }

         viewSource.BestFitColumns();
         viewDest.BestFitColumns();
      }

      private void memSource_EditValueChanged(object sender, EventArgs e)
      {
         dirtyQueries = true;
      }

      private void memDest_EditValueChanged(object sender, EventArgs e)
      {
         dirtyQueries = true;
      }


      private void btnExportSource_Click(object sender, EventArgs e)
      {
         string fileName = string.Format("src_{0}.xls", DateTime.Now.ToString("yMMdd_HHmmssff"));
         grdSource.ExportToXls(fileName);
         System.Diagnostics.Process.Start(fileName);

         //SaveFileDialog d = new SaveFileDialog();
         //d.Filter ="Excel files (*.xls)|*.xls|All files (*.*)|*.*";
         //if (d.ShowDialog() == DialogResult.OK)
         //{
         //   grdSource.ExportToXls(d.FileName);
         //}
      }

      private void btnExportDest_Click(object sender, EventArgs e)
      {

         string fileName = string.Format("dst_{0}.xls", DateTime.Now.ToString("yMMdd_HHmmssff"));
         grdDest.ExportToXls(fileName);
         System.Diagnostics.Process.Start(fileName);

         //SaveFileDialog d = new SaveFileDialog();
         //d.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
         //if (d.ShowDialog() == DialogResult.OK)
         //{
         //   grdDest.ExportToXls(d.FileName);
         //}
      }

      private void btnClearCols_Click(object sender, EventArgs e)
      {
         for (int i = 0; i < lstIncludeCols.ItemCount; i++)
         {
            lstIncludeCols.SetItemCheckState(i, CheckState.Unchecked);
         }
      }
   }
}