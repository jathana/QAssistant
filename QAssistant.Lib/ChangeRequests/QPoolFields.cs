using QAssistant.Lib.ChangeRequests;
using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib.ChangeRequests
{
   [Description("Pool Fields")]
   public class QPoolFields : QGroupCR
   {
      #region fields

      #endregion

      #region properties


      #endregion

      public QPoolFields():base()
      {
         Name = "Pool Fields";

         // remove any children from parent
         compatibleChildren.Clear();
         SetCompatibleChildren();
         needsChildren = true;
      }

      void SetCompatibleChildren()
      {
         compatibleChildren.Add(typeof(QPoolField));
      }

      #region methods
      
      #endregion


      #region Serialization
      

      #endregion

      #region Checks
      public override bool Check()
      {
         bool result = base.Check();
         
         // check children
         foreach (QChangeRequest cr in Children)
         {
            result = cr.Check() && result;
            Actions.AddRange(cr.Actions);
         }
         NotifyPropertyChanged(nameof(CheckResultType));
         return result;
      }
      #endregion
   }
}
