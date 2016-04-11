using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public abstract class QCRModifier: IModifier
   {
      [Browsable(false)]
      public QChangeRequest ChangeRequest; 
      public abstract void Modify();
   }
}
