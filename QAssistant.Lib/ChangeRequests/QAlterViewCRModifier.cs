using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QAlterViewCRModifier:QCRModifier
   {

      #region fields
      private List<QPoolField> poolFields = new List<QPoolField>();

      #endregion

      public QAlterViewCRModifier()
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
      #endregion
      #region methods

      public override void Modify()
      {
         foreach(QPoolField field in poolFields)
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
