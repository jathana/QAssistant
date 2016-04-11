using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QAlterViewCRModifier:QCRModifier
   {

      #region fields
      private QCRFields fields = new QCRFields();

      #endregion

      public QAlterViewCRModifier()
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
      #endregion
      #region methods

      public override void Modify()
      {
         foreach(QCRField field in fields)
         {
            var children = ChangeRequest.Children.Where(C => C.GetType() == typeof(QAddColumnToViewCR) && ((QAddColumnToViewCR)C).ColumnName == field.FieldName).ToList();
            if (children == null || children.Count == 0)
            {
               // add child
               QAddColumnToViewCR newchild= ChangeRequest.AddNewChild<QAddColumnToViewCR>();
               newchild.ColumnName = field.FieldName;
            }
         }
      }
      #endregion

   }
}
