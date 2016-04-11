using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib
{
   public class QEnvironments: Dictionary<QEnvironmentType, QEnvironment>, IDisposable
   { 
      public QEnvironments(string EnvFile)
      {
         if (File.Exists(EnvFile))
         {
            XmlDocument doc = new XmlDocument();
            doc.Load(EnvFile);
            XmlNodeList envs = doc.SelectNodes("//environment");
            foreach (XmlNode envNode in envs)
            {
               QEnvironment envItem = new QEnvironment();
               envItem.FromXml(envNode);
               if(!ContainsKey(envItem.EnvType))
               Add(envItem.EnvType, envItem);
            }

         }

      }

      public QDatabaseNames GetDatabaseNames(QEnvironmentType envType)
      {
         QDatabaseNames result = new QDatabaseNames();
         if (envType == QEnvironmentType.All)
         {
            foreach (QEnvironment env in this.Values)
            {
               foreach (QSQLServer srv in env.SqlServers)
               {
                  foreach (QDatabase db in srv.Databases)
                  {
                     result.Add(db.FullName);
                  }
               }
            }

         }
         else
         {
            foreach (QSQLServer srv in this[envType].SqlServers)
            {
               foreach (QDatabase db in srv.Databases)
               {
                  result.Add(db.FullName);
               }
            }
         }
         return result;
      }


      public QDatabases GetDatabases(QEnvironmentType envType)
      {
         QDatabases result = new QDatabases();
         foreach(QSQLServer srv in this[envType].SqlServers)
         {
            foreach(QDatabase db in srv.Databases)
            {
               result.Add(db);
            }
         }
         return result;
      }


      public QDatabase GetDatabase(QDatabaseName databaseName)
      {
         QDatabase retval = null;
         if (this.ContainsKey(databaseName.EnvironmentType))
         {
            foreach (QSQLServer srv in this[databaseName.EnvironmentType].SqlServers)
            {
               retval = srv.Databases.FirstOrDefault(D => D.FullName.Equals(databaseName));
               if (retval != null) break;
            }
         }
         return retval;
      }

      public void Dispose()
      {
         foreach (QEnvironment environment in this.Values)
         {
            (environment as IDisposable).Dispose();
         }
         this.Clear();
         
      }
   }
}
