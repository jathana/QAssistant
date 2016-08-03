using QAssistant.Lib.ChangeRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib
{
   public static class TypeExtensions
   {

      /// <summary>
      /// Gets the Description attribute of a type.
      /// </summary>
      /// <param name="type"></param>
      /// <returns>Returns the Description attribute of a type.</returns>
      public static string GetDescription(this Type type)
      {
         string retval = "";
         System.Reflection.MemberInfo inf = type;

         object[] descriptions = inf.GetCustomAttributes(typeof(DescriptionAttribute), false);

         string delim = "";
         foreach (Object attribute in descriptions)
         {
            DescriptionAttribute da = (DescriptionAttribute)attribute;
            retval += delim + da.Description;
            delim = " ";
         }
         return retval;
      }




   }
}
