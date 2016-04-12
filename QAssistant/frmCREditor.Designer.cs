namespace QAssistant
{
   partial class frmCREditor
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCREditor));
         DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
         DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
         DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
         this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
         this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
         this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
         this.pnlCRTree = new DevExpress.XtraBars.Docking.DockPanel();
         this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
         this.trlCRTree = new DevExpress.XtraTreeList.TreeList();
         this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
         this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
         this.pnlActions = new DevExpress.XtraBars.Docking.DockPanel();
         this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
         this.grdCRActions = new DevExpress.XtraGrid.GridControl();
         this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.btnSaveCR = new DevExpress.XtraBars.BarButtonItem();
         this.btnCheckCR = new DevExpress.XtraBars.BarButtonItem();
         this.btnCloseCR = new DevExpress.XtraBars.BarButtonItem();
         this.btnAddChildCR = new DevExpress.XtraBars.BarButtonItem();
         this.mnuAddChildCR = new DevExpress.XtraBars.PopupMenu(this.components);
         this.btnAddGroupCR = new DevExpress.XtraBars.BarButtonItem();
         this.btnAddViewCR = new DevExpress.XtraBars.BarButtonItem();
         this.btnAlterTableCR = new DevExpress.XtraBars.BarButtonItem();
         this.btnConfigureDatasourceCR = new DevExpress.XtraBars.BarButtonItem();
         this.btnNew = new DevExpress.XtraBars.BarButtonItem();
         this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
         this.btnScriptCriteria = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
         this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
         this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
         this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
         this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
         this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
         this.pnlCRTree.SuspendLayout();
         this.dockPanel1_Container.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.trlCRTree)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
         this.pnlActions.SuspendLayout();
         this.dockPanel3_Container.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdCRActions)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.mnuAddChildCR)).BeginInit();
         this.dockPanel1.SuspendLayout();
         this.controlContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
         this.SuspendLayout();
         // 
         // documentGroup1
         // 
         this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document1});
         // 
         // document1
         // 
         this.document1.Caption = "dockPanel1";
         this.document1.ControlName = "dockPanel1";
         this.document1.FloatLocation = new System.Drawing.Point(0, 0);
         this.document1.FloatSize = new System.Drawing.Size(200, 200);
         this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
         this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
         this.document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
         // 
         // dockManager1
         // 
         this.dockManager1.Form = this;
         this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.pnlCRTree,
            this.pnlActions,
            this.dockPanel1});
         this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
         // 
         // pnlCRTree
         // 
         this.pnlCRTree.Controls.Add(this.dockPanel1_Container);
         this.pnlCRTree.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
         this.pnlCRTree.ID = new System.Guid("452af844-d3a7-4536-ba66-c50a2e1b1714");
         this.pnlCRTree.Location = new System.Drawing.Point(0, 141);
         this.pnlCRTree.Name = "pnlCRTree";
         this.pnlCRTree.OriginalSize = new System.Drawing.Size(457, 200);
         this.pnlCRTree.Size = new System.Drawing.Size(457, 408);
         this.pnlCRTree.Text = "CR Tree";
         // 
         // dockPanel1_Container
         // 
         this.dockPanel1_Container.Controls.Add(this.trlCRTree);
         this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
         this.dockPanel1_Container.Name = "dockPanel1_Container";
         this.dockPanel1_Container.Size = new System.Drawing.Size(449, 381);
         this.dockPanel1_Container.TabIndex = 0;
         // 
         // trlCRTree
         // 
         this.trlCRTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn5});
         this.trlCRTree.Dock = System.Windows.Forms.DockStyle.Fill;
         this.trlCRTree.Location = new System.Drawing.Point(0, 0);
         this.trlCRTree.Name = "trlCRTree";
         this.trlCRTree.OptionsBehavior.Editable = false;
         this.trlCRTree.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
         this.trlCRTree.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
         this.trlCRTree.OptionsView.EnableAppearanceEvenRow = true;
         this.trlCRTree.OptionsView.EnableAppearanceOddRow = true;
         this.trlCRTree.OptionsView.ShowColumns = false;
         this.trlCRTree.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
         this.trlCRTree.Size = new System.Drawing.Size(449, 381);
         this.trlCRTree.TabIndex = 0;
         this.trlCRTree.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.trlCRTree_GetStateImage);
         this.trlCRTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlCRTree_FocusedNodeChanged);
         this.trlCRTree.SelectionChanged += new System.EventHandler(this.trlCRTree_SelectionChanged);
         this.trlCRTree.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.trlCRTree_PopupMenuShowing);
         this.trlCRTree.VirtualTreeGetChildNodes += new DevExpress.XtraTreeList.VirtualTreeGetChildNodesEventHandler(this.trlCRTree_VirtualTreeGetChildNodes);
         this.trlCRTree.VirtualTreeGetCellValue += new DevExpress.XtraTreeList.VirtualTreeGetCellValueEventHandler(this.trlCRTree_VirtualTreeGetCellValue);
         this.trlCRTree.VirtualTreeSetCellValue += new DevExpress.XtraTreeList.VirtualTreeSetCellValueEventHandler(this.trlCRTree_VirtualTreeSetCellValue);
         this.trlCRTree.Click += new System.EventHandler(this.trlCRTree_Click);
         this.trlCRTree.DoubleClick += new System.EventHandler(this.trlCRTree_DoubleClick);
         // 
         // treeListColumn1
         // 
         this.treeListColumn1.Caption = "ChangeRequestType";
         this.treeListColumn1.FieldName = "ChangeRequestType";
         this.treeListColumn1.Name = "treeListColumn1";
         // 
         // treeListColumn2
         // 
         this.treeListColumn2.Caption = "Description";
         this.treeListColumn2.FieldName = "Description";
         this.treeListColumn2.Name = "treeListColumn2";
         this.treeListColumn2.Visible = true;
         this.treeListColumn2.VisibleIndex = 0;
         this.treeListColumn2.Width = 104;
         // 
         // treeListColumn5
         // 
         this.treeListColumn5.Caption = "Id";
         this.treeListColumn5.FieldName = "Id";
         this.treeListColumn5.Name = "treeListColumn5";
         // 
         // repositoryItemImageEdit1
         // 
         this.repositoryItemImageEdit1.AutoHeight = false;
         this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.repositoryItemImageEdit1.Images = this.imageCollection1;
         this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
         // 
         // imageCollection1
         // 
         this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
         this.imageCollection1.InsertGalleryImage("question_16x16.png", "office2013/support/question_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/support/question_16x16.png"), 0);
         this.imageCollection1.Images.SetKeyName(0, "question_16x16.png");
         this.imageCollection1.InsertGalleryImage("apply_16x16.png", "office2013/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/apply_16x16.png"), 1);
         this.imageCollection1.Images.SetKeyName(1, "apply_16x16.png");
         this.imageCollection1.InsertGalleryImage("bugreport_16x16.png", "images/programming/bugreport_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/bugreport_16x16.png"), 2);
         this.imageCollection1.Images.SetKeyName(2, "bugreport_16x16.png");
         this.imageCollection1.InsertGalleryImage("status_16x16.png", "images/tasks/status_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/tasks/status_16x16.png"), 3);
         this.imageCollection1.Images.SetKeyName(3, "status_16x16.png");
         this.imageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 4);
         this.imageCollection1.Images.SetKeyName(4, "apply_16x16.png");
         this.imageCollection1.InsertGalleryImage("about_16x16.png", "devav/actions/about_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/actions/about_16x16.png"), 5);
         this.imageCollection1.Images.SetKeyName(5, "about_16x16.png");
         // 
         // pnlActions
         // 
         this.pnlActions.Controls.Add(this.dockPanel3_Container);
         this.pnlActions.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
         this.pnlActions.FloatVertical = true;
         this.pnlActions.ID = new System.Guid("d36918b8-4619-46ce-9a81-a22676107d5a");
         this.pnlActions.Location = new System.Drawing.Point(457, 386);
         this.pnlActions.Name = "pnlActions";
         this.pnlActions.OriginalSize = new System.Drawing.Size(200, 163);
         this.pnlActions.Size = new System.Drawing.Size(421, 163);
         this.pnlActions.Text = "CR Actions";
         // 
         // dockPanel3_Container
         // 
         this.dockPanel3_Container.Controls.Add(this.grdCRActions);
         this.dockPanel3_Container.Location = new System.Drawing.Point(4, 23);
         this.dockPanel3_Container.Name = "dockPanel3_Container";
         this.dockPanel3_Container.Size = new System.Drawing.Size(413, 136);
         this.dockPanel3_Container.TabIndex = 0;
         // 
         // grdCRActions
         // 
         this.grdCRActions.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdCRActions.Location = new System.Drawing.Point(0, 0);
         this.grdCRActions.MainView = this.gridView2;
         this.grdCRActions.MenuManager = this.ribbonControl1;
         this.grdCRActions.Name = "grdCRActions";
         this.grdCRActions.Size = new System.Drawing.Size(413, 136);
         this.grdCRActions.TabIndex = 0;
         this.grdCRActions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
         // 
         // gridView2
         // 
         this.gridView2.GridControl = this.grdCRActions;
         this.gridView2.Name = "gridView2";
         // 
         // ribbonControl1
         // 
         this.ribbonControl1.ExpandCollapseItem.Id = 0;
         this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSaveCR,
            this.btnCheckCR,
            this.btnCloseCR,
            this.btnAddChildCR,
            this.btnAddGroupCR,
            this.btnAddViewCR,
            this.btnAlterTableCR,
            this.btnConfigureDatasourceCR,
            this.btnNew,
            this.btnOpen,
            this.btnScriptCriteria});
         this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl1.MaxItemId = 13;
         this.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
         this.ribbonControl1.Name = "ribbonControl1";
         this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
         this.ribbonControl1.Size = new System.Drawing.Size(878, 141);
         // 
         // btnSaveCR
         // 
         this.btnSaveCR.Caption = "Save";
         this.btnSaveCR.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveCR.Glyph")));
         this.btnSaveCR.Id = 2;
         this.btnSaveCR.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveCR.LargeGlyph")));
         this.btnSaveCR.Name = "btnSaveCR";
         toolTipTitleItem1.Text = "Save Change Request";
         superToolTip1.Items.Add(toolTipTitleItem1);
         this.btnSaveCR.SuperTip = superToolTip1;
         this.btnSaveCR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveCR_ItemClick);
         // 
         // btnCheckCR
         // 
         this.btnCheckCR.Caption = "Check";
         this.btnCheckCR.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCheckCR.Glyph")));
         this.btnCheckCR.Id = 3;
         this.btnCheckCR.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCheckCR.LargeGlyph")));
         this.btnCheckCR.Name = "btnCheckCR";
         this.btnCheckCR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCheckCR_ItemClick);
         // 
         // btnCloseCR
         // 
         this.btnCloseCR.Caption = "Close";
         this.btnCloseCR.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCloseCR.Glyph")));
         this.btnCloseCR.Id = 4;
         this.btnCloseCR.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCloseCR.LargeGlyph")));
         this.btnCloseCR.Name = "btnCloseCR";
         this.btnCloseCR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCloseCR_ItemClick);
         // 
         // btnAddChildCR
         // 
         this.btnAddChildCR.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
         this.btnAddChildCR.Caption = "Add Child";
         this.btnAddChildCR.DropDownControl = this.mnuAddChildCR;
         this.btnAddChildCR.Id = 5;
         this.btnAddChildCR.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddChildCR.LargeGlyph")));
         this.btnAddChildCR.Name = "btnAddChildCR";
         this.btnAddChildCR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddChildCR_ItemClick);
         // 
         // mnuAddChildCR
         // 
         this.mnuAddChildCR.ItemLinks.Add(this.btnAddGroupCR);
         this.mnuAddChildCR.ItemLinks.Add(this.btnAddViewCR);
         this.mnuAddChildCR.ItemLinks.Add(this.btnAlterTableCR);
         this.mnuAddChildCR.ItemLinks.Add(this.btnConfigureDatasourceCR);
         this.mnuAddChildCR.Name = "mnuAddChildCR";
         this.mnuAddChildCR.Ribbon = this.ribbonControl1;
         // 
         // btnAddGroupCR
         // 
         this.btnAddGroupCR.Caption = "GroupCR";
         this.btnAddGroupCR.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddGroupCR.Glyph")));
         this.btnAddGroupCR.Id = 6;
         this.btnAddGroupCR.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddGroupCR.LargeGlyph")));
         this.btnAddGroupCR.Name = "btnAddGroupCR";
         this.btnAddGroupCR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddGroupCR_ItemClick);
         // 
         // btnAddViewCR
         // 
         this.btnAddViewCR.Caption = "AlterViewCR";
         this.btnAddViewCR.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddViewCR.Glyph")));
         this.btnAddViewCR.Id = 7;
         this.btnAddViewCR.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddViewCR.LargeGlyph")));
         this.btnAddViewCR.Name = "btnAddViewCR";
         this.btnAddViewCR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddViewCR_ItemClick);
         // 
         // btnAlterTableCR
         // 
         this.btnAlterTableCR.Caption = "AlterTableCR";
         this.btnAlterTableCR.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAlterTableCR.Glyph")));
         this.btnAlterTableCR.Id = 8;
         this.btnAlterTableCR.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAlterTableCR.LargeGlyph")));
         this.btnAlterTableCR.Name = "btnAlterTableCR";
         this.btnAlterTableCR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAlterTableCR_ItemClick);
         // 
         // btnConfigureDatasourceCR
         // 
         this.btnConfigureDatasourceCR.Caption = "ConfigureDatasourceCR";
         this.btnConfigureDatasourceCR.Id = 9;
         this.btnConfigureDatasourceCR.Name = "btnConfigureDatasourceCR";
         this.btnConfigureDatasourceCR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfigureDatasourceCR_ItemClick);
         // 
         // btnNew
         // 
         this.btnNew.Caption = "New";
         this.btnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNew.Glyph")));
         this.btnNew.Id = 10;
         this.btnNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNew.LargeGlyph")));
         this.btnNew.Name = "btnNew";
         this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
         // 
         // btnOpen
         // 
         this.btnOpen.Caption = "Open";
         this.btnOpen.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpen.Glyph")));
         this.btnOpen.Id = 11;
         this.btnOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpen.LargeGlyph")));
         this.btnOpen.Name = "btnOpen";
         this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
         // 
         // btnScriptCriteria
         // 
         this.btnScriptCriteria.Caption = "Script Criteria";
         this.btnScriptCriteria.Glyph = ((System.Drawing.Image)(resources.GetObject("btnScriptCriteria.Glyph")));
         this.btnScriptCriteria.Id = 12;
         this.btnScriptCriteria.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnScriptCriteria.LargeGlyph")));
         this.btnScriptCriteria.Name = "btnScriptCriteria";
         this.btnScriptCriteria.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnScriptCriteria_ItemClick);
         // 
         // ribbonPage1
         // 
         this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
         this.ribbonPage1.Name = "ribbonPage1";
         this.ribbonPage1.Text = "Change Request";
         // 
         // ribbonPageGroup1
         // 
         this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
         this.ribbonPageGroup1.ItemLinks.Add(this.btnOpen);
         this.ribbonPageGroup1.ItemLinks.Add(this.btnSaveCR);
         this.ribbonPageGroup1.ItemLinks.Add(this.btnCloseCR);
         this.ribbonPageGroup1.Name = "ribbonPageGroup1";
         this.ribbonPageGroup1.Text = "File";
         // 
         // ribbonPageGroup2
         // 
         this.ribbonPageGroup2.ItemLinks.Add(this.btnCheckCR);
         this.ribbonPageGroup2.ItemLinks.Add(this.btnScriptCriteria);
         this.ribbonPageGroup2.Name = "ribbonPageGroup2";
         this.ribbonPageGroup2.Text = "Build";
         // 
         // dockPanel1
         // 
         this.dockPanel1.Controls.Add(this.controlContainer1);
         this.dockPanel1.DockedAsTabbedDocument = true;
         this.dockPanel1.ID = new System.Guid("e00ffe32-ae8a-43f2-b1d3-1d0d270c3bde");
         this.dockPanel1.Name = "dockPanel1";
         this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
         this.dockPanel1.Text = "dockPanel1";
         // 
         // controlContainer1
         // 
         this.controlContainer1.Controls.Add(this.propertyGridControl1);
         this.controlContainer1.Location = new System.Drawing.Point(0, 0);
         this.controlContainer1.Name = "controlContainer1";
         this.controlContainer1.Size = new System.Drawing.Size(415, 217);
         this.controlContainer1.TabIndex = 0;
         // 
         // propertyGridControl1
         // 
         this.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.propertyGridControl1.Location = new System.Drawing.Point(0, 0);
         this.propertyGridControl1.Name = "propertyGridControl1";
         this.propertyGridControl1.OptionsBehavior.Editable = false;
         this.propertyGridControl1.Size = new System.Drawing.Size(415, 217);
         this.propertyGridControl1.TabIndex = 0;
         // 
         // documentManager1
         // 
         this.documentManager1.ContainerControl = this;
         this.documentManager1.View = this.tabbedView1;
         this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
         // 
         // tabbedView1
         // 
         this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
         this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1});
         dockingContainer1.Element = this.documentGroup1;
         this.tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer1});
         // 
         // treeListColumn3
         // 
         this.treeListColumn3.Caption = "Description";
         this.treeListColumn3.FieldName = "Description";
         this.treeListColumn3.Name = "treeListColumn3";
         this.treeListColumn3.Visible = true;
         this.treeListColumn3.VisibleIndex = 1;
         // 
         // treeListColumn4
         // 
         this.treeListColumn4.Caption = "Description";
         this.treeListColumn4.FieldName = "Description";
         this.treeListColumn4.Name = "treeListColumn4";
         this.treeListColumn4.Visible = true;
         this.treeListColumn4.VisibleIndex = 1;
         // 
         // frmCREditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(878, 549);
         this.Controls.Add(this.pnlActions);
         this.Controls.Add(this.pnlCRTree);
         this.Controls.Add(this.ribbonControl1);
         this.Name = "frmCREditor";
         this.Text = "Change Request Editor";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCREditor_FormClosing);
         this.Load += new System.EventHandler(this.frmCREditor_Load);
         ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
         this.pnlCRTree.ResumeLayout(false);
         this.dockPanel1_Container.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.trlCRTree)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
         this.pnlActions.ResumeLayout(false);
         this.dockPanel3_Container.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdCRActions)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.mnuAddChildCR)).EndInit();
         this.dockPanel1.ResumeLayout(false);
         this.controlContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.Docking.DockManager dockManager1;
      private DevExpress.XtraBars.Docking.DockPanel pnlActions;
      private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
      private DevExpress.XtraBars.Docking.DockPanel pnlCRTree;
      private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
      private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
      private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
      private DevExpress.XtraBars.BarButtonItem btnSaveCR;
      private DevExpress.XtraBars.BarButtonItem btnCheckCR;
      private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
      private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
      private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
      private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
      private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
      private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
      private DevExpress.XtraBars.BarButtonItem btnCloseCR;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
      private DevExpress.XtraBars.BarButtonItem btnAddChildCR;
      private DevExpress.XtraBars.BarButtonItem btnAddGroupCR;
      private DevExpress.XtraBars.BarButtonItem btnAddViewCR;
      private DevExpress.XtraBars.BarButtonItem btnAlterTableCR;
      private DevExpress.XtraBars.PopupMenu mnuAddChildCR;
      private DevExpress.XtraGrid.GridControl grdCRActions;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
      private DevExpress.XtraTreeList.TreeList trlCRTree;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
      private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
      private DevExpress.XtraBars.BarButtonItem btnConfigureDatasourceCR;
      private DevExpress.XtraBars.BarButtonItem btnNew;
      private DevExpress.XtraBars.BarButtonItem btnOpen;
      private DevExpress.Utils.ImageCollection imageCollection1;
      private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
      private DevExpress.XtraBars.BarButtonItem btnScriptCriteria;
   }
}