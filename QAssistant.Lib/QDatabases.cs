using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QDatabases : List<QDatabase>, IDisposable
   {
      public void Dispose()
      {
         foreach(QDatabase database in this)
         {
            (database as IDisposable).Dispose();
         }
      }
   }
}
