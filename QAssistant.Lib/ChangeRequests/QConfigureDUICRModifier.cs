﻿using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QConfigureDUICRModifier : QCRModifier
   {

      #region fields
      private int installationCode = 0;
      private List<QPoolField> poolFields = new List<QPoolField>();

      #endregion

      public QConfigureDUICRModifier()
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

      public int InstallationCode
      {
         get
         {
            int retval = 0;
            if(ChangeRequest!=null)
            {
               retval = ((QConfigureDUICR)ChangeRequest).InstallationCode;
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
            var children = ChangeRequest.Children.Where(C => C.GetType() == typeof(QAddDUIFieldCR) && 
                                                            ((QAddDUIFieldCR)C).FieldName == field.FieldName &&
                                                            ((QAddDUIFieldCR)C).InstallationCode == installationCode).ToList();
            if (children == null || children.Count == 0)
            {
               // add child
               QAddDUIFieldCR newchild = ChangeRequest.AddNewChild<QAddDUIFieldCR>();
               newchild.FieldName = field.FieldName;
            }
         }
      }
      #endregion

   }
}
