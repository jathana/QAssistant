Imports System.Configuration

Public Class SqlConnectionDialog



   Public Property ConnectionString As String

   Public Function ShowDialog() As System.Windows.Forms.DialogResult
      Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

      Dim dialog As New SQLServerConnectionDialog()
      Try
         dialog.ConnectionString = config.ConnectionStrings.ConnectionStrings("conn").ConnectionString
      Catch ex As Exception

      End Try


      Dim result As System.Windows.Forms.DialogResult
      result = dialog.ShowDialog() ' = System.Windows.Forms.DialogResult.Cancel Then Return False
      ConnectionString = dialog.ConnectionString
      Return result
      Dim CS As String = dialog.ConnectionString

      config.ConnectionStrings.ConnectionStrings("conn").ConnectionString = CS
      config.Save(ConfigurationSaveMode.Modified)

      ConfigurationManager.RefreshSection("connectionStrings")
   End Function

End Class
