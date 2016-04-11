namespace QAssistant.UI.SQLServerConnection
{
   partial class ucConnectionString
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.btNewConnection = new DevExpress.XtraEditors.SimpleButton();
         this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
         ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // btNewConnection
         // 
         this.btNewConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btNewConnection.Location = new System.Drawing.Point(438, 0);
         this.btNewConnection.Name = "btNewConnection";
         this.btNewConnection.Size = new System.Drawing.Size(107, 23);
         this.btNewConnection.TabIndex = 0;
         this.btNewConnection.Text = "New Connection";
         this.btNewConnection.Click += new System.EventHandler(this.btNewConnection_Click);
         // 
         // memoEdit1
         // 
         this.memoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.memoEdit1.Location = new System.Drawing.Point(0, 0);
         this.memoEdit1.Name = "memoEdit1";
         this.memoEdit1.Properties.ReadOnly = true;
         this.memoEdit1.Size = new System.Drawing.Size(435, 25);
         this.memoEdit1.TabIndex = 1;
         // 
         // ucConnectionString
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.memoEdit1);
         this.Controls.Add(this.btNewConnection);
         this.Name = "ucConnectionString";
         this.Size = new System.Drawing.Size(548, 24);
         ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton btNewConnection;
      private DevExpress.XtraEditors.MemoEdit memoEdit1;
   }
}
