using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QCRField
   {

      
      public string FieldName { get; set; }
      public string FieldCaption { get; set; }
      public string GreekCaption { get; set; }

      public QCRField()
      {
         FieldName = "";         
         FieldCaption = "";
         GreekCaption = "";
      }

      public QCRField(string fieldName, string fieldCaption)
      {
         FieldName = fieldName;
         FieldCaption = fieldCaption;
      }
   }
}
