using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QAssistant.Lib.ChangeRequests;
using QAssistant.Lib;
using System.IO;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using System.Xml;

namespace QAssistant
{
   public partial class frmCREditor : DevExpress.XtraEditors.XtraForm
   {
      private QDocumentCR docCR;
      private string initialXml = "";

      private Dictionary<Type, EventHandler> addHandlers = new Dictionary<Type, EventHandler>();
      private Dictionary<Type, EventHandler> editHandlers = new Dictionary<Type, EventHandler>();
      private Dictionary<Type, EventHandler> modifiers = new Dictionary<Type, EventHandler>();

      private void CreateHandlers()
      {
         // add handlers
         addHandlers.Add(typeof(QGroupCR), bbAdd_Child_ItemClick<QGroupCR>);
         addHandlers.Add(typeof(QAlterTableCR), bbAdd_Child_ItemClick<QAlterTableCR>);
         addHandlers.Add(typeof(QAlterViewCR), bbAdd_Child_ItemClick<QAlterViewCR>);
         addHandlers.Add(typeof(QConfigureDatasourceCR), bbAdd_Child_ItemClick<QConfigureDatasourceCR>);
         addHandlers.Add(typeof(QConfigureDUICR), bbAdd_Child_ItemClick<QConfigureDUICR>);
         addHandlers.Add(typeof(QAddDUIFieldCR), bbAdd_Child_ItemClick<QAddDUIFieldCR>);
         addHandlers.Add(typeof(QConfigureDUIStackCR), bbAdd_Child_ItemClick<QConfigureDUIStackCR>);
         addHandlers.Add(typeof(QAddColumnToTableCR), bbAdd_Child_ItemClick<QAddColumnToTableCR>);
         addHandlers.Add(typeof(QAddColumnToViewCR), bbAdd_Child_ItemClick<QAddColumnToViewCR>);
         addHandlers.Add(typeof(QAddDatasourceFieldCR), bbAdd_Child_ItemClick<QAddDatasourceFieldCR>);
         addHandlers.Add(typeof(QAddCriterioCR), bbAdd_Child_ItemClick<QAddCriterioCR>);
         addHandlers.Add(typeof(QPoolField), bbAdd_Child_ItemClick<QPoolField>);
         addHandlers.Add(typeof(QPoolFields), bbAdd_Child_ItemClick<QPoolFields>);

         // edit handlers
         editHandlers.Add(typeof(QDocumentCR), trlCRTree_DoubleClick<QDocumentCR>);
         editHandlers.Add(typeof(QGroupCR), trlCRTree_DoubleClick<QGroupCR>);
         editHandlers.Add(typeof(QAlterTableCR), trlCRTree_DoubleClick<QAlterTableCR>);
         editHandlers.Add(typeof(QAlterViewCR), trlCRTree_DoubleClick<QAlterViewCR>);
         editHandlers.Add(typeof(QConfigureDatasourceCR), trlCRTree_DoubleClick<QConfigureDatasourceCR>);
         editHandlers.Add(typeof(QConfigureDUICR), trlCRTree_DoubleClick<QConfigureDUICR>);
         editHandlers.Add(typeof(QAddDUIFieldCR), trlCRTree_DoubleClick<QAddDUIFieldCR>);
         editHandlers.Add(typeof(QConfigureDUIStackCR), trlCRTree_DoubleClick<QConfigureDUIStackCR>);
         editHandlers.Add(typeof(QAddColumnToTableCR), trlCRTree_DoubleClick<QAddColumnToTableCR>);
         editHandlers.Add(typeof(QAddColumnToViewCR), trlCRTree_DoubleClick<QAddColumnToViewCR>);
         editHandlers.Add(typeof(QAddDatasourceFieldCR), trlCRTree_DoubleClick<QAddDatasourceFieldCR>);
         editHandlers.Add(typeof(QAddCriterioCR), trlCRTree_DoubleClick<QAddCriterioCR>);
         editHandlers.Add(typeof(QPoolField), trlCRTree_DoubleClick<QPoolField>);
         editHandlers.Add(typeof(QPoolFields), trlCRTree_DoubleClick<QPoolFields>);

         // modifiers
         modifiers.Add(typeof(QAlterTableCR), ShowModifier_ItemClick<QAlterTableCRModifier>);
         modifiers.Add(typeof(QAlterViewCR), ShowModifier_ItemClick<QAlterViewCRModifier>);
         modifiers.Add(typeof(QConfigureDatasourceCR), ShowModifier_ItemClick<QConfigureDatasourceCRModifier>);
         modifiers.Add(typeof(QConfigureDUICR), ShowModifier_ItemClick<QConfigureDUICRModifier>);
         modifiers.Add(typeof(QConfigureDUIStackCR), ShowModifier_ItemClick<QConfigureDUIStackCRModifier>);
      }

      public frmCREditor()
      {
         InitializeComponent();
      }

      private void btnCloseCR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         Close();
      }

      private void frmCREditor_Load(object sender, EventArgs e)
      {
         CreateHandlers();
         trlCRTree.StateImageList = imageCollection1;


      }
      

      private void btnAddChildCR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {

      }

      private void btnAddGroupCR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         
      }

      private void btnAddViewCR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
      }

      private void btnCheckCR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (docCR != null)
         {
            docCR.Check();
            grdCRActions.DataSource = null;
            if (trlCRTree.FocusedNode == null)
            {
               trlCRTree.SetFocusedNode(trlCRTree.Nodes[0]);
            }
            FocusedNodeChanged(trlCRTree.FocusedNode);
         }
      }

      private void btnAlterTableCR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
      }

      private void btnSaveCR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         SaveFileDialog d = new SaveFileDialog();
         d.Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";
         if (d.ShowDialog() == DialogResult.OK)
         {
            initialXml = docCR.Serialize();
            File.WriteAllText(d.FileName, initialXml, Encoding.UTF8);            
         }
         
      }

      #region tree list

      #endregion

      #region virtual tree list
      private void trlCRTree_VirtualTreeGetCellValue(object sender, DevExpress.XtraTreeList.VirtualTreeGetCellValueInfo e)
      {
         if (e.Column.Caption == "Description")
         {
            e.CellData = ((QChangeRequest)e.Node).Description;
         }
         else if (e.Column.Caption == "Id")
         {
            e.CellData = ((QChangeRequest)e.Node).Id;
         }
         else if (e.Column.Caption == "NeedsAttention")
         {
            //e.CellData = ((QChangeRequest)e.Node).Id;
         }




      }

      private void trlCRTree_VirtualTreeGetChildNodes(object sender, DevExpress.XtraTreeList.VirtualTreeGetChildNodesInfo e)
      {
         if (e.Node is QChangeRequest)
         {
            e.Children = ((QChangeRequest)e.Node).Children;
         }
         else if (e.Node is object)
         {
            e.Children = docCR.CRTree;
         }
         
      }

      private void trlCRTree_VirtualTreeSetCellValue(object sender, DevExpress.XtraTreeList.VirtualTreeSetCellValueInfo e)
      {
        
      }

      #endregion

      private void trlCRTree_Click(object sender, EventArgs e)
      {
         
      }

      private void trlCRTree_SelectionChanged(object sender, EventArgs e)
      {
        
      }


      private void FocusedNodeChanged(TreeListNode node)
      {
         if (trlCRTree.FocusedNode != null)
         {
            string id = trlCRTree.FocusedNode.GetValue("Id").ToString();
            if (!string.IsNullOrEmpty(id))
            {
               // get cr object
               QChangeRequest obj = (QChangeRequest)trlCRTree.GetDataRecordByNode(node);
               // refresh grid
               propertyGridControl1.Rows.Clear();
               propertyGridControl1.SelectedObject = null;
               propertyGridControl1.SelectedObject = obj;
               propertyGridControl1.Refresh();

               // refresh actions
               grdCRActions.DataSource = obj.Actions;
            }
         }
      }


      private void trlCRTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
      {
         FocusedNodeChanged(e.Node);
      }



      #region CRTreeList popup menu

      private void trlCRTree_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
      {
         if (e.Menu is TreeListNodeMenu)
         {
            trlCRTree.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
            object Obj = trlCRTree.GetDataRecordByNode(trlCRTree.FocusedNode);
            QChangeRequest objCR = (QChangeRequest)Obj;

            foreach(Type crType in objCR.CompatibleChildren)
            {
               e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add " + crType.Name, addHandlers[crType]));
            }
            if (modifiers.ContainsKey(objCR.GetType()))
            {
               e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem(string.Format( "Run {0} modifier.",objCR.GetType().Name), modifiers[objCR.GetType()]));
            }
            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete", trlCRTree_DeleteNode));
            if(objCR.GetType()==typeof(QAddCriterioCR))
            {
               e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem(string.Format("Script Criterio"), trlCRTree_ScriptCriterio));
            }
         }
      }

      private void trlCRTree_ScriptCriterio(object sender, EventArgs e)
      {
         object obj = trlCRTree.GetDataRecordByNode(trlCRTree.FocusedNode);
         SaveFileDialog d = new SaveFileDialog();
         d.Filter = "Sql files (*.sql)|*.sql|All files (*.*)|*.*";
         if (obj.GetType() == typeof(QAddCriterioCR))
         {
            QAddCriterioCR cr = (QAddCriterioCR)obj;
            if (cr.CanBeScripted())
            {
               d.FileName = cr.CriUniqueId;
               if (d.ShowDialog() == DialogResult.OK)
               {
                  string script = cr.GetScripted();
                  File.WriteAllText(d.FileName, script, Encoding.Unicode);
               }
            }
            else
            {
               XtraMessageBox.Show(string.Format("Criterio {0}.", cr.CheckResultType), "Info", MessageBoxButtons.OK);
            }

         }
      }

      private void trlCRTree_DeleteNode(object sender, EventArgs e)
      {
         object obj = trlCRTree.GetDataRecordByNode(trlCRTree.FocusedNode);
         if(XtraMessageBox.Show("Are you sure to delete node?", "Delete node", MessageBoxButtons.YesNo) == DialogResult.Yes)
         {
            QChangeRequest cr = (QChangeRequest)obj;
            QChangeRequest.Delete(cr);
            if(cr.GetType() == typeof(QDocumentCR))
            {
               trlCRTree.DataSource = null;
            }
         }
      }

      private void FocusNode(string id)
      {
         trlCRTree.ExpandAll();
         TreeListNode node = trlCRTree.FindNode(N => N.GetValue("Id").ToString() == id);
         trlCRTree.SetFocusedNode(node);
      }



      private void bbAdd_Child_ItemClick<TChild>(object sender, EventArgs e) 
         where TChild  : QChangeRequest, new() 
      {
         object Obj = trlCRTree.GetDataRecordByNode(trlCRTree.FocusedNode);
         QChangeRequest cr = (QChangeRequest)Obj;
         frmObjectEditor f = new frmObjectEditor();
         TChild newObj = new TChild();
         newObj.Parent = (QChangeRequest)Obj;
         if (f.ShowAddDialog(newObj) == DialogResult.OK)
         {
            TChild child = (TChild)f.NewObj;
            cr.AddChild<TChild>(child);
            FocusNode(((QChangeRequest)child).Id);
         }
      }

      private void ShowModifier_ItemClick<TModifier>(object sender, EventArgs e)
         where TModifier : QCRModifier, new()
      {
         object Obj = trlCRTree.GetDataRecordByNode(trlCRTree.FocusedNode);
         QChangeRequest cr = (QChangeRequest)Obj;
         frmModifier f = new frmModifier();
         TModifier modifier = new TModifier();
         modifier.ChangeRequest = cr;
         if (f.ShowDialog(modifier) == DialogResult.OK)
         {
            FocusNode(((QChangeRequest)Obj).Id);
            trlCRTree.ExpandAll();
         }
      }

      #endregion

      private void btnConfigureDatasourceCR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {

      }


      private void trlCRTree_DoubleClick<T>(object sender, EventArgs e) where T:QChangeRequest
      {
         object obj = trlCRTree.GetDataRecordByNode(trlCRTree.FocusedNode);
         if (obj.GetType().Equals(typeof(T)))
         {
            frmObjectEditor f = new frmObjectEditor();
            if (f.ShowEditDialog(obj) == DialogResult.OK)
            {
               // get parent child
               T cr = (T)obj;
               T crNew = (T)f.NewObj;
               cr.CopyState(f.NewObj);
               FocusNode(cr.Id);
               propertyGridControl1.Refresh();
            }
         }
      }


      private void trlCRTree_DoubleClick(object sender, EventArgs e)
      {
         object obj = trlCRTree.GetDataRecordByNode(trlCRTree.FocusedNode);
         editHandlers[obj.GetType()](sender, e);
      }

      private void CloseCR()
      {
         if (docCR != null)
         {
            docCR.Dispose();
            docCR = null;
         }
         grdCRActions.DataSource = null;

      }

      private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         frmObjectEditor f = new frmObjectEditor();
         QDocumentCR newDoc = new QDocumentCR();
         if (f.ShowAddDialog(newDoc) == DialogResult.OK)
         {
            CloseCR();
            docCR = newDoc;
            trlCRTree.DataSource = new object();
            FocusNode(docCR.Id);
         }
         
      }

      private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         OpenFileDialog d = new OpenFileDialog();
         if(d.ShowDialog() == DialogResult.OK)
         {
            CloseCR();
            docCR = new QDocumentCR();
            trlCRTree.DataSource = new object();
            
            XmlDocument doc = new XmlDocument();
            doc.Load(d.FileName);
            docCR.Deserialize(doc.DocumentElement);
            initialXml = docCR.Serialize();
            trlCRTree.ExpandAll();
         }
      }

      private void trlCRTree_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
      {

         object Obj = trlCRTree.GetDataRecordByNode(e.Node);
         if (Obj != null)
         {
            QChangeRequest cr = (QChangeRequest)Obj;
            switch(cr.CheckResultType)
            {
               case QCRCheckResultType.NotChecked:
                  e.NodeImageIndex = 0; break;
               case QCRCheckResultType.WellImplemented:
                  e.NodeImageIndex = 1; break;
               case QCRCheckResultType.NeedsAttention:
                  e.NodeImageIndex = 2; break;
            }
         }
      }

      private void btnScriptCriteria_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         frmScriptCriteria f = new frmScriptCriteria();
         if(f.ShowDialog(docCR) == DialogResult.OK)
         {
            foreach(QAddCriterioCR cr in f.SelectedCriteria)
            {
               if(cr.CanBeScripted())
               {
                  try
                  {
                     string script = cr.GetScripted();
                     File.WriteAllText(Path.Combine(f.SelectedPath, cr.CriUniqueId + ".sql"), script, Encoding.Unicode);
                  }
                  catch(Exception ex)
                  {
                     XtraMessageBox.Show(string.Format("Cannot script criterio {0} (reason:{1} - {2}).", cr.Name, cr.CheckResultType, ex.Message), "Script Criterio", MessageBoxButtons.OK);
                  }
               }

            }
         }
      }

      private void frmCREditor_FormClosing(object sender, FormClosingEventArgs e)
      {
         // check for changes
         if (docCR != null)
         {
            string currentXml = docCR.Serialize();
            if (!initialXml.Equals(currentXml))
            {
               DialogResult res = XtraMessageBox.Show("Save changes?", "Save", MessageBoxButtons.YesNoCancel);
               switch (res)
               {
                  case DialogResult.Cancel: e.Cancel = true; break;
                  case DialogResult.Yes: btnSaveCR_ItemClick(null, null); break;
               }
            }
         }
      }
   }
}