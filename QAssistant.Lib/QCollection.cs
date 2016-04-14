using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QCollection:BindingList<object>, ICloneable
   {
      #region fields
      private BindingList<object> availableItems;
      #endregion

      #region properties

      public BindingList<object> AvailableItems
      {
         get
         {
            return availableItems;
         }

         set
         {
            availableItems = value;
         }
      }

      public object Clone()
      {
         QCollection retval = new QCollection();
         retval.availableItems = availableItems;
         foreach(object obj in this)
         {
            object newObj=((ICloneable)obj).Clone();
            retval.Add(newObj);
         }
         return retval;
      }


      #endregion
   }
}
