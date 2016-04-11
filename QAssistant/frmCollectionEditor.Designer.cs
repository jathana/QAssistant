namespace QAssistant
{
   partial class frmCollectionEditor
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
         this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
         this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
         this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
         this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
         this.layoutControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
         this.SuspendLayout();
         // 
         // layoutControl1
         // 
         this.layoutControl1.Controls.Add(this.listBoxControl1);
         this.layoutControl1.Controls.Add(this.btnOK);
         this.layoutControl1.Controls.Add(this.btnCancel);
         this.layoutControl1.Controls.Add(this.propertyGridControl1);
         this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.layoutControl1.Location = new System.Drawing.Point(0, 0);
         this.layoutControl1.Name = "layoutControl1";
         this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(874, 122, 250, 577);
         this.layoutControl1.Root = this.layoutControlGroup1;
         this.layoutControl1.Size = new System.Drawing.Size(531, 504);
         this.layoutControl1.TabIndex = 0;
         this.layoutControl1.Text = "layoutControl1";
         // 
         // listBoxControl1
         // 
         this.listBoxControl1.Location = new System.Drawing.Point(12, 372);
         this.listBoxControl1.Name = "listBoxControl1";
         this.listBoxControl1.Size = new System.Drawing.Size(507, 94);
         this.listBoxControl1.StyleController = this.layoutControl1;
         this.listBoxControl1.TabIndex = 7;
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(329, 470);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(86, 22);
         this.btnOK.StyleController = this.layoutControl1;
         this.btnOK.TabIndex = 6;
         this.btnOK.Text = "OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(429, 470);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(90, 22);
         this.btnCancel.StyleController = this.layoutControl1;
         this.btnCancel.TabIndex = 5;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // propertyGridControl1
         // 
         this.propertyGridControl1.Location = new System.Drawing.Point(12, 12);
         this.propertyGridControl1.Name = "propertyGridControl1";
         this.propertyGridControl1.Size = new System.Drawing.Size(507, 356);
         this.propertyGridControl1.TabIndex = 4;
         this.propertyGridControl1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.propertyGridControl1_ValidatingEditor);
         this.propertyGridControl1.ValidateRecord += new DevExpress.XtraVerticalGrid.Events.ValidateRecordEventHandler(this.propertyGridControl1_ValidateRecord);
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
            this.layoutControlItem4});
         this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlGroup1.Name = "Root";
         this.layoutControlGroup1.Size = new System.Drawing.Size(531, 504);
         this.layoutControlGroup1.TextVisible = false;
         // 
         // layoutControlItem1
         // 
         this.layoutControlItem1.Control = this.propertyGridControl1;
         this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlItem1.Name = "layoutControlItem1";
         this.layoutControlItem1.Size = new System.Drawing.Size(511, 360);
         this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem1.TextVisible = false;
         // 
         // layoutControlItem2
         // 
         this.layoutControlItem2.Control = this.btnCancel;
         this.layoutControlItem2.Location = new System.Drawing.Point(417, 458);
         this.layoutControlItem2.MaxSize = new System.Drawing.Size(94, 26);
         this.layoutControlItem2.MinSize = new System.Drawing.Size(94, 26);
         this.layoutControlItem2.Name = "layoutControlItem2";
         this.layoutControlItem2.Size = new System.Drawing.Size(94, 26);
         this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem2.TextVisible = false;
         // 
         // layoutControlItem3
         // 
         this.layoutControlItem3.Control = this.btnOK;
         this.layoutControlItem3.Location = new System.Drawing.Point(317, 458);
         this.layoutControlItem3.MaxSize = new System.Drawing.Size(90, 26);
         this.layoutControlItem3.MinSize = new System.Drawing.Size(90, 26);
         this.layoutControlItem3.Name = "layoutControlItem3";
         this.layoutControlItem3.Size = new System.Drawing.Size(90, 26);
         this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem3.TextVisible = false;
         this.layoutControlItem3.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // emptySpaceItem1
         // 
         this.emptySpaceItem1.AllowHotTrack = false;
         this.emptySpaceItem1.Location = new System.Drawing.Point(0, 458);
         this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 26);
         this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 26);
         this.emptySpaceItem1.Name = "emptySpaceItem1";
         this.emptySpaceItem1.Size = new System.Drawing.Size(317, 26);
         this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
         // 
         // emptySpaceItem2
         // 
         this.emptySpaceItem2.AllowHotTrack = false;
         this.emptySpaceItem2.Location = new System.Drawing.Point(407, 458);
         this.emptySpaceItem2.MaxSize = new System.Drawing.Size(10, 26);
         this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 26);
         this.emptySpaceItem2.Name = "emptySpaceItem2";
         this.emptySpaceItem2.Size = new System.Drawing.Size(10, 26);
         this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
         // 
         // layoutControlItem4
         // 
         this.layoutControlItem4.Control = this.listBoxControl1;
         this.layoutControlItem4.Location = new System.Drawing.Point(0, 360);
         this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 98);
         this.layoutControlItem4.MinSize = new System.Drawing.Size(54, 98);
         this.layoutControlItem4.Name = "layoutControlItem4";
         this.layoutControlItem4.Size = new System.Drawing.Size(511, 98);
         this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem4.TextVisible = false;
         // 
         // frmObjectEditor
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(531, 504);
         this.Controls.Add(this.layoutControl1);
         this.Name = "frmObjectEditor";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Object Editor";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmObjectEditor_FormClosing);
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
         this.layoutControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraLayout.LayoutControl layoutControl1;
      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
      private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
      private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
   }
}