using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib
{
   public class QConnectionString
   {
      public string Name { get; set; }
      public string Value { get; set; }

      public void FromXml(XmlNode node)
        {
            Name = node.Attributes["name"].Value.ToString();
            Value = node.Attributes["connectionstring"].Value.ToString();
        }
   }
}
