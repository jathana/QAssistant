using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QDUIStackCRModifier
   {

      #region fields
      private QCRFields fields = new QCRFields();
      private QConfigureDUIStackCR cr;

      #endregion

      public QDUIStackCRModifier(QConfigureDUIStackCR cr)
      {
         this.cr = cr;
      }

      #region properties
      public QCRFields Fields
      {
         get
         {
            return fields;
         }
      }
      #endregion

      #region methods
      
      #endregion

   }
}
