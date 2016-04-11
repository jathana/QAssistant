<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SQLServerConnectionDialog
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.lbServidor = New System.Windows.Forms.Label()
      Me.cbServer = New System.Windows.Forms.ComboBox()
      Me.btnRefresh = New System.Windows.Forms.Button()
      Me.rbAuthenticationWin = New System.Windows.Forms.RadioButton()
      Me.rbAuthenticationSql = New System.Windows.Forms.RadioButton()
      Me.txtUser = New System.Windows.Forms.TextBox()
      Me.txtPassword = New System.Windows.Forms.TextBox()
      Me.lbUsuario = New System.Windows.Forms.Label()
      Me.lbClave = New System.Windows.Forms.Label()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnTest = New System.Windows.Forms.Button()
      Me.cbDataBase = New System.Windows.Forms.ComboBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.lbBase = New System.Windows.Forms.Label()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.SuspendLayout()
      '
      'lbServidor
      '
      Me.lbServidor.AutoSize = True
      Me.lbServidor.Location = New System.Drawing.Point(7, 6)
      Me.lbServidor.Name = "lbServidor"
      Me.lbServidor.Size = New System.Drawing.Size(69, 13)
      Me.lbServidor.TabIndex = 0
      Me.lbServidor.Text = "Server Name"
      '
      'cbServer
      '
      Me.cbServer.FormattingEnabled = True
      Me.cbServer.Location = New System.Drawing.Point(10, 23)
      Me.cbServer.Name = "cbServer"
      Me.cbServer.Size = New System.Drawing.Size(232, 21)
      Me.cbServer.TabIndex = 1
      '
      'btnRefresh
      '
      Me.btnRefresh.Location = New System.Drawing.Point(248, 21)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(82, 23)
      Me.btnRefresh.TabIndex = 2
      Me.btnRefresh.Text = "Refresh"
      '
      'rbAuthenticationWin
      '
      Me.rbAuthenticationWin.AutoSize = True
      Me.rbAuthenticationWin.Checked = True
      Me.rbAuthenticationWin.Location = New System.Drawing.Point(13, 20)
      Me.rbAuthenticationWin.Name = "rbAuthenticationWin"
      Me.rbAuthenticationWin.Size = New System.Drawing.Size(162, 17)
      Me.rbAuthenticationWin.TabIndex = 3
      Me.rbAuthenticationWin.TabStop = True
      Me.rbAuthenticationWin.Text = "Use Windows Authentication"
      Me.rbAuthenticationWin.UseVisualStyleBackColor = True
      '
      'rbAuthenticationSql
      '
      Me.rbAuthenticationSql.AutoSize = True
      Me.rbAuthenticationSql.Location = New System.Drawing.Point(13, 42)
      Me.rbAuthenticationSql.Name = "rbAuthenticationSql"
      Me.rbAuthenticationSql.Size = New System.Drawing.Size(173, 17)
      Me.rbAuthenticationSql.TabIndex = 4
      Me.rbAuthenticationSql.Text = "Use SQL Server Authentication"
      '
      'txtUser
      '
      Me.txtUser.Enabled = False
      Me.txtUser.Location = New System.Drawing.Point(81, 72)
      Me.txtUser.Name = "txtUser"
      Me.txtUser.Size = New System.Drawing.Size(212, 20)
      Me.txtUser.TabIndex = 7
      '
      'txtPassword
      '
      Me.txtPassword.Enabled = False
      Me.txtPassword.Location = New System.Drawing.Point(81, 98)
      Me.txtPassword.Name = "txtPassword"
      Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtPassword.Size = New System.Drawing.Size(212, 20)
      Me.txtPassword.TabIndex = 8
      '
      'lbUsuario
      '
      Me.lbUsuario.AutoSize = True
      Me.lbUsuario.Location = New System.Drawing.Point(22, 75)
      Me.lbUsuario.Name = "lbUsuario"
      Me.lbUsuario.Size = New System.Drawing.Size(29, 13)
      Me.lbUsuario.TabIndex = 9
      Me.lbUsuario.Text = "User"
      '
      'lbClave
      '
      Me.lbClave.AutoSize = True
      Me.lbClave.Location = New System.Drawing.Point(22, 101)
      Me.lbClave.Name = "lbClave"
      Me.lbClave.Size = New System.Drawing.Size(53, 13)
      Me.lbClave.TabIndex = 10
      Me.lbClave.Text = "Password"
      '
      'btnOK
      '
      Me.btnOK.Location = New System.Drawing.Point(6, 322)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(82, 23)
      Me.btnOK.TabIndex = 25
      Me.btnOK.Tag = ""
      Me.btnOK.Text = "OK"
      '
      'btnCancel
      '
      Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnCancel.Location = New System.Drawing.Point(94, 322)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(82, 23)
      Me.btnCancel.TabIndex = 24
      Me.btnCancel.Text = "Cancel"
      '
      'btnTest
      '
      Me.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnTest.Location = New System.Drawing.Point(248, 322)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.Size = New System.Drawing.Size(82, 23)
      Me.btnTest.TabIndex = 26
      Me.btnTest.Text = "Test"
      '
      'cbDataBase
      '
      Me.cbDataBase.FormattingEnabled = True
      Me.cbDataBase.Location = New System.Drawing.Point(25, 45)
      Me.cbDataBase.Name = "cbDataBase"
      Me.cbDataBase.Size = New System.Drawing.Size(268, 21)
      Me.cbDataBase.TabIndex = 27
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.lbBase)
      Me.GroupBox1.Controls.Add(Me.cbDataBase)
      Me.GroupBox1.Location = New System.Drawing.Point(13, 195)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(317, 108)
      Me.GroupBox1.TabIndex = 33
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Connect to database"
      '
      'lbBase
      '
      Me.lbBase.AutoSize = True
      Me.lbBase.Location = New System.Drawing.Point(3, 29)
      Me.lbBase.Name = "lbBase"
      Me.lbBase.Size = New System.Drawing.Size(161, 13)
      Me.lbBase.TabIndex = 36
      Me.lbBase.Text = "Select or enter a database name"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.txtPassword)
      Me.GroupBox2.Controls.Add(Me.txtUser)
      Me.GroupBox2.Controls.Add(Me.rbAuthenticationWin)
      Me.GroupBox2.Controls.Add(Me.lbUsuario)
      Me.GroupBox2.Controls.Add(Me.lbClave)
      Me.GroupBox2.Controls.Add(Me.rbAuthenticationSql)
      Me.GroupBox2.Location = New System.Drawing.Point(13, 50)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(317, 128)
      Me.GroupBox2.TabIndex = 34
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Log on to the server"
      '
      'SQLServerConnectionDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(347, 357)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.btnTest)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnRefresh)
      Me.Controls.Add(Me.cbServer)
      Me.Controls.Add(Me.lbServidor)
      Me.Controls.Add(Me.GroupBox2)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "SQLServerConnectionDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "SQL Server Connection Dialog"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lbServidor As System.Windows.Forms.Label
    Friend WithEvents cbServer As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents rbAuthenticationWin As System.Windows.Forms.RadioButton
    Friend WithEvents rbAuthenticationSql As System.Windows.Forms.RadioButton
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lbUsuario As System.Windows.Forms.Label
    Friend WithEvents lbClave As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents cbDataBase As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbBase As System.Windows.Forms.Label
End Class
