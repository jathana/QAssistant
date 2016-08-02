using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QConfigureDatasourceCRModifier : QCRModifier
   {

      #region fields
      private int installationCode = 0;
      private List<QPoolField> poolFields = new List<QPoolField>();

      #endregion

      public QConfigureDatasourceCRModifier()
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
      [Editor(typeof(QInstallationCodeTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
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
         foreach(QPoolField field in poolFields)
         {
            var children = ChangeRequest.Children.Where(C => C.GetType() == typeof(QAddDatasourceFieldCR) && 
                                                            ((QAddDatasourceFieldCR)C).FieldName == field.FieldName &&
                                                            ((QAddDatasourceFieldCR)C).FieldCaption == field.EnglishCaption &&
                                                            ((QAddDatasourceFieldCR)C).InstallationCode == installationCode).ToList();
            if (children == null || children.Count == 0)
            {
               // add child
               QAddDatasourceFieldCR newchild = ChangeRequest.AddNewChild<QAddDatasourceFieldCR>();
               newchild.FieldName = field.FieldName;
               newchild.FieldCaption = field.EnglishCaption;
            }
         }
      }
      #endregion

   }
}
