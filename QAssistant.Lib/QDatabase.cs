using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib
{
   public class QDatabase : IDisposable
   {
      private QDatabaseName fullName = new QDatabaseName();
      private bool integratedSecurity = true;
      private string connectionString = "";
      private string userid = "";
      private string password = "";

      private SqlConnection connection = new SqlConnection();

      public QDatabase(QEnvironmentType envType,  string server)
      {
         fullName.SqlServer = server;
         fullName.EnvironmentType = envType;
      }

      public void Deserialize(XmlNode node)
      {
         fullName.Name = node.ReadString("name");
         integratedSecurity = node.ReadBool("integratedsecurity");
         userid = node.ReadString("userid");
         password = node.ReadString("password");
         SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
         builder.DataSource = fullName.SqlServer;
         builder.IntegratedSecurity = this.integratedSecurity;
         builder.InitialCatalog = fullName.Name;
         builder.UserID = userid;
         builder.Password = password;
         connectionString = builder.ConnectionString;
      }

      public DataSet ExecuteQuery(string Sql)
      {
         DataSet ds = new DataSet();
         OpenConnection();
         if (Connection != null)
         {
            SqlDataAdapter adapter = new SqlDataAdapter(Sql, Connection);
            adapter.Fill(ds);
            adapter.Dispose();
         }
         return ds;
      }

      public DataTable ExecuteCommand(SqlCommand command)
      {
         DataTable tb = new DataTable();
         command.Connection = Connection;
         OpenConnection();
         if (Connection != null)
         {
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tb);
            adapter.Dispose();
         }
         return tb;
      }

      public object ExecuteScalar(SqlCommand command)
      {
         object retval = null;
         command.Connection = Connection;
         OpenConnection();
         if (Connection != null)
         {
            retval =command.ExecuteScalar();
         }
         return retval;
      }

      public string ConnectionString
      {
         get
         {
            return connectionString;
         }
         set
         {
            string oldValue = ConnectionString;
            if (!oldValue.Equals(value))
            {
               connectionString = value;
               CloseConnection();
            }
         }
      }

      public SqlConnection Connection
      {
         get
         {
            OpenConnection();
            return connection;
         }
      }

      public QDatabaseName FullName
      {
         get
         {
            return fullName;
         }

         set
         {
            fullName = value;
         }
      }

      private void OpenConnection()
      {
         if (!string.IsNullOrWhiteSpace(connectionString))
         {
            // close broken connection
            if (connection.State == ConnectionState.Broken)
            {
               connection.Close();
            }

            if (connection.State == ConnectionState.Closed)
            {
               connection.ConnectionString = connectionString;
               connection.Open();
            }
         }
      }

      private void CloseConnection()
      {

         if(connection != null && connection.State != ConnectionState.Closed)
         {
            connection.Close();
         }
      }


      void IDisposable.Dispose()
      {
         CloseConnection();
      }

      public override string ToString()
      {
         return fullName.ToString();
      }

      public void FromString(string value)
      {
         fullName.FromString(value);
      }
   }
}
