using System;
using System.Configuration;
using System.Windows.Forms;

namespace QAssistant.UI.SQLServerConnection
{
   public partial class ucConnectionString : DevExpress.XtraEditors.XtraUserControl
   {
      private string connectionString = "";

      public event EventHandler ConnectionStringCreated;

      public ucConnectionString()
      {
         InitializeComponent();
      }

      public string ConnectionString
      {
         get
         {
            return connectionString;
         }

         set
         {
            connectionString = value;
         }
      }

      protected virtual void OnConnectionStringCreated()
      {
         // Raise the event by using the () operator.
         if (ConnectionStringCreated != null)
            ConnectionStringCreated(this, new EventArgs());
      }


      private void btNewConnection_Click(object sender, EventArgs e)
      {
         Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

         SqlServerConnectionDialog dialog = new SqlServerConnectionDialog();
         if (config.ConnectionStrings.ConnectionStrings["conn"] != null)
         {
            dialog.ConnectionString = config.ConnectionStrings.ConnectionStrings["conn"].ConnectionString;
         }
         if (dialog.ShowDialog()==DialogResult.OK)
         {
            if (config.ConnectionStrings.ConnectionStrings["conn"] != null)
            {
               config.ConnectionStrings.ConnectionStrings["conn"].ConnectionString = dialog.ConnectionString;
               config.Save(ConfigurationSaveMode.Modified);
               ConfigurationManager.RefreshSection("connectionStrings");
            }

            connectionString = dialog.ConnectionString;
            memoEdit1.Text = dialog.ConnectionString;
            OnConnectionStringCreated();
         }
      }


   }
}
