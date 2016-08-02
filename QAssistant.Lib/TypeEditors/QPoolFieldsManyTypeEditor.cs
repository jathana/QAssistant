using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using QAssistant.Lib.ChangeRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace QAssistant.Lib.TypeEditors
{
   public class QPoolFieldsManyTypeEditor : UITypeEditor
   {
      IWindowsFormsEditorService edSvc = null;
      private List<QPoolField> poolFields = null;

      public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
      {
         return UITypeEditorEditStyle.DropDown;
      }

      public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
      {

         if (context != null
                && context.Instance != null
                && provider != null)
         {

            edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (edSvc != null)
            {
               ucMultiSelectionGrid ucGrid = new ucMultiSelectionGrid();

               poolFields = (List<QPoolField>) value;
               GridControl grd = ucGrid.Grid;
               GridView gview = new GridView(grd);
               GridColumn colEnglishCaption = new GridColumn();
               GridColumn colFieldName = new GridColumn();
               GridColumn colTableName = new GridColumn();
               colEnglishCaption.FieldName = "EnglishCaption";
               colFieldName.FieldName = "FieldName";
               colTableName.FieldName = "TableName";

               colEnglishCaption.Visible = true;
               colFieldName.Visible = true;
               colTableName.Visible = true;
               gview.Columns.AddRange(new GridColumn[] { colEnglishCaption, colFieldName, colTableName });

               grd.MainView = gview;
               //grd.Click += Dbs_Click;
               gview.OptionsCustomization.AllowGroup = false;
               gview.OptionsView.ShowGroupPanel = false;
               gview.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
               gview.OptionsSelection.MultiSelect = true;
               gview.OptionsBehavior.Editable = false;
               ucGrid.OKPressed += UcGrid_OKPressed;

               try
               {
                  object inst = context.Instance;
                  grd.DataSource = GetDataSource(context);
                  edSvc.DropDownControl(ucGrid);
                  value = poolFields;
               }
               catch (Exception ex)
               {

               }
            }
         }

         return value;
      }

      private void UcGrid_OKPressed(object sender, EventArgs e)
      {
         try
         {
            GridControl grd = (DevExpress.XtraGrid.GridControl)((ucMultiSelectionGrid)sender).Grid;
            GridView gview = (GridView)grd.MainView;
            int[] rows = gview.GetSelectedRows();
            foreach (int rowHandle in rows)
            {
               QPoolField poolField = (QPoolField)gview.GetRow(rowHandle); 
               poolFields.Add(poolField);  
            }
         }
         catch (Exception ex)
         {

         }
         edSvc.CloseDropDown();
      }

      private List<QPoolField> GetDataSource(ITypeDescriptorContext context)
      {
         // get document
         QDocumentCR doc = null;
         if (context.Instance is QCRModifier)
         {
            doc = (QDocumentCR)(((QCRModifier)context.Instance).ChangeRequest).GetRoot();
         }
         else if(context.Instance is QChangeRequest)
         {
            doc = (QDocumentCR)((QChangeRequest)context.Instance).GetRoot();
         }
         List<QPoolField> fields = doc.GetDescendants<QPoolField>();
         return fields;
      }

   }
}
