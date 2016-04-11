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
using System.Data.SqlClient;
using System.Data.Sql;

namespace QAssistant.UI.SQLServerConnection
{
   public partial class SqlServerConnectionDialog : DevExpress.XtraEditors.XtraForm
   {
      private SqlConnectionStringBuilder conn=new SqlConnectionStringBuilder();
      public string RootPath = "";

      public SqlServerConnectionDialog()
      {
         InitializeComponent();
      }

      #region properties
      public string ConnectionString
      {
         get
         {
            return conn.ConnectionString;
         }
         set
         {
            conn.ConnectionString = value;
         }
      }
      #endregion

      #region private methods
      private void ConstructConnection()
      {
         conn.DataSource = cbServer.Text;
         conn.IntegratedSecurity = true;
         conn.UserID = "";
         conn.Password = "";
         conn.InitialCatalog = "";

         if (rbAuthenticationSql.Checked)
         {
            conn.IntegratedSecurity = false;
            conn.UserID = txtUser.Text;
            conn.Password = txtPassword.Text;
         }
         if (cbDatabase.Text != "")
         {
            conn.InitialCatalog = cbDatabase.Text;
         }
      }

      private void SqlInstances()
      {
         Cursor.Current = Cursors.WaitCursor;
         try
         {
            cbServer.Properties.Items.Clear();
            DataTable sqlSources = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow datarow in sqlSources.Rows)
            {
               string datasource = datarow["ServerName"].ToString();
               if (datarow["InstanceName"] != DBNull.Value)
               {
                  datasource += String.Format("\\{0}", datarow["InstanceName"]);
               }
               cbServer.Properties.Items.Add(datasource);
            }
         }
         catch (Exception ex)
         {
            XtraMessageBox.Show(ex.Message);
         }
         Cursor.Current = Cursors.Default;
      }



      private void SqlDatabaseNames()
      {
         ConstructConnection();
         Cursor.Current = Cursors.WaitCursor;
         string connString = conn.ConnectionString;
         List<string> databaseNames = new List<string>();

         cbDatabase.Properties.Items.Clear();
         try
         {
            using (SqlConnection cn = new SqlConnection(connString))
            {
               cn.Open();
               using (SqlCommand cmd = new SqlCommand())
               {

                  cmd.Connection = cn;
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandText = "sp_databases";
                  using (SqlDataReader myReader = cmd.ExecuteReader())
                  {
                     while (myReader.Read())
                     {
                        cbDatabase.Properties.Items.Add(myReader.GetString(0));
                     }
                  }
               }
            }
         }
         catch (Exception ex)
         {
            XtraMessageBox.Show(ex.Message);
         }
         Cursor.Current = Cursors.Default;
      }

      private void TestDB()
      {
         ConstructConnection();
         try
         {
            SqlConnection objConn = new SqlConnection(conn.ConnectionString);
            objConn.Open();
            objConn.Close();
            XtraMessageBox.Show("Successful connection!!!");
         }
         catch (Exception ex)
         {
            XtraMessageBox.Show(ex.Message);
         }

      }
      #endregion
      #region handlers
      private void SqlServerConnectionDialog_Load(object sender, EventArgs e)
      {
         cbServer.Text = conn.DataSource;
         cbDatabase.Text = conn.InitialCatalog;

         txtUser.Enabled = !conn.IntegratedSecurity;
         txtPassword.Enabled = !conn.IntegratedSecurity;
         rbAuthenticationWin.Checked = conn.IntegratedSecurity;
         rbAuthenticationSql.Checked = !conn.IntegratedSecurity;
         txtUser.Text = (conn.IntegratedSecurity ? "" : conn.UserID);
         txtPassword.Text = (conn.IntegratedSecurity ? "" : conn.Password);
      }


      private void btnRefresh_Click(object sender, EventArgs e)
      {
         SqlInstances();
      }

      private void cbServer_QueryPopUp(object sender, CancelEventArgs e)
      {
         if (cbServer.Properties.Items.Count == 0)
            SqlInstances();
      }


      private void cbDatabase_QueryPopUp(object sender, CancelEventArgs e)
      {
         SqlDatabaseNames();
      }
      private void rbAuthenticationWin_CheckedChanged(object sender, EventArgs e)
      {
         txtUser.Enabled = false;
         txtPassword.Enabled = false;

      }

      private void rbAuthenticationSql_CheckedChanged(object sender, EventArgs e)
      {
         txtUser.Enabled = true;
         txtPassword.Enabled = true;

      }

      private void btnTest_Click(object sender, EventArgs e)
      {
         TestDB();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         ConstructConnection();
         this.Close();
         this.DialogResult = System.Windows.Forms.DialogResult.OK;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      }



      #endregion

      private void cbServer_SelectedIndexChanged(object sender, EventArgs e)
      {
         cbDatabase.Text = "";
      }
   }
}