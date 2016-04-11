using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QCRAction
   {
      public string Description { get; set; }
      public QCRActionType ActionType { get; set; }
      public QCRActionState State { get; set; }
      public QDatabaseName DatabaseName {get; set; }


      public QCRAction()
      {
      }

      public QCRAction(QCRActionState state, QCRActionType actionType, string description, QDatabaseName databaseName)
      {
         State = state;
         ActionType = actionType;
         Description = description;
         DatabaseName = databaseName;
      } 
   }
}
