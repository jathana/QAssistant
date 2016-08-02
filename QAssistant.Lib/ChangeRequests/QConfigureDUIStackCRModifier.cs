using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QConfigureDUIStackCRModifier : QCRModifier
   {

      #region fields
      private List<QPoolField> poolFields = new List<QPoolField>();
      private QDBObjectType dbObjectType = QDBObjectType.View;


      #endregion

      public QConfigureDUIStackCRModifier()
      {
      }

      #region properties
      [Editor(typeof(QPoolFieldsManyTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
      public List<QPoolField> PoolFields
      {
         get
         {
            return poolFields;
         }
         set
         {
            poolFields = value;
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

      private void ModifyTables()
      {
         // foreach field
         // 1. check if table exists. If not create change table. Add add column cr.
         foreach (QPoolField poolField in poolFields)
         {
            // normally there is only one alter table cr, but check all.
            List<QAlterTableCR> alterTablesCR = ChangeRequest.GetDescendants<QAlterTableCR>().Where(CR => CR.TableName == poolField.TableName && CR.DatabaseName == DatabaseName).ToList();
            if (alterTablesCR != null && alterTablesCR.Count > 0)
            {
               // check if QAddColumnToTableCR item exists in alterTableCR.
               foreach (QAlterTableCR alterTableCR in alterTablesCR)
               {
                  List<QAddColumnToTableCR> columns = alterTableCR.GetDescendants<QAddColumnToTableCR>().Where(CR => CR.ColumnName == poolField.FieldName).ToList();
                  if (columns == null || columns.Count == 0)
                  {
                     // add field to table.
                     alterTableCR.AddColumnToTableCR(poolField.FieldName);
                  }
               }
            }
            else
            {
               // create alter table cr, add field and add it to change request.
               QAlterTableCR alterTableCR = ChangeRequest.AddNewChild<QAlterTableCR>();
               alterTableCR.TableName = poolField.TableName;
               alterTableCR.DatabaseName = DatabaseName;
               alterTableCR.AddColumnToTableCR(poolField.FieldName);
            }
         }

      }

      public override void Modify()
      {
         // Table
         ModifyTables();

         // View / Stored procedure(todo)
         if (dbObjectType == QDBObjectType.View)
         {
            var viewChildren = ChangeRequest.Children.Where(c => c.GetType() == typeof(QAlterViewCR) &&
                                                           ((QAlterViewCR)c).ViewName == RelatedDBObject &&
                                                           ((QAlterViewCR)c).DatabaseName == DatabaseName).ToList();
            if (viewChildren != null && viewChildren.Count > 0)
            {
               foreach (QAlterViewCR alterViewCR in viewChildren)
               {
                  QAlterViewCRModifier alterViewCRModifier = new QAlterViewCRModifier();
                  alterViewCRModifier.ChangeRequest = alterViewCR;
                  alterViewCRModifier.PoolFields = poolFields;
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
               alterViewCRModifier.PoolFields = poolFields;
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
               configureDatasourceCRModifier.PoolFields = poolFields;
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
            configureDatasourceCRModifier.PoolFields = poolFields;
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
               configureDatasourceCRModifier.PoolFields = poolFields;
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
            configureDUICRModifier.PoolFields = poolFields;
            configureDUICRModifier.Modify();
         }

      }
      #endregion

   }
}
