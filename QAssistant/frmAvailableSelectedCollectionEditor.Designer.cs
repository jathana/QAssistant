namespace QAssistant
{
   partial class frmAvailableSelectedCollectionEditor
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAvailableSelectedCollectionEditor));
         this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
         this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
         this.lstAvailable = new DevExpress.XtraEditors.ListBoxControl();
         this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
         this.lstSelected = new DevExpress.XtraEditors.ListBoxControl();
         this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
         this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.btnDeselect = new DevExpress.XtraEditors.SimpleButton();
         this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
         this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
         this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
         this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
         this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
         this.btnDeselectAll = new DevExpress.XtraEditors.SimpleButton();
         this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
         this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
         this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
         this.layoutControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lstAvailable)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lstSelected)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
         this.SuspendLayout();
         // 
         // layoutControl1
         // 
         this.layoutControl1.Controls.Add(this.btnOK);
         this.layoutControl1.Controls.Add(this.btnCancel);
         this.layoutControl1.Controls.Add(this.btnDeselectAll);
         this.layoutControl1.Controls.Add(this.btnSelectAll);
         this.layoutControl1.Controls.Add(this.btnSelect);
         this.layoutControl1.Controls.Add(this.btnDeselect);
         this.layoutControl1.Controls.Add(this.lstSelected);
         this.layoutControl1.Controls.Add(this.lstAvailable);
         this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.layoutControl1.Location = new System.Drawing.Point(0, 0);
         this.layoutControl1.Name = "layoutControl1";
         this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1068, 288, 418, 486);
         this.layoutControl1.Root = this.layoutControlGroup1;
         this.layoutControl1.Size = new System.Drawing.Size(783, 507);
         this.layoutControl1.TabIndex = 0;
         this.layoutControl1.Text = "layoutControl1";
         // 
         // layoutControlGroup1
         // 
         this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
         this.layoutControlGroup1.GroupBordersVisible = false;
         this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem5,
            this.emptySpaceItem6});
         this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlGroup1.Name = "Root";
         this.layoutControlGroup1.Size = new System.Drawing.Size(783, 507);
         this.layoutControlGroup1.TextVisible = false;
         // 
         // lstAvailable
         // 
         this.lstAvailable.Location = new System.Drawing.Point(12, 12);
         this.lstAvailable.Name = "lstAvailable";
         this.lstAvailable.Size = new System.Drawing.Size(336, 452);
         this.lstAvailable.StyleController = this.layoutControl1;
         this.lstAvailable.TabIndex = 4;
         // 
         // layoutControlItem1
         // 
         this.layoutControlItem1.Control = this.lstAvailable;
         this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlItem1.Name = "layoutControlItem1";
         this.layoutControlItem1.Size = new System.Drawing.Size(340, 456);
         this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem1.TextVisible = false;
         // 
         // lstSelected
         // 
         this.lstSelected.Location = new System.Drawing.Point(448, 12);
         this.lstSelected.Name = "lstSelected";
         this.lstSelected.Size = new System.Drawing.Size(323, 452);
         this.lstSelected.StyleController = this.layoutControl1;
         this.lstSelected.TabIndex = 5;
         // 
         // layoutControlItem2
         // 
         this.layoutControlItem2.Control = this.lstSelected;
         this.layoutControlItem2.Location = new System.Drawing.Point(436, 0);
         this.layoutControlItem2.Name = "layoutControlItem2";
         this.layoutControlItem2.Size = new System.Drawing.Size(327, 456);
         this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem2.TextVisible = false;
         // 
         // emptySpaceItem1
         // 
         this.emptySpaceItem1.AllowHotTrack = false;
         this.emptySpaceItem1.Location = new System.Drawing.Point(350, 309);
         this.emptySpaceItem1.Name = "emptySpaceItem1";
         this.emptySpaceItem1.Size = new System.Drawing.Size(76, 147);
         this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
         // 
         // emptySpaceItem2
         // 
         this.emptySpaceItem2.AllowHotTrack = false;
         this.emptySpaceItem2.Location = new System.Drawing.Point(350, 0);
         this.emptySpaceItem2.Name = "emptySpaceItem2";
         this.emptySpaceItem2.Size = new System.Drawing.Size(76, 141);
         this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
         // 
         // btnDeselect
         // 
         this.btnDeselect.Image = ((System.Drawing.Image)(resources.GetObject("btnDeselect.Image")));
         this.btnDeselect.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
         this.btnDeselect.Location = new System.Drawing.Point(362, 237);
         this.btnDeselect.Name = "btnDeselect";
         this.btnDeselect.Size = new System.Drawing.Size(72, 38);
         this.btnDeselect.StyleController = this.layoutControl1;
         this.btnDeselect.TabIndex = 6;
         this.btnDeselect.Text = "simpleButton1";
         // 
         // layoutControlItem3
         // 
         this.layoutControlItem3.Control = this.btnDeselect;
         this.layoutControlItem3.Location = new System.Drawing.Point(350, 225);
         this.layoutControlItem3.MaxSize = new System.Drawing.Size(76, 42);
         this.layoutControlItem3.MinSize = new System.Drawing.Size(76, 42);
         this.layoutControlItem3.Name = "layoutControlItem3";
         this.layoutControlItem3.Size = new System.Drawing.Size(76, 42);
         this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem3.TextVisible = false;
         // 
         // btnSelect
         // 
         this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
         this.btnSelect.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
         this.btnSelect.Location = new System.Drawing.Point(362, 195);
         this.btnSelect.Name = "btnSelect";
         this.btnSelect.Size = new System.Drawing.Size(72, 38);
         this.btnSelect.StyleController = this.layoutControl1;
         this.btnSelect.TabIndex = 7;
         this.btnSelect.Text = "simpleButton2";
         // 
         // layoutControlItem4
         // 
         this.layoutControlItem4.Control = this.btnSelect;
         this.layoutControlItem4.Location = new System.Drawing.Point(350, 183);
         this.layoutControlItem4.MaxSize = new System.Drawing.Size(76, 42);
         this.layoutControlItem4.MinSize = new System.Drawing.Size(76, 42);
         this.layoutControlItem4.Name = "layoutControlItem4";
         this.layoutControlItem4.Size = new System.Drawing.Size(76, 42);
         this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem4.TextVisible = false;
         // 
         // btnSelectAll
         // 
         this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
         this.btnSelectAll.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
         this.btnSelectAll.Location = new System.Drawing.Point(362, 153);
         this.btnSelectAll.Name = "btnSelectAll";
         this.btnSelectAll.Size = new System.Drawing.Size(72, 38);
         this.btnSelectAll.StyleController = this.layoutControl1;
         this.btnSelectAll.TabIndex = 8;
         this.btnSelectAll.Tag = "simpleButton3";
         // 
         // layoutControlItem5
         // 
         this.layoutControlItem5.Control = this.btnSelectAll;
         this.layoutControlItem5.Location = new System.Drawing.Point(350, 141);
         this.layoutControlItem5.MaxSize = new System.Drawing.Size(76, 42);
         this.layoutControlItem5.MinSize = new System.Drawing.Size(76, 42);
         this.layoutControlItem5.Name = "layoutControlItem5";
         this.layoutControlItem5.Size = new System.Drawing.Size(76, 42);
         this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem5.TextVisible = false;
         // 
         // btnDeselectAll
         // 
         this.btnDeselectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnDeselectAll.Image")));
         this.btnDeselectAll.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
         this.btnDeselectAll.Location = new System.Drawing.Point(362, 279);
         this.btnDeselectAll.Name = "btnDeselectAll";
         this.btnDeselectAll.Size = new System.Drawing.Size(72, 38);
         this.btnDeselectAll.StyleController = this.layoutControl1;
         this.btnDeselectAll.TabIndex = 9;
         this.btnDeselectAll.Text = "simpleButton4";
         // 
         // layoutControlItem6
         // 
         this.layoutControlItem6.Control = this.btnDeselectAll;
         this.layoutControlItem6.Location = new System.Drawing.Point(350, 267);
         this.layoutControlItem6.MaxSize = new System.Drawing.Size(76, 42);
         this.layoutControlItem6.MinSize = new System.Drawing.Size(76, 42);
         this.layoutControlItem6.Name = "layoutControlItem6";
         this.layoutControlItem6.Size = new System.Drawing.Size(76, 42);
         this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem6.TextVisible = false;
         // 
         // emptySpaceItem3
         // 
         this.emptySpaceItem3.AllowHotTrack = false;
         this.emptySpaceItem3.Location = new System.Drawing.Point(340, 0);
         this.emptySpaceItem3.MaxSize = new System.Drawing.Size(10, 456);
         this.emptySpaceItem3.MinSize = new System.Drawing.Size(10, 456);
         this.emptySpaceItem3.Name = "emptySpaceItem3";
         this.emptySpaceItem3.Size = new System.Drawing.Size(10, 456);
         this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
         // 
         // emptySpaceItem4
         // 
         this.emptySpaceItem4.AllowHotTrack = false;
         this.emptySpaceItem4.Location = new System.Drawing.Point(426, 0);
         this.emptySpaceItem4.MaxSize = new System.Drawing.Size(10, 456);
         this.emptySpaceItem4.MinSize = new System.Drawing.Size(10, 456);
         this.emptySpaceItem4.Name = "emptySpaceItem4";
         this.emptySpaceItem4.Size = new System.Drawing.Size(10, 456);
         this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(689, 468);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(82, 25);
         this.btnCancel.StyleController = this.layoutControl1;
         this.btnCancel.TabIndex = 10;
         this.btnCancel.Text = "Cancel";
         // 
         // layoutControlItem7
         // 
         this.layoutControlItem7.Control = this.btnCancel;
         this.layoutControlItem7.Location = new System.Drawing.Point(677, 456);
         this.layoutControlItem7.MaxSize = new System.Drawing.Size(86, 29);
         this.layoutControlItem7.MinSize = new System.Drawing.Size(86, 29);
         this.layoutControlItem7.Name = "layoutControlItem7";
         this.layoutControlItem7.Size = new System.Drawing.Size(86, 31);
         this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem7.TextVisible = false;
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(597, 468);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(78, 25);
         this.btnOK.StyleController = this.layoutControl1;
         this.btnOK.TabIndex = 11;
         this.btnOK.Text = "OK";
         // 
         // layoutControlItem8
         // 
         this.layoutControlItem8.Control = this.btnOK;
         this.layoutControlItem8.Location = new System.Drawing.Point(585, 456);
         this.layoutControlItem8.MaxSize = new System.Drawing.Size(82, 29);
         this.layoutControlItem8.MinSize = new System.Drawing.Size(82, 29);
         this.layoutControlItem8.Name = "layoutControlItem8";
         this.layoutControlItem8.Size = new System.Drawing.Size(82, 31);
         this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem8.TextVisible = false;
         // 
         // emptySpaceItem5
         // 
         this.emptySpaceItem5.AllowHotTrack = false;
         this.emptySpaceItem5.Location = new System.Drawing.Point(667, 456);
         this.emptySpaceItem5.MaxSize = new System.Drawing.Size(10, 29);
         this.emptySpaceItem5.MinSize = new System.Drawing.Size(10, 29);
         this.emptySpaceItem5.Name = "emptySpaceItem5";
         this.emptySpaceItem5.Size = new System.Drawing.Size(10, 31);
         this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
         // 
         // emptySpaceItem6
         // 
         this.emptySpaceItem6.AllowHotTrack = false;
         this.emptySpaceItem6.Location = new System.Drawing.Point(0, 456);
         this.emptySpaceItem6.MaxSize = new System.Drawing.Size(585, 29);
         this.emptySpaceItem6.MinSize = new System.Drawing.Size(585, 29);
         this.emptySpaceItem6.Name = "emptySpaceItem6";
         this.emptySpaceItem6.Size = new System.Drawing.Size(585, 31);
         this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
         // 
         // frmAvailableSelectedCollectionEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(783, 507);
         this.Controls.Add(this.layoutControl1);
         this.Name = "frmAvailableSelectedCollectionEditor";
         this.Text = "frmAvailableSelectedCollectionEditor";
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
         this.layoutControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lstAvailable)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lstSelected)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraLayout.LayoutControl layoutControl1;
      private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
      private DevExpress.XtraEditors.SimpleButton btnDeselectAll;
      private DevExpress.XtraEditors.SimpleButton btnSelectAll;
      private DevExpress.XtraEditors.SimpleButton btnSelect;
      private DevExpress.XtraEditors.SimpleButton btnDeselect;
      private DevExpress.XtraEditors.ListBoxControl lstSelected;
      private DevExpress.XtraEditors.ListBoxControl lstAvailable;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
   }
}