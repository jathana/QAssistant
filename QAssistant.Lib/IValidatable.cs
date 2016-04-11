using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public interface IValidatable
   {
      bool Validate(out Dictionary<string, string> errors);
   }
}
