using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib.ChangeRequests
{
   public class QAddDUIFieldCR : QChangeRequest
   {

      #region fields
      private string fieldName = "";
      #endregion

      #region properties

      [Category(QConsts.CategoryInherited)]
      public string DatasourceName
      {
         get
         {
            string retval = "";
            if (Parent != null)
            {
               retval = ((QConfigureDUICR)Parent).DatasourceName;
            }
            return retval;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string VersionValue
      {
         get
         {
            string retval = "";
            if (Parent != null)
            {
               retval = ((QConfigureDUICR)Parent).VersionValue;
            }
            return retval;
         }
      }


      [Category(QConsts.CategoryInherited)]
      public string DynamicUIName
      {
         get
         {
            string retval = "";
            if (Parent != null)
            {
               retval = ((QConfigureDUICR)Parent).Name;
            }
            return retval;
         }
      }

      [Category(QConsts.CategoryInherited)]
      public QDatabaseName DatabaseName
      {
         get
         {
            QDatabaseName retval = new QDatabaseName();
            if (Parent != null)
            {
               retval = ((QConfigureDUICR)Parent).DatabaseName;
            }
            return retval;
         }
      }

      [Category(QConsts.CategoryInherited)]
      public override string Description
      {
         get
         {
            return string.Format("Add field \"{0}\" to Dynamic UI \"{1}\".", FieldName, DynamicUIName);
         }
      }

      [Category(QConsts.CategoryRequired)]
      public string FieldName
      {
         get
         {
            return fieldName;
         }
         set
         {
            if (value != this.fieldName)
            {
               this.fieldName = value;
               NotifyPropertyChanged();
            }
         }
      }


      [Category(QConsts.CategoryInherited)]
      public int InstallationCode
      {
         get
         {
            int retval = 0;
            if (Parent != null)
            {
               retval = ((QConfigureDUICR)Parent).InstallationCode;
            }
            return retval;
         }
      }
      #endregion

      public QAddDUIFieldCR()
      {
         FieldName = "";
      }

      #region methods

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(fieldName))
            errors.Add(nameof(FieldName), "Field name is mandatory.");
         if (FieldName.HasTrailingSpaces())
            errors.Add(nameof(FieldName), "Trailing spaces are not allowed.");

         return errors.Count == 0;
      }

      public override void CopyState(object source)
      {
         if (source is QAddDUIFieldCR)
         {
            QAddDUIFieldCR cr = (QAddDUIFieldCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }
      public override object Clone()
      {
         QAddDUIFieldCR retval = new QAddDUIFieldCR()
         {
            FieldName = this.fieldName,
            Parent = this.Parent
         };
         foreach (QChangeRequest child in this.Children)
         {
            retval.Children.Add((QChangeRequest)child.Clone());
         }
         return retval;

      }

      public override T AddNewChild<T>()
      {
         T retval = null;
         if (typeof(T) == typeof(QAddDatasourceFieldCR))
         {
            retval = new T();
            retval.Parent = this;
            Children.Add(retval);
         }
         return retval;
      }

      protected override void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
      {
         base.NotifyPropertyChanged(propertyName);
         if (propertyName == nameof(FieldName))
         {
            NotifyPropertyChanged(nameof(Description));
         }
      }

      private SqlCommand GetInstUiFieldCommand()
      {
         string sql = @"SELECT DUIP.INST_CODE, DUIV.DUIV_VERSION_VALUE, DUI.DUI_NAME, DUI.DUI_CODE
                        FROM TLK_DYNAMICUI_FIELDS DUIF
                        INNER JOIN TLK_DYNAMICUI_VERSIONS DUIV
                        ON DUIF.DUIV_CODE=DUIV.DUIV_CODE
                        INNER JOIN TLK_DATASOURCES_FIELDS DSF
                        ON DSF.DSF_CODE=DUIF.DSF_CODE AND DSF.DSF_FIELDNAME=@field_name
                        INNER JOIN TLK_DYNAMICUI_DEPL_PROP DUIP
                        ON DUIP.DUIP_CODE = DUIV.DUIP_CODE AND DUIP.INST_CODE=@inst_code
                        INNER JOIN TLK_DYNAMICUI DUI
                        ON DUI.DUI_CODE=DUIP.DUI_CODE AND DUI.DUI_NAME=@dui_name
                        INNER JOIN TLK_UI_ROLES UIR
                        ON UIR.UIR_INTERNAL_DESC=DUIV.DUIV_VERSION_VALUE AND UIR.UIR_DESCRIPTION=@version_value";
         if(VersionValue.Equals("#BASE_VERSION#"))
         {
               sql = @"SELECT DUIP.INST_CODE, DUIV.DUIV_VERSION_VALUE, DUI.DUI_NAME, DUI.DUI_CODE, DSRC.DSRC_NAME, DSRC.DSRC_CODE
                     FROM TLK_DYNAMICUI DUI
                     INNER JOIN TLK_DYNAMICUI_DEPL_PROP DUIP
                     ON DUIP.DUI_CODE = DUI.DUI_CODE AND DUIP.INST_CODE=@inst_code
                     INNER JOIN TLK_DYNAMICUI_VERSIONS DUIV
                     ON DUIV.DUIP_CODE=DUIP.DUIP_CODE AND DUIV.DUIV_VERSION_VALUE='#BASE_VERSION#'
                     INNER JOIN TLK_DATASOURCES DSRC
                     ON DUI.DSRC_CODE = DSRC.DSRC_CODE
                     WHERE DUI.DUI_NAME=@dui_name";
         }
         SqlCommand command = new SqlCommand(sql);

         command.Parameters.Add("@version_value", SqlDbType.NVarChar, 50).Value = VersionValue;
         command.Parameters.Add("@field_name", SqlDbType.NVarChar, 50).Value = FieldName;
         command.Parameters.Add("@dui_name", SqlDbType.NVarChar, 50).Value = DynamicUIName;
         command.Parameters.Add("@inst_code", SqlDbType.Int).Value = InstallationCode;

         return command;
      }

      
      #endregion

      #region Serialization
      public override string Serialize()
      {

         var sb = new StringBuilder();
         XmlWriterSettings settings = new XmlWriterSettings() { OmitXmlDeclaration = true };
         using (XmlWriter w = XmlWriter.Create(sb, settings))
         {
            w.WriteStartElement(GetType().Name);
            base.Serialize(w);
            w.WriteAttributeString("fieldname", FieldName);

            w.WriteEndElement();
            w.Flush();
         }
         return sb.ToString();

      }

      public override void Deserialize(XmlNode Node)
      {
         base.Deserialize(Node);
         FieldName = Node.ReadString("fieldname", "");

      }

      #endregion

      #region checks
      public override bool Check()
      {
         bool result = base.Check();

         result = CheckRec() && result;
         NotifyPropertyChanged(nameof(CheckResultType));
         return result;
      }

      private bool CheckRec()
      {
         bool retval = true;
         
            try
            {
               // do not check LCY fields
               if (!fieldName.EndsWith("_LCY"))
               {
                  QDatabase database = QInstance.Environments.GetDatabase(DatabaseName);
                  // first check if the field ui record exists 
                  DataTable tbRec = database.ExecuteCommand(GetInstUiFieldCommand());
                  if (tbRec.Rows.Count == 0)
                  {
                     QCRAction check = new QCRAction()
                     {
                        State = QCRActionState.NeedsAction,
                        ActionType = QCRActionType.CheckDatasourceField,
                        Description = string.Format("Add field \"{0}\" to Dynamic UI \"{1}\".", FieldName, DynamicUIName),
                        DatabaseName = this.DatabaseName
                     };
                     Actions.Add(check);
                     retval = false;
                  }
               }
               // everything ok
               if (Actions.Count == 0)
               {
                  QCRAction check = new QCRAction()
                  {
                     State = QCRActionState.WellImplemented,
                     ActionType = QCRActionType.NoActionNeeded,
                     Description = string.Format("Add field \"{0}\" to Dynamic UI \"{1}\".", FieldName, DynamicUIName),
                     DatabaseName = this.DatabaseName
                  };
                  Actions.Add(check);
                  retval = true;
               }


            }
            catch (Exception ex)
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.NeedsAction,
                  ActionType = QCRActionType.CheckDUIField,
                  Description = string.Format(ex.Message),
                  DatabaseName = this.DatabaseName
               };
               Actions.Add(check);
               retval = false;
            }
         
         return retval;
      }

      

   }

      #endregion
   }
