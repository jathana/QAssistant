using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public static class QCRFactory
   {

      public static QChangeRequest GetObject(string nspace, string name)
      {
         //object obj = Activator.CreateInstance("QAssistant.Lib", string.Format("QAssistant.Lib.ChangeRequests.{0}", name));

         object obj = Activator.CreateInstance(Type.GetType(string.Format("{0}.{1}", nspace, name)));
         
         return (QChangeRequest)obj;
      }
     
   }
}
