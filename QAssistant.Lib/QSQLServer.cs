using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib
{
   public class QSQLServer: IDisposable
   {
      public string Name { get; set; }
      public QDatabases Databases { get; set; }
      public QEnvironment Parent { get; set; }

      public QSQLServer()
      {
         Databases = new QDatabases();
      }

      public void FromXml(XmlNode node)
      {
         Name = node.Attributes["name"].Value.ToString();
         XmlNodeList list = node.SelectNodes("databases/database");
         foreach(XmlNode dbnode in list)
         {
            QDatabase db = new QDatabase(Parent.EnvType, Name);
            db.Deserialize(dbnode);
            if(!Databases.Any(D=>D.FullName==db.FullName))
               Databases.Add(db);
         }
      }

      public void Dispose()
      {
         if(Databases != null)
         {
            Databases.Dispose();
         }
      }
   }
}
