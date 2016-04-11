using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAssistant.Lib
{
   public class QDatabaseName
   {
      private const char separator='.';
      #region fields
      public string Name { get; set; }
      public string SqlServer { get; set; }
      public QEnvironmentType EnvironmentType { get; set; }
      #endregion
      
      public QDatabaseName()
      {
         Name = "";
         SqlServer = "";
         EnvironmentType = QEnvironmentType.None;

      }

      #region properties
      public string FullName
      {
         get
         {
            return ToString();
         }
      }
      #endregion
      #region methods

      public bool IsInvalid()
      {
         return EnvironmentType == QEnvironmentType.None || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(SqlServer);
      }

      public QDatabaseName(string fullName)
      {
         FromString(fullName);
      }

      public override bool Equals(object obj)
      {
         // Check for null values and compare run-time types.
         if (obj == null || GetType() != obj.GetType())
            return false;

         QDatabaseName name = (QDatabaseName)obj;
         return name.EnvironmentType == EnvironmentType && name.SqlServer == SqlServer && name.Name == Name;
      }


      public override string ToString()
      {
         return string.Format("{0}{3}{1}{3}{2}", EnvironmentType, SqlServer, Name, separator);
      }

      public void FromString(string value)
      {
         if (!string.IsNullOrEmpty(value))
         {
            string[] arr = value.Split(separator);
            EnvironmentType = (QEnvironmentType)Enum.Parse(typeof(QEnvironmentType), arr[0]);
            SqlServer = arr[1];
            Name = arr[2];
         }
      }
      #endregion
   }
}
