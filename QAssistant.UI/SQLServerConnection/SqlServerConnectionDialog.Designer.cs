namespace QAssistant.UI.SQLServerConnection
{
   partial class SqlServerConnectionDialog
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.cbServer = new DevExpress.XtraEditors.ComboBoxEdit();
         this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
         this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
         this.txtPassword = new DevExpress.XtraEditors.TextEdit();
         this.txtUser = new DevExpress.XtraEditors.TextEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.rbAuthenticationSql = new DevExpress.XtraEditors.CheckEdit();
         this.rbAuthenticationWin = new DevExpress.XtraEditors.CheckEdit();
         this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
         this.cbDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnTest = new DevExpress.XtraEditors.SimpleButton();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.cbServer.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
         this.groupControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.rbAuthenticationSql.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.rbAuthenticationWin.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
         this.groupControl2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(14, 12);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(62, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Server Name";
         // 
         // cbServer
         // 
         this.cbServer.Location = new System.Drawing.Point(13, 32);
         this.cbServer.Name = "cbServer";
         this.cbServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cbServer.Size = new System.Drawing.Size(201, 20);
         this.cbServer.TabIndex = 1;
         this.cbServer.SelectedIndexChanged += new System.EventHandler(this.cbServer_SelectedIndexChanged);
         this.cbServer.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.cbServer_QueryPopUp);
         // 
         // btnRefresh
         // 
         this.btnRefresh.Location = new System.Drawing.Point(220, 30);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(86, 23);
         this.btnRefresh.TabIndex = 2;
         this.btnRefresh.Text = "Refresh";
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // groupControl1
         // 
         this.groupControl1.Controls.Add(this.txtPassword);
         this.groupControl1.Controls.Add(this.txtUser);
         this.groupControl1.Controls.Add(this.labelControl3);
         this.groupControl1.Controls.Add(this.labelControl2);
         this.groupControl1.Controls.Add(this.rbAuthenticationSql);
         this.groupControl1.Controls.Add(this.rbAuthenticationWin);
         this.groupControl1.Location = new System.Drawing.Point(14, 58);
         this.groupControl1.Name = "groupControl1";
         this.groupControl1.Size = new System.Drawing.Size(292, 140);
         this.groupControl1.TabIndex = 4;
         this.groupControl1.Text = "Log on to the server";
         // 
         // txtPassword
         // 
         this.txtPassword.Location = new System.Drawing.Point(72, 109);
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.Size = new System.Drawing.Size(207, 20);
         this.txtPassword.TabIndex = 5;
         // 
         // txtUser
         // 
         this.txtUser.Location = new System.Drawing.Point(72, 83);
         this.txtUser.Name = "txtUser";
         this.txtUser.Size = new System.Drawing.Size(207, 20);
         this.txtUser.TabIndex = 4;
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(14, 112);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(46, 13);
         this.labelControl3.TabIndex = 3;
         this.labelControl3.Text = "Password";
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(14, 86);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(22, 13);
         this.labelControl2.TabIndex = 2;
         this.labelControl2.Text = "User";
         // 
         // rbAuthenticationSql
         // 
         this.rbAuthenticationSql.Location = new System.Drawing.Point(14, 55);
         this.rbAuthenticationSql.Name = "rbAuthenticationSql";
         this.rbAuthenticationSql.Properties.Caption = "Use SQL Server Authentication";
         this.rbAuthenticationSql.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
         this.rbAuthenticationSql.Properties.RadioGroupIndex = 0;
         this.rbAuthenticationSql.Size = new System.Drawing.Size(273, 19);
         this.rbAuthenticationSql.TabIndex = 1;
         this.rbAuthenticationSql.TabStop = false;
         this.rbAuthenticationSql.CheckedChanged += new System.EventHandler(this.rbAuthenticationSql_CheckedChanged);
         // 
         // rbAuthenticationWin
         // 
         this.rbAuthenticationWin.Location = new System.Drawing.Point(14, 30);
         this.rbAuthenticationWin.Name = "rbAuthenticationWin";
         this.rbAuthenticationWin.Properties.Caption = "Use Windows Authentication";
         this.rbAuthenticationWin.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
         this.rbAuthenticationWin.Properties.RadioGroupIndex = 0;
         this.rbAuthenticationWin.Size = new System.Drawing.Size(273, 19);
         this.rbAuthenticationWin.TabIndex = 0;
         this.rbAuthenticationWin.TabStop = false;
         this.rbAuthenticationWin.CheckedChanged += new System.EventHandler(this.rbAuthenticationWin_CheckedChanged);
         // 
         // groupControl2
         // 
         this.groupControl2.Controls.Add(this.cbDatabase);
         this.groupControl2.Controls.Add(this.labelControl4);
         this.groupControl2.Location = new System.Drawing.Point(13, 205);
         this.groupControl2.Name = "groupControl2";
         this.groupControl2.Size = new System.Drawing.Size(293, 100);
         this.groupControl2.TabIndex = 5;
         this.groupControl2.Text = "Connect to database";
         // 
         // cbDatabase
         // 
         this.cbDatabase.Location = new System.Drawing.Point(15, 61);
         this.cbDatabase.Name = "cbDatabase";
         this.cbDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cbDatabase.Size = new System.Drawing.Size(265, 20);
         this.cbDatabase.TabIndex = 5;
         this.cbDatabase.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.cbDatabase_QueryPopUp);
         // 
         // labelControl4
         // 
         this.labelControl4.Location = new System.Drawing.Point(15, 42);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(157, 13);
         this.labelControl4.TabIndex = 4;
         this.labelControl4.Text = "Select or enter a database name";
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(231, 311);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 6;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnTest
         // 
         this.btnTest.Location = new System.Drawing.Point(14, 311);
         this.btnTest.Name = "btnTest";
         this.btnTest.Size = new System.Drawing.Size(75, 23);
         this.btnTest.TabIndex = 7;
         this.btnTest.Text = "Test";
         this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(150, 311);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 8;
         this.btnOK.Text = "OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // SqlServerConnectionDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(317, 345);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.groupControl2);
         this.Controls.Add(this.groupControl1);
         this.Controls.Add(this.btnRefresh);
         this.Controls.Add(this.cbServer);
         this.Controls.Add(this.labelControl1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.Name = "SqlServerConnectionDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "SQL Server Connection";
         this.Load += new System.EventHandler(this.SqlServerConnectionDialog_Load);
         ((System.ComponentModel.ISupportInitialize)(this.cbServer.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
         this.groupControl1.ResumeLayout(false);
         this.groupControl1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.rbAuthenticationSql.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.rbAuthenticationWin.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
         this.groupControl2.ResumeLayout(false);
         this.groupControl2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.ComboBoxEdit cbServer;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private DevExpress.XtraEditors.GroupControl groupControl1;
      private DevExpress.XtraEditors.TextEdit txtPassword;
      private DevExpress.XtraEditors.TextEdit txtUser;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.CheckEdit rbAuthenticationSql;
      private DevExpress.XtraEditors.CheckEdit rbAuthenticationWin;
      private DevExpress.XtraEditors.GroupControl groupControl2;
      private DevExpress.XtraEditors.ComboBoxEdit cbDatabase;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnTest;
      private DevExpress.XtraEditors.SimpleButton btnOK;
   }
}