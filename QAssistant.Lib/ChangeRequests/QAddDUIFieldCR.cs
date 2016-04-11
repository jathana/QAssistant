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
      private string fieldCaption = "";
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
            return string.Format("Configure datasource field \"{0}\"", FieldName);
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

      [Category(QConsts.CategoryRequired)]
      public string FieldCaption
      {
         get
         {
            return fieldCaption;
         }
         set
         {
            if (value != this.fieldCaption)
            {
               this.fieldCaption = value;
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
         FieldCaption = "";
      }

      #region methods

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(fieldName))
            errors.Add(nameof(FieldName), "Field name is mandatory.");
         if (string.IsNullOrEmpty(fieldCaption))
            errors.Add(nameof(FieldCaption), "Field caption is mandatory.");
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
            FieldCaption = this.fieldCaption,
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

      private SqlCommand GetInstUIFieldsCountCommand()
      {

         string sql = @"SELECT COUNT(*)
                        FROM TLK_DATASOURCES_FIELDS DSF
                        INNER JOIN TLK_DATASOURCES DSRC
                        ON DSRC.DSRC_CODE=DSF.DSRC_CODE
                        AND DSRC.DSRC_NAME = @dsrc_name
                        INNER JOIN TLK_DATASOURCES_FIELDS_UI DSFU
                        ON DSF.DSF_CODE=DSFU.DSF_CODE 
                        AND (DSFU.INST_CODE=@inst_code)";
         SqlCommand command = new SqlCommand(sql);
         command.Parameters.Add("@dsrc_name", SqlDbType.NVarChar, 50).Value = DatasourceName;
         command.Parameters.Add("@inst_code", SqlDbType.Int).Value = InstallationCode;

         return command;
      }

      private SqlCommand GetInstUiFieldCommand()
      {
         string sql = @"SELECT DSRC.DSRC_NAME, DSRC.DSRC_CODE, 
                        DSFU.DSF_CODE, DSFU.INST_CODE, DSFU.DSFU_UI_VISIBLE, DSFU.DSFU_UI_IN_QBE, DSFU.DSFU_UI_CAPTION, 
                        DSF.DSF_FIELDNAME, DSF.DSF_ACTIVE, DSF.DSF_INTERNAL 
                        FROM TLK_DATASOURCES_FIELDS DSF
                        INNER JOIN TLK_DATASOURCES DSRC
                        ON DSRC.DSRC_CODE=DSF.DSRC_CODE
                        AND DSRC.DSRC_NAME LIKE @dsrc_name
                        INNER JOIN TLK_DATASOURCES_FIELDS_UI DSFU
                        ON DSF.DSF_CODE=DSFU.DSF_CODE 
                        AND (DSFU.INST_CODE=@inst_code OR DSFU.INST_CODE IS NULL)
                        AND DSF.DSF_FIELDNAME=@field_name
                        AND DSFU.DSFU_UI_CAPTION=@field_caption";
         SqlCommand command = new SqlCommand(sql);

         command.Parameters.Add("@dsrc_name", SqlDbType.NVarChar, 50).Value = DatasourceName;
         command.Parameters.Add("@field_name", SqlDbType.NVarChar, 50).Value = FieldName;
         command.Parameters.Add("@field_caption", SqlDbType.NVarChar, 250).Value = FieldCaption;
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
            w.WriteAttributeString("fieldcaption", FieldCaption);

            w.WriteEndElement();
            w.Flush();
         }
         return sb.ToString();

      }

      public override void Deserialize(XmlNode Node)
      {
         base.Deserialize(Node);
         FieldName = Node.ReadString("fieldname", "");
         FieldCaption = Node.ReadString("fieldcaption");

      }

      #endregion

      #region checks
      public override bool Check()
      {
         bool result = true;
         Actions.Clear();

         result = CheckRec() && result;
         NotifyPropertyChanged(nameof(CheckResultType));
         return result;

      }

      private bool CheckRec()
      {
         bool retval = true;
         try
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
                  Description = string.Format("The datasource \"{0}\" does not contain the field \"{1}\".", DatasourceName, FieldName),
                  DatabaseName = this.DatabaseName
               };
               Actions.Add(check);
               retval = false;
            }
            else if (tbRec.Rows.Count > 0)
            {
               // check if there are  fields in the specific installation.
               int count = (int)database.ExecuteScalar(GetInstUIFieldsCountCommand());
               // check if fields exists
               DataRow[] row = tbRec.Select(string.Format("INST_CODE = {0}", InstallationCode));
               if (row.Length == 0 && count > 0)
               {
                  QCRAction check = new QCRAction()
                  {
                     State = QCRActionState.NeedsAction,
                     ActionType = QCRActionType.CheckDatasourceField,
                     Description = string.Format("The datasource \"{0}\" contain the field \"{1}\" for the default installation only.Override for \"{2}\"", DatasourceName, FieldName, InstallationCode),
                     DatabaseName = this.DatabaseName
                  };
                  Actions.Add(check);
                  retval = false;
               }
               if (row.Length == 1) // record found  
               {
                  // check active flag
                  if (!((bool)row[0]["DSF_ACTIVE"]))
                  {
                     QCRAction check = new QCRAction()
                     {
                        State = QCRActionState.NeedsAction,
                        ActionType = QCRActionType.CheckDatasourceField,
                        Description = string.Format("The field \"{0}\" in datasource \"{1}\" for the installation \"{2}\" is not active.", FieldName, DatasourceName, InstallationCode),
                        DatabaseName = this.DatabaseName
                     };
                     Actions.Add(check);
                     retval = false;
                  }
                  // check visible in ui flag
                  if (!((bool)row[0]["DSFU_UI_VISIBLE"]))
                  {
                     QCRAction check = new QCRAction()
                     {
                        State = QCRActionState.NeedsAction,
                        ActionType = QCRActionType.CheckDatasourceField,
                        Description = string.Format("The field \"{0}\" in datasource \"{1}\" for the installation \"{2}\" is not visible in ui.", FieldName, DatasourceName, InstallationCode),
                        DatabaseName = this.DatabaseName
                     };
                     Actions.Add(check);
                     retval = false;
                  }
                  // check caption
                  if (((string)row[0]["DSFU_UI_CAPTION"]) != FieldCaption)
                  {
                     QCRAction check = new QCRAction()
                     {
                        State = QCRActionState.NeedsAction,
                        ActionType = QCRActionType.CheckDatasourceField,
                        Description = string.Format("The field \"{0}\" in datasource \"{1}\" for the installation \"{2}\" has different caption than the specification.", FieldName, DatasourceName, InstallationCode),
                        DatabaseName = this.DatabaseName
                     };
                     Actions.Add(check);
                     retval = false;
                  }
               }
            }
            // everything ok
            if(Actions.Count==0)
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.WellImplemented,
                  ActionType = QCRActionType.CheckDUIField,
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
