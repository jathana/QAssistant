using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QConfigureDatasourceCRModifier : QCRModifier
   {

      #region fields
      private int installationCode = 0;
      private QCRFields fields = new QCRFields();

      #endregion

      public QConfigureDatasourceCRModifier()
      {
      }

      #region properties
      public QCRFields Fields
      {
         get
         {
            return fields;
         }
         set
         {
            fields = value;
         }
      }

      public int InstallationCode
      {
         get
         {
            int retval = 0;
            if(ChangeRequest!=null)
            {
               retval = ((QConfigureDatasourceCR)ChangeRequest).InstallationCode;
            }
            return retval;
         }
      }
      #endregion
      #region methods

      public override void Modify()
      {
         foreach(QCRField field in fields)
         {
            var children = ChangeRequest.Children.Where(C => C.GetType() == typeof(QAddDatasourceFieldCR) && 
                                                            ((QAddDatasourceFieldCR)C).FieldName == field.FieldName &&
                                                            ((QAddDatasourceFieldCR)C).FieldCaption == field.FieldCaption &&
                                                            ((QAddDatasourceFieldCR)C).InstallationCode == installationCode).ToList();
            if (children == null || children.Count == 0)
            {
               // add child
               QAddDatasourceFieldCR newchild = ChangeRequest.AddNewChild<QAddDatasourceFieldCR>();
               newchild.FieldName = field.FieldName;
               newchild.FieldCaption = field.FieldCaption;
            }
         }
      }
      #endregion

   }
}
