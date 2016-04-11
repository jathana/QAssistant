using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib.ChangeRequests
{
   public class QChangeRequests:BindingList<QChangeRequest>
   {

      public void Delete(QChangeRequest item)
      {
         if(item.Children != null && item.Children.Count > 0)
         {
            foreach(QChangeRequest child in item.Children)
            {
               Delete(child);
            }
         }
         else
         {

            item.Children.Clear();
         }
      }

   }
}
