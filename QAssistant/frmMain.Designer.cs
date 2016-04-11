namespace QAssistant
{
   partial class frmMain
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
         DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
         DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
         this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.btnNewFields = new DevExpress.XtraBars.BarButtonItem();
         this.btNewFields = new DevExpress.XtraBars.BarButtonItem();
         this.btnOpenCREditor = new DevExpress.XtraBars.BarButtonItem();
         this.btnCompare = new DevExpress.XtraBars.BarButtonItem();
         this.rpgChangeRequests = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.grpFileCR = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
         this.SuspendLayout();
         // 
         // ribbon
         // 
         this.ribbon.ExpandCollapseItem.Id = 0;
         this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnNewFields,
            this.btNewFields,
            this.btnOpenCREditor,
            this.btnCompare});
         this.ribbon.Location = new System.Drawing.Point(0, 0);
         this.ribbon.MaxItemId = 9;
         this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.OnlyWhenMaximized;
         this.ribbon.Name = "ribbon";
         this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpgChangeRequests,
            this.ribbonPage1});
         this.ribbon.Size = new System.Drawing.Size(875, 143);
         this.ribbon.StatusBar = this.ribbonStatusBar;
         // 
         // btnNewFields
         // 
         this.btnNewFields.Caption = "New Fields";
         this.btnNewFields.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNewFields.Glyph")));
         this.btnNewFields.Id = 1;
         this.btnNewFields.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNewFields.LargeGlyph")));
         this.btnNewFields.Name = "btnNewFields";
         this.btnNewFields.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewFields_ItemClick);
         // 
         // btNewFields
         // 
         this.btNewFields.Caption = "Add Fields";
         this.btNewFields.Glyph = ((System.Drawing.Image)(resources.GetObject("btNewFields.Glyph")));
         this.btNewFields.Id = 2;
         this.btNewFields.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btNewFields.LargeGlyph")));
         this.btNewFields.Name = "btNewFields";
         this.btNewFields.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btNewFields_ItemClick);
         // 
         // btnOpenCREditor
         // 
         this.btnOpenCREditor.Caption = "CR Editor";
         this.btnOpenCREditor.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpenCREditor.Glyph")));
         this.btnOpenCREditor.Id = 3;
         this.btnOpenCREditor.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpenCREditor.LargeGlyph")));
         this.btnOpenCREditor.Name = "btnOpenCREditor";
         toolTipTitleItem1.Text = "Create new change request";
         superToolTip1.Items.Add(toolTipTitleItem1);
         this.btnOpenCREditor.SuperTip = superToolTip1;
         this.btnOpenCREditor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenCREditor_ItemClick);
         // 
         // btnCompare
         // 
         this.btnCompare.Caption = "Compare";
         this.btnCompare.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCompare.Glyph")));
         this.btnCompare.Id = 8;
         this.btnCompare.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCompare.LargeGlyph")));
         this.btnCompare.Name = "btnCompare";
         this.btnCompare.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCompare_ItemClick);
         // 
         // rpgChangeRequests
         // 
         this.rpgChangeRequests.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.grpFileCR});
         this.rpgChangeRequests.Name = "rpgChangeRequests";
         this.rpgChangeRequests.Text = "Change Request";
         // 
         // grpFileCR
         // 
         this.grpFileCR.ItemLinks.Add(this.btnOpenCREditor);
         this.grpFileCR.Name = "grpFileCR";
         this.grpFileCR.Text = "File";
         // 
         // ribbonPage1
         // 
         this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
         this.ribbonPage1.Name = "ribbonPage1";
         this.ribbonPage1.Text = "Test";
         // 
         // ribbonPageGroup1
         // 
         this.ribbonPageGroup1.ItemLinks.Add(this.btnNewFields);
         this.ribbonPageGroup1.ItemLinks.Add(this.btNewFields);
         this.ribbonPageGroup1.ItemLinks.Add(this.btnCompare);
         this.ribbonPageGroup1.Name = "ribbonPageGroup1";
         this.ribbonPageGroup1.Text = "Test";
         // 
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 502);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbon;
         this.ribbonStatusBar.Size = new System.Drawing.Size(875, 31);
         // 
         // frmMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(875, 533);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbon);
         this.IsMdiContainer = true;
         this.Name = "frmMain";
         this.Ribbon = this.ribbon;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "QAssistant";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RibbonForm1_FormClosing);
         this.Load += new System.EventHandler(this.RibbonForm1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
      private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
      private DevExpress.XtraBars.BarButtonItem btnNewFields;
      private DevExpress.XtraBars.BarButtonItem btNewFields;
      private DevExpress.XtraBars.BarButtonItem btnOpenCREditor;
      private DevExpress.XtraBars.Ribbon.RibbonPage rpgChangeRequests;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup grpFileCR;
      private DevExpress.XtraBars.BarButtonItem btnCompare;
   }
}