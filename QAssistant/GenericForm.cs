using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant
{
   public class GenericForm<T> : DevExpress.XtraEditors.XtraForm
   {
      public T Obj;

      public GenericForm()

      {

      }

      public GenericForm(T obj)
      {

         Obj = obj;

      }
   }
}
