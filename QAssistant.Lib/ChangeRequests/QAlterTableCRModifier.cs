using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QAlterTableCRModifier:QCRModifier
   {

      #region fields
      private QCRFields fields = new QCRFields();
      

      #endregion

      public QAlterTableCRModifier()
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
            var children = ChangeRequest.Children.Where(C => C.GetType() == typeof(QAddColumnToTableCR) && ((QAddColumnToTableCR)C).ColumnName == field.FieldName).ToList();
            if (children == null || children.Count == 0)
            {
               // add child
               QAddColumnToTableCR newchild= ChangeRequest.AddNewChild<QAddColumnToTableCR>();
               newchild.ColumnName = field.FieldName;
            }
         }
      }
      #endregion

   }
}
