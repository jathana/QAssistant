using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QAlterTableCRModifier:QCRModifier
   {

      #region fields
      private List<QPoolField> poolFields = new List<QPoolField>();
      

      #endregion

      public QAlterTableCRModifier()
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
         foreach(QPoolField poolField in poolFields)
         {
            var children = ChangeRequest.GetDescendants<QAddColumnToTableCR>().Where(C => C.ColumnName == poolField.FieldName).ToList();
            if (children == null || children.Count == 0)
            {
               // add child
               QAddColumnToTableCR newchild= ChangeRequest.AddNewChild<QAddColumnToTableCR>();
               newchild.ColumnName = poolField.FieldName;
            }
         }
      }
      #endregion

   }
}
