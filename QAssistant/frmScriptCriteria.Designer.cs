namespace QAssistant
{
   partial class frmScriptCriteria
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
         this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
         this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
         this.txtPath = new DevExpress.XtraEditors.TextEdit();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.gridControl1 = new DevExpress.XtraGrid.GridControl();
         this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colChecked = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
         this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCriUniqueId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCheckResultType = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colDatabaseName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
         this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
         this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
         this.layoutControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
         this.SuspendLayout();
         // 
         // layoutControl1
         // 
         this.layoutControl1.Controls.Add(this.btnBrowse);
         this.layoutControl1.Controls.Add(this.txtPath);
         this.layoutControl1.Controls.Add(this.btnOK);
         this.layoutControl1.Controls.Add(this.btnCancel);
         this.layoutControl1.Controls.Add(this.gridControl1);
         this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.layoutControl1.Location = new System.Drawing.Point(0, 0);
         this.layoutControl1.Name = "layoutControl1";
         this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1307, 216, 250, 350);
         this.layoutControl1.Root = this.layoutControlGroup1;
         this.layoutControl1.Size = new System.Drawing.Size(953, 358);
         this.layoutControl1.TabIndex = 0;
         this.layoutControl1.Text = "layoutControl1";
         // 
         // btnBrowse
         // 
         this.btnBrowse.Location = new System.Drawing.Point(918, 298);
         this.btnBrowse.Name = "btnBrowse";
         this.btnBrowse.Size = new System.Drawing.Size(23, 22);
         this.btnBrowse.StyleController = this.layoutControl1;
         this.btnBrowse.TabIndex = 8;
         this.btnBrowse.Text = "...";
         this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
         // 
         // txtPath
         // 
         this.txtPath.Location = new System.Drawing.Point(68, 298);
         this.txtPath.Name = "txtPath";
         this.txtPath.Size = new System.Drawing.Size(846, 20);
         this.txtPath.StyleController = this.layoutControl1;
         this.txtPath.TabIndex = 7;
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(745, 324);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(84, 22);
         this.btnOK.StyleController = this.layoutControl1;
         this.btnOK.TabIndex = 6;
         this.btnOK.Text = "OK";
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(852, 324);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(89, 22);
         this.btnCancel.StyleController = this.layoutControl1;
         this.btnCancel.TabIndex = 5;
         this.btnCancel.Text = "Cancel";
         // 
         // gridControl1
         // 
         this.gridControl1.Location = new System.Drawing.Point(12, 12);
         this.gridControl1.MainView = this.gridView1;
         this.gridControl1.Name = "gridControl1";
         this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
         this.gridControl1.Size = new System.Drawing.Size(929, 282);
         this.gridControl1.TabIndex = 4;
         this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
         // 
         // gridView1
         // 
         this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChecked,
            this.colName,
            this.colCriUniqueId,
            this.colCheckResultType,
            this.colDatabaseName,
            this.colId});
         this.gridView1.GridControl = this.gridControl1;
         this.gridView1.Name = "gridView1";
         this.gridView1.OptionsBehavior.ReadOnly = true;
         // 
         // colChecked
         // 
         this.colChecked.ColumnEdit = this.repositoryItemCheckEdit1;
         this.colChecked.FieldName = "Checked";
         this.colChecked.Name = "colChecked";
         this.colChecked.Visible = true;
         this.colChecked.VisibleIndex = 0;
         // 
         // repositoryItemCheckEdit1
         // 
         this.repositoryItemCheckEdit1.AutoHeight = false;
         this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
         // 
         // colName
         // 
         this.colName.Caption = "Name";
         this.colName.FieldName = "Name";
         this.colName.Name = "colName";
         this.colName.OptionsColumn.ReadOnly = true;
         this.colName.Visible = true;
         this.colName.VisibleIndex = 1;
         // 
         // colCriUniqueId
         // 
         this.colCriUniqueId.Caption = "Unique Id";
         this.colCriUniqueId.FieldName = "CriUniqueId";
         this.colCriUniqueId.Name = "colCriUniqueId";
         this.colCriUniqueId.OptionsColumn.ReadOnly = true;
         this.colCriUniqueId.Visible = true;
         this.colCriUniqueId.VisibleIndex = 2;
         // 
         // colCheckResultType
         // 
         this.colCheckResultType.Caption = "Check Result";
         this.colCheckResultType.FieldName = "CheckResultType";
         this.colCheckResultType.Name = "colCheckResultType";
         this.colCheckResultType.OptionsColumn.ReadOnly = true;
         this.colCheckResultType.Visible = true;
         this.colCheckResultType.VisibleIndex = 3;
         // 
         // colDatabaseName
         // 
         this.colDatabaseName.Caption = "Database Name";
         this.colDatabaseName.FieldName = "DatabaseName";
         this.colDatabaseName.Name = "colDatabaseName";
         this.colDatabaseName.OptionsColumn.ReadOnly = true;
         this.colDatabaseName.Visible = true;
         this.colDatabaseName.VisibleIndex = 4;
         // 
         // colId
         // 
         this.colId.Caption = "Id";
         this.colId.FieldName = "Id";
         this.colId.Name = "colId";
         // 
         // layoutControlGroup1
         // 
         this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
         this.layoutControlGroup1.GroupBordersVisible = false;
         this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.layoutControlItem5});
         this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlGroup1.Name = "Root";
         this.layoutControlGroup1.Size = new System.Drawing.Size(953, 358);
         this.layoutControlGroup1.TextVisible = false;
         // 
         // layoutControlItem1
         // 
         this.layoutControlItem1.Control = this.gridControl1;
         this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlItem1.Name = "layoutControlItem1";
         this.layoutControlItem1.Size = new System.Drawing.Size(933, 286);
         this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem1.TextVisible = false;
         // 
         // layoutControlItem2
         // 
         this.layoutControlItem2.Control = this.btnCancel;
         this.layoutControlItem2.Location = new System.Drawing.Point(840, 312);
         this.layoutControlItem2.MaxSize = new System.Drawing.Size(93, 26);
         this.layoutControlItem2.MinSize = new System.Drawing.Size(93, 26);
         this.layoutControlItem2.Name = "layoutControlItem2";
         this.layoutControlItem2.Size = new System.Drawing.Size(93, 26);
         this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem2.TextVisible = false;
         // 
         // layoutControlItem3
         // 
         this.layoutControlItem3.Control = this.btnOK;
         this.layoutControlItem3.Location = new System.Drawing.Point(733, 312);
         this.layoutControlItem3.MaxSize = new System.Drawing.Size(88, 26);
         this.layoutControlItem3.MinSize = new System.Drawing.Size(88, 26);
         this.layoutControlItem3.Name = "layoutControlItem3";
         this.layoutControlItem3.Size = new System.Drawing.Size(88, 26);
         this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem3.TextVisible = false;
         // 
         // emptySpaceItem1
         // 
         this.emptySpaceItem1.AllowHotTrack = false;
         this.emptySpaceItem1.Location = new System.Drawing.Point(821, 312);
         this.emptySpaceItem1.MaxSize = new System.Drawing.Size(19, 26);
         this.emptySpaceItem1.MinSize = new System.Drawing.Size(19, 26);
         this.emptySpaceItem1.Name = "emptySpaceItem1";
         this.emptySpaceItem1.Size = new System.Drawing.Size(19, 26);
         this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
         // 
         // emptySpaceItem2
         // 
         this.emptySpaceItem2.AllowHotTrack = false;
         this.emptySpaceItem2.Location = new System.Drawing.Point(0, 312);
         this.emptySpaceItem2.Name = "emptySpaceItem2";
         this.emptySpaceItem2.Size = new System.Drawing.Size(733, 26);
         this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
         // 
         // layoutControlItem4
         // 
         this.layoutControlItem4.Control = this.txtPath;
         this.layoutControlItem4.Location = new System.Drawing.Point(0, 286);
         this.layoutControlItem4.Name = "layoutControlItem4";
         this.layoutControlItem4.Size = new System.Drawing.Size(906, 26);
         this.layoutControlItem4.Text = "Save Path:";
         this.layoutControlItem4.TextSize = new System.Drawing.Size(53, 13);
         // 
         // layoutControlItem5
         // 
         this.layoutControlItem5.Control = this.btnBrowse;
         this.layoutControlItem5.Location = new System.Drawing.Point(906, 286);
         this.layoutControlItem5.MaxSize = new System.Drawing.Size(27, 26);
         this.layoutControlItem5.MinSize = new System.Drawing.Size(27, 26);
         this.layoutControlItem5.Name = "layoutControlItem5";
         this.layoutControlItem5.Size = new System.Drawing.Size(27, 26);
         this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem5.TextVisible = false;
         // 
         // frmScriptCriteria
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(953, 358);
         this.Controls.Add(this.layoutControl1);
         this.Name = "frmScriptCriteria";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Script Criteria";
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
         this.layoutControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraLayout.LayoutControl layoutControl1;
      private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraGrid.GridControl gridControl1;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
      private DevExpress.XtraGrid.Columns.GridColumn colChecked;
      private DevExpress.XtraGrid.Columns.GridColumn colName;
      private DevExpress.XtraGrid.Columns.GridColumn colCriUniqueId;
      private DevExpress.XtraGrid.Columns.GridColumn colCheckResultType;
      private DevExpress.XtraGrid.Columns.GridColumn colDatabaseName;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
      private DevExpress.XtraGrid.Columns.GridColumn colId;
      private DevExpress.XtraEditors.SimpleButton btnBrowse;
      private DevExpress.XtraEditors.TextEdit txtPath;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
   }
}