using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QDataDiff
   {
      public string TableName { get; set; }
      public string FieldName { get; set; }
      public object KeyValue { get; set; }
      public object SourceValue { get; set; }
      public object DestValue { get; set; }
   }
}
