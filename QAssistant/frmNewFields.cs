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
using System.Configuration;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraTab;
using QAssistant.Lib;

namespace QAssistant
{
   public partial class frmNewFields : DevExpress.XtraEditors.XtraForm
   {

      private QDatabases devDBs = null;
      private List<GridControl> grids = new List<GridControl>();
      private Dictionary<string, List<string>> fields = new Dictionary<string, List<string>>();


      public frmNewFields()
      {
         InitializeComponent();
      }

      private void frmNewFields_Load(object sender, EventArgs e)
      {         
         
         PopulateTargetDataBaseCombo();
         
      }


      private void PopulateTargetDataBaseCombo()
      {
         // cbo Target database
         cboTargetDatabase.Properties.DisplayMember = "Name";
         cboTargetDatabase.Properties.ValueMember = "ConnectionString";
         cboTargetDatabase.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name"));
         cboTargetDatabase.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ConnectionString"));
         cboTargetDatabase.Properties.Columns["ConnectionString"].Visible = false;
         cboTargetDatabase.Properties.DataSource = QInstance.Environments.GetDatabases(QEnvironmentType.Dev);
      }

      private void grdFields_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Delete)
         {
            GridView view = (sender as GridControl).DefaultView as GridView;
            view.DeleteRow(view.FocusedRowHandle);
         }
      }

      private void AddGrids()
      {

         ParseFields();

         tabGrids.TabPages.Clear();
         grids.Clear();
         foreach(string str in fields.Keys)
         {
            XtraTabPage page = new XtraTabPage();
            page.Name = str;
            page.Text = string.Format("Table {0}",str);
            // grid

            GridControl grd = new GridControl();
            GridView v = (GridView)grd.CreateView("GridView");
            grd.MainView = v;
            //grd.Views.add
            (grd.MainView as GridView).RowCellStyle += FrmNewFields_RowCellStyle;
            grd.Name = str;
            QTableFieldsHelper helper = new QTableFieldsHelper();
            DataTable tb = helper.MergeTable(devDBs, str);

            grd.DataSource = tb;
            page.Controls.Add(grd);
            grd.Dock = DockStyle.Fill;
            tabGrids.TabPages.Add(page);
            grids.Add(grd);
         }
      }

      private void FrmNewFields_RowCellStyle(object sender, RowCellStyleEventArgs e)
      {
         
         GridView view = sender as GridView;
         string table = view.GridControl.Name;
         List<string> destFlds = fields[table];
         if (destFlds.Contains(e.CellValue))
         {
            e.Appearance.ForeColor= Color.Green;
            e.Appearance.BackColor = Color.LightGray;
         }
      }

      private void ParseFields()
      {
         fields.Clear();
         foreach (DataRow row in dataSet1.Tables["Fields"].Rows)
         {
            string fld = row["Name"].ToString();
            string[] fldarr=fld.Split('.');
            if (fldarr != null && fldarr.Length == 2)
            {
               if (!fields.ContainsKey(fldarr[0]))
               {
                  fields.Add(fldarr[0],new List<string>() { fldarr[1] });
               }
               else
               {
                  if(!fields[fldarr[0]].Contains(fldarr[1]))
                  {
                     fields[fldarr[0]].Add(fldarr[1]);
                  }
               }
            }
         }
      }


      private void btnValidate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         AddGrids();
      }

      private void frmNewFields_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (devDBs!= null)
         {
            devDBs.Dispose();
         }

      }
   }
}