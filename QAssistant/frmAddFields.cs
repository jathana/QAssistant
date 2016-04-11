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
using QAssistant.Lib.ChangeRequests;
using System.Xml;

namespace QAssistant
{
   public partial class frmAddFields : DevExpress.XtraEditors.XtraForm
   {

      public frmAddFields()
      {
         InitializeComponent();
         
      }

      private void frmAddFields_Load(object sender, EventArgs e)
      {
         PopulateDataBasesList();
      }

      private void PopulateDataBasesList()
      {
         // Target databases
         lstDatabases.DisplayMember = "FullName";
         lstDatabases.DataSource = QInstance.Environments.GetDatabaseNames(QEnvironmentType.Dev);
      }

      private void simpleButton1_Click(object sender, EventArgs e)
      {
         List<string> flds = new List<string>()
            {
               "CAEX_CUSTOM_TEXT_03",
               "CAEX_CUSTOM_TEXT_01",
               "CAEX_CUSTOM_DATETIME_18",
               "CAEX_CUSTOM_TEXT_04",
               "CAEX_CUSTOM_DECIMAL_03",
               "CAEX_CUSTOM_DECIMAL_03_LCY"
            };

         List<string> arflds = new List<string>()
            {
               "MVEX_CAEX_CUSTOM_TEXT_03",
               "MVEX_CAEX_CUSTOM_TEXT_01",
               "MVEX_CAEX_CUSTOM_DATETIME_18",
               "MVEX_CAEX_CUSTOM_TEXT_04",
               "MVEX_CAEX_CUSTOM_DECIMAL_03",
               "MVEX_CAEX_CUSTOM_DECIMAL_03_LCY"
            };


         List<string> views = new List<string>()
         {
            "vw_at_cases_for_admin",
            "vw_at_cases",
            "vw_at_cases_collection_base_fields",
            "vw_at_strategy_cases",
            "vw_at_worklists_cases",
            "vw_at_cases_small",
            "vw_at_packet_cases",
            "vw_at_all_packet_cases",
            "vw_at_exceptions_coll_comp",
            "vw_at_cases_out_per_pack",
            "vw_at_revoc_manual_cases",
            "vw_at_packet_recall_cases_with_streams",
            "vw_at_cases_with_all_recalls",
            "vw_at_request_cases",
            "vw_at_cases_extra_customers_for_search",
            "vw_at_cases_open_available_for_requests",
            "vw_at_settlements_ext_cases",
            "VW_AT_CASE_QUEUE_HISTORY_DETAILS"
         };

         List<string> arviews = new List<string>()
         {
            "vw_at_cases_for_archive"
         };

         List<string> tables = new List<string>()
         {
            "at_case_extra"
         };



         QGroupCR gcr2 = new QGroupCR()
         {
            Name = "Add fields to views"
         };

         //XmlDocument doc = new XmlDocument();
         //doc.Load("cr.xml");
         //gcr2.Deserialize(doc.DocumentElement);

         QGroupCR rootCR = new QGroupCR()
         {
            Name = "PEM 11014"
         };
         //rootCR.Deserialize(doc.DocumentElement);

         #region init
         foreach (var dbName in lstDatabases.CheckedItems)
         {
            QDatabase dbObj = QInstance.Environments.GetDatabase((QDatabaseName)dbName);

            QGroupCR gcr = new QGroupCR()
            {
               Name = "Add fields to views",
               Parent = rootCR

            };

            rootCR.Children.Add(gcr);


            foreach (string v in views)
            {
               QAlterViewCR vobj = new QAlterViewCR()
               {
                  ViewName = v,
                  DatabaseName = dbObj.FullName
               };
               vobj.AddColumnsCR(flds);
               gcr.Children.Add(vobj);
            }

            foreach (string arv in arviews)
            {
               QAlterViewCR vobj = new QAlterViewCR()
               {
                  ViewName = arv,
                  DatabaseName = dbObj.FullName
               };
               vobj.AddColumnsCR(arflds);
               gcr.Children.Add(vobj);

            }


         }

         #endregion
         ////


         string s = rootCR.Serialize();

         using (XmlWriter x = new XmlTextWriter("cr.xml", Encoding.Default))
         {
            x.WriteRaw(s);
            x.Flush();
            x.Close();
         }

         bool r = rootCR.Check();
         gridControl1.DataSource = rootCR.Actions;
      }

      private void frmAddFields_FormClosing(object sender, FormClosingEventArgs e)
      {
         
      }

      private void btnUICR_Click(object sender, EventArgs e)
      {
      }
   }
}