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
   public class QPoolFieldsEnglishCaptionTypeEditor : UITypeEditor
   {
      IWindowsFormsEditorService edSvc = null;
      private string englishCaption = "";

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
               englishCaption = (string)value;
               GridControl grd = new GridControl();
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

               //gview.OptionsBehavior.ReadOnly = true;
               grd.MainView = gview;
               grd.Click += Dbs_Click;
               gview.OptionsCustomization.AllowGroup = false;
               gview.OptionsView.ShowGroupPanel = false;
               //gview.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
               gview.OptionsBehavior.Editable = false;
               //ListBoxControl dbs = new ListBoxControl();               
               //dbs.Click += Dbs_Click;

               try
               {
                  object inst = context.Instance;
                  grd.DataSource = GetDataSource(context);
                  edSvc.DropDownControl(grd);
                  value = englishCaption;
               }
               catch (Exception ex)
               {

               }

            }
         }

         return value;
      }

      private List<QPoolField> GetDataSource(ITypeDescriptorContext context)
      {
         QDocumentCR doc = (QDocumentCR)((QChangeRequest)context.Instance).GetRoot();
         List<QPoolField> fields = doc.GetDescendants<QPoolField>();
         
         return fields;
      }

      private void Dbs_Click(object sender, EventArgs e)
      {
         try
         {
            GridControl grd = (DevExpress.XtraGrid.GridControl)sender;
            GridView gview = (GridView)grd.MainView;
            englishCaption = gview.GetRowCellValue(gview.FocusedRowHandle, "EnglishCaption").ToString();
         }
         catch (Exception ex)
         {

         }
         edSvc.CloseDropDown();
      }

      
      private object InitDropDown_Criterio(ITypeDescriptorContext context, ListBoxControl dbs)
      {
         object retval = null;
         try
         {
            QDocumentCR doc = (QDocumentCR)((QChangeRequest)context.Instance).GetRoot();
            List<QPoolField> fields =  doc.GetDescendants<QPoolField>();
            dbs.DisplayMember = "FieldName";
            dbs.DataSource = fields;
            edSvc.DropDownControl(dbs);
            retval = ((QPoolField)dbs.SelectedItem).FieldName;
         }
         catch (Exception ex)
         {

         }
         return retval;
      }

   }
}
