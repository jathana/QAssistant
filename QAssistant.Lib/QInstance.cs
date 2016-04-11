using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib
{
   public static class QInstance
   {
      public static QEnvironments Environments;

      private static string projectsPath = "";
      public static string ProjectsPath
      {
         get
         {
            return projectsPath;
         }
      }

     
         
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
            XmlDocument doc = new XmlDocument();
            doc.Load(EnvFile);
            Environments = new QEnvironments(doc);
            projectsPath = doc.SelectSingleNode("//projects/@path").Value;
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
