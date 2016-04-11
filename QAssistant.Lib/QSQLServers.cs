using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QSQLServers:List<QSQLServer>, IDisposable
   {
      public void Dispose()
      {
         foreach (QSQLServer server in this)
         {
            (server as IDisposable).Dispose();
         }
      }
   }
}
