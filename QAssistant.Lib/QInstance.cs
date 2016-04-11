using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public static class QInstance
   {
      public static QEnvironments Environments;


         
      public static bool Init(string EnvFile)
      {
         bool retval = true;
         try
         {
            if (Environments != null)
            {
               Environments.Dispose();
               Environments = null;
            }
            Environments = new QEnvironments(EnvFile);
         }
         catch(Exception ex)
         {
            retval = false;
         }
         return retval;

      }

      public static bool Dispose()
      {
         bool retval = true;
         try
         {
            if (Environments != null)
            {
               Environments.Dispose();
               Environments = null;
            }
         }
         catch (Exception ex)
         {
            retval = false;
         }
         return retval;

      }
   }
}
