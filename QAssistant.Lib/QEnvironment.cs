using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib
{
   public class QEnvironment:IDisposable
   {
      public QEnvironmentType EnvType { get; set; }
      public QSQLServers SqlServers { get; set; }

      public QEnvironment()
      {
         SqlServers = new QSQLServers();
      }

      public void FromXml(XmlNode node)
      {
         EnvType = node.ReadEnum<QEnvironmentType>("type");
         XmlNodeList srvs = node.SelectNodes("sqlserver");
         foreach (XmlNode srv in srvs)
         {
            QSQLServer sql = new QSQLServer();
            sql.Parent = this;
            sql.FromXml(srv);
            if(!SqlServers.Any(S=>S.Name==sql.Name))
               SqlServers.Add(sql);
         }
      }

      public void Dispose()
      {
         if(SqlServers!=null)
         {
            foreach(QSQLServer server in SqlServers)
            {
               if(server!=null)
               {
                  server.Dispose();
               }
            }
         }
      }
   }
}
