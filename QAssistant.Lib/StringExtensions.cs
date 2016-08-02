using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib
{
   public static class StringExtensions
   {
      public static bool HasTrailingSpaces(this String value)
      {
         return !string.IsNullOrEmpty(value) && (value.EndsWith(" ") || value.StartsWith(" "));

      }
   }
}
