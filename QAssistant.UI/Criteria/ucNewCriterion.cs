using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QAssistant.Lib;

namespace QAssistant.UI.Criteria
{
   public partial class ucNewCriterion : DevExpress.XtraEditors.XtraUserControl
   {
      private QDatabase database = new QDatabase();

      public ucNewCriterion()
      {
         InitializeComponent();
         this.Disposed += UcNewCriterion_Disposed;
      }

      private void UcNewCriterion_Disposed(object sender, EventArgs e)
      {
         (database as IDisposable).Dispose();
         
      }

      private void ucConnectionString1_ConnectionStringCreated(object sender, EventArgs e)
      {
         database.ConnectionString = ucConnectionString1.ConnectionString;
         QCDatabaseVersion Version = new QCDatabaseVersion();
         Version.FromDB(database);
         txtDatabaseVersion.Text = Version.ToString();

      }

     


   }
}
