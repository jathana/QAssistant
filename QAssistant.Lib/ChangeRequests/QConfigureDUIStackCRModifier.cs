using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QConfigureDUIStackCRModifier : QCRModifier
   {

      #region fields
      private QCRFields fields = new QCRFields();
      private QDBObjectType dbObjectType = QDBObjectType.View;


      #endregion

      public QConfigureDUIStackCRModifier()
      {
      }

      #region properties
      public QCRFields Fields
      {
         get
         {
            return fields;
         }
      }

      public string RelatedDBObject
      {
         get
         {
            string retval = "";
            if (ChangeRequest != null)
            {
               retval = ((QConfigureDUIStackCR)ChangeRequest).RelatedDBObject;
            }
            return retval;
         }
      }

      public string DynamicUIName
      {
         get
         {
            string retval = "";
            if (ChangeRequest != null)
            {
               retval = ((QConfigureDUIStackCR)ChangeRequest).DynamicUIName;
            }
            return retval;
         }
      }

      public string DatasourceName
      {
         get
         {
            string retval = "";
            if (ChangeRequest != null)
            {
               retval = ((QConfigureDUIStackCR)ChangeRequest).DatasourceName;
            }
            return retval;
         }
      }

      public string TableName
      {
         get
         {
            string retval = "";
            if (ChangeRequest != null)
            {
               retval = ((QConfigureDUIStackCR)ChangeRequest).TableName;
            }
            return retval;
         }
      }

      public int InstallationCode
      {
         get
         {
            int retval = 0;
            if(ChangeRequest!=null)
            {
               retval = ((QConfigureDUIStackCR)ChangeRequest).InstallationCode;
            }
            return retval;
         }
      }

      public QDatabaseName DatabaseName
      {
         get
         {
            QDatabaseName retval = new QDatabaseName();
            if (ChangeRequest != null)
            {
               retval = ((QConfigureDUIStackCR)ChangeRequest).DatabaseName;
            }
            return retval;
         }
      }

      #endregion
      #region methods

      public override void Modify()
      {
         // Table
         var tbChildren = ChangeRequest.Children.Where(c => c.GetType() == typeof(QAlterTableCR) && 
                                                            ((QAlterTableCR)c).TableName == TableName &&
                                                            ((QAlterTableCR)c).DatabaseName == DatabaseName).ToList();
         
         if (tbChildren != null && tbChildren.Count > 0)
         {
            foreach (QAlterTableCR alterTableCR in tbChildren)
            {
               QAlterTableCRModifier alterTableCRModifier = new QAlterTableCRModifier();
               alterTableCRModifier.ChangeRequest = alterTableCR;
               alterTableCRModifier.Fields = fields;
               alterTableCRModifier.Modify();
            }
         }
         else
         {
            QAlterTableCR alterTableCR = ChangeRequest.AddNewChild<QAlterTableCR>();
            alterTableCR.TableName = TableName;
            alterTableCR.DatabaseName = DatabaseName;
            QAlterTableCRModifier alterTableCRModifier = new QAlterTableCRModifier();
            alterTableCRModifier.ChangeRequest = alterTableCR;
            alterTableCRModifier.Fields = fields;
            alterTableCRModifier.Modify();

         }

         // View / Stored procedure(todo)
         if (dbObjectType == QDBObjectType.View)
         {
            var viewChildren = ChangeRequest.Children.Where(c => c.GetType() == typeof(QAlterViewCR) &&
                                                           ((QAlterViewCR)c).ViewName == TableName &&
                                                           ((QAlterViewCR)c).DatabaseName == DatabaseName).ToList();
            if (viewChildren != null && viewChildren.Count > 0)
            {
               foreach (QAlterViewCR alterViewCR in viewChildren)
               {
                  QAlterViewCRModifier alterViewCRModifier = new QAlterViewCRModifier();
                  alterViewCRModifier.ChangeRequest = alterViewCR;
                  alterViewCRModifier.Fields = fields;
                  alterViewCRModifier.Modify();
               }
            }
            else
            {
               QAlterViewCR alterViewCR = ChangeRequest.AddNewChild<QAlterViewCR>();
               alterViewCR.ViewName = RelatedDBObject;
               alterViewCR.DatabaseName = DatabaseName;

               QAlterViewCRModifier alterViewCRModifier = new QAlterViewCRModifier();
               alterViewCRModifier.ChangeRequest = alterViewCR;
               alterViewCRModifier.Fields = fields;
               alterViewCRModifier.Modify();
            }
         }

         // Datasource         
         var dsChildren = ChangeRequest.Children.Where(c => c.GetType() == typeof(QConfigureDatasourceCR) &&
                                                           ((QConfigureDatasourceCR)c).Name == DatasourceName &&
                                                           ((QConfigureDatasourceCR)c).DatabaseName == DatabaseName &&
                                                           ((QConfigureDatasourceCR)c).InstallationCode == InstallationCode).ToList();
         if (dsChildren != null && dsChildren.Count > 0)
         {
            foreach (QConfigureDatasourceCR configureDatasourceCR in dsChildren)
            {
               QConfigureDatasourceCRModifier configureDatasourceCRModifier = new QConfigureDatasourceCRModifier();
               configureDatasourceCRModifier.ChangeRequest = configureDatasourceCR;
               configureDatasourceCRModifier.Fields = fields;
               configureDatasourceCRModifier.Modify();
            }
         }
         else
         {
            QConfigureDatasourceCR configureDatasourceCR = ChangeRequest.AddNewChild<QConfigureDatasourceCR>();
            configureDatasourceCR.Name = DatasourceName;
            configureDatasourceCR.DatabaseName = DatabaseName;
            configureDatasourceCR.InstallationCode = InstallationCode;
            configureDatasourceCR.RelatedDBObject = RelatedDBObject;
            QConfigureDatasourceCRModifier configureDatasourceCRModifier = new QConfigureDatasourceCRModifier();
            configureDatasourceCRModifier.ChangeRequest = configureDatasourceCR;
            configureDatasourceCRModifier.Fields = fields;
            configureDatasourceCRModifier.Modify();
         }

         // DUI    
         var duiChildren = ChangeRequest.Children.Where(c => c.GetType() == typeof(QConfigureDUICR) &&
                                                          ((QConfigureDUICR)c).Name == DatasourceName &&
                                                          ((QConfigureDUICR)c).DatabaseName == DatabaseName &&
                                                          ((QConfigureDUICR)c).InstallationCode == InstallationCode).ToList();
         if (duiChildren != null && duiChildren.Count > 0)
         {
            foreach (QConfigureDUICR configureDatasourceCR in duiChildren)
            {
               QConfigureDUICRModifier configureDatasourceCRModifier = new QConfigureDUICRModifier();
               configureDatasourceCRModifier.ChangeRequest = configureDatasourceCR;
               configureDatasourceCRModifier.Fields = fields;
               configureDatasourceCRModifier.Modify();
            }
         }
         else
         {
            QConfigureDUICR configureDUICR = ChangeRequest.AddNewChild<QConfigureDUICR>();
            configureDUICR.Name = DynamicUIName;
            configureDUICR.DatabaseName = DatabaseName;
            configureDUICR.InstallationCode = InstallationCode;
            configureDUICR.RelatedDBObject = RelatedDBObject;
            QConfigureDUICRModifier configureDUICRModifier = new QConfigureDUICRModifier();
            configureDUICRModifier.ChangeRequest = configureDUICR;
            configureDUICRModifier.Fields = fields;
            configureDUICRModifier.Modify();
         }

      }
      #endregion

   }
}
