Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Configuration

Public Class SQLServerConnectionDialog

    Dim conn As New SqlConnectionStringBuilder()
    Public RootPath As String = ""

    Private Sub frmSQLConnectionDialog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cbServer.Text = conn.DataSource
        cbDataBase.Text = conn.InitialCatalog

        If conn.IntegratedSecurity = False Then
            txtUser.Enabled = True
            txtPassword.Enabled = True
            rbAuthenticationWin.Checked = False
            rbAuthenticationSql.Checked = True
            txtUser.Text = conn.UserID
            txtPassword.Text = conn.Password
        End If

    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        SqlInstances()
    End Sub

    Sub ContructConnection()
        conn.DataSource = cbServer.Text
        conn.IntegratedSecurity = True
        conn.UserID = ""
        conn.Password = ""
        conn.InitialCatalog = ""

        If rbAuthenticationSql.Checked Then
            conn.IntegratedSecurity = False
            conn.UserID = txtUser.Text
            conn.Password = txtPassword.Text
        End If
        If cbDataBase.Text <> "" Then
            conn.InitialCatalog = cbDataBase.Text
        End If
    End Sub

    Sub SqlInstances()
      Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
      Try
            cbServer.Items.Clear()
            Dim sqlSources As DataTable = SqlDataSourceEnumerator.Instance.GetDataSources
            For Each datarow As DataRow In sqlSources.Rows
                Dim datasource As String = datarow("ServerName").ToString
                If Not datarow("InstanceName") Is DBNull.Value Then
                    datasource &= String.Format("\{0}", datarow("InstanceName"))
                End If
                cbServer.Items.Add(datasource)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      Cursor.Current = System.Windows.Forms.Cursors.Default
   End Sub

    Sub SqlDatabaseNames()

        ContructConnection()
      Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
      Dim connString As String
        Dim databaseNames As New List(Of String)
        connString = conn.ConnectionString
        cbDataBase.Items.Clear()
        Try
            Using cn As SqlConnection = New SqlConnection(connString)
                cn.Open()
                Using cmd As SqlCommand = New SqlCommand()
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_databases"

                    Using myReader As SqlDataReader = cmd.ExecuteReader()
                        While (myReader.Read())
                            cbDataBase.Items.Add(myReader.GetString(0))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      Cursor.Current = System.Windows.Forms.Cursors.Default
   End Sub


    Sub TestDB()
        ContructConnection()
        Try
            Dim objConn As SqlConnection = New SqlConnection(conn.ConnectionString)
            objConn.Open()
            objConn.Close()
            MsgBox("Successful connection!!!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub cbServer_DropDown(sender As System.Object, e As System.EventArgs) Handles cbServer.DropDown
        If cbServer.Items.Count = 0 Then
            SqlInstances()
        End If
    End Sub

    Private Sub cbDataBase_DropDown(sender As System.Object, e As System.EventArgs) Handles cbDataBase.DropDown
        SqlDatabaseNames()
    End Sub

    Private Sub rbAuthenticationWin_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbAuthenticationWin.CheckedChanged
        txtUser.Enabled = False
        txtPassword.Enabled = False
    End Sub

    Private Sub rbAuthenticationSql_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbAuthenticationSql.CheckedChanged
        txtUser.Enabled = True
        txtPassword.Enabled = True
    End Sub


    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        TestDB()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ContructConnection()
        Me.Close()
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
   End Sub

    Public Property ConnectionString() As String
        Get
            Return conn.ConnectionString
        End Get
        Set(ByVal value As String)
            conn.ConnectionString = value
        End Set
    End Property


End Class