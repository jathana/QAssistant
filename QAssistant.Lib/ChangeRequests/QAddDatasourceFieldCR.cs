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
   [Description("Datasource Field CR")]
   public class QAddDatasourceFieldCR : QChangeRequest
   {

      #region fields
      private string fieldName = "";
      private string fieldCaption = "";
      #endregion

      #region properties

      [Category(QConsts.CategoryInherited)]
      public QDatabaseName DatabaseName
      {
         get
         {
            QDatabaseName retval = new QDatabaseName();
            if (Parent != null)
            {
               retval = ((QConfigureDatasourceCR)Parent).DatabaseName;
            }
            return retval;
         }
      }


      [Category(QConsts.CategoryInherited)]
      public string DatasourceName
      {
         get
         {
            string retval = "";
            if (Parent != null)
            {
               retval = ((QConfigureDatasourceCR)Parent).Name;
            }
            return retval;
         }
      }

      [Category(QConsts.CategoryInherited)]
      public override string Description
      {
         get
         {
            return string.Format("Add field \"{0}\" to datasource \"{1}\".", FieldName, DatasourceName);
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
               retval = ((QConfigureDatasourceCR)Parent).InstallationCode;
            }
            return retval;
         }
      }
      #endregion



      public QAddDatasourceFieldCR()
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

         if (FieldName.HasTrailingSpaces())
            errors.Add(nameof(FieldName), "Trailing spaces are not allowed.");
         if (FieldCaption.HasTrailingSpaces())
            errors.Add(nameof(FieldCaption), "Trailing spaces are not allowed.");


         return errors.Count == 0;
      }

      public override void CopyState(object source)
      {
         if (source is QAddDatasourceFieldCR)
         {
            QAddDatasourceFieldCR cr = (QAddDatasourceFieldCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }

      public override object Clone()
      {
         QAddDatasourceFieldCR retval = new QAddDatasourceFieldCR()
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

      private SqlCommand GetFieldCommand()
      {
         string sql = @"SELECT DSF.DSF_FIELDNAME, DSF.DSF_ACTIVE
                        FROM TLK_DATASOURCES_FIELDS DSF
                        INNER JOIN TLK_DATASOURCES DSRC 
                        ON DSF.DSRC_CODE = DSRC.DSRC_CODE
                        AND DSRC.DSRC_NAME = @dsrc_name
                        AND DSF.DSF_FIELDNAME = @field_name";
         SqlCommand command = new SqlCommand(sql);

         command.Parameters.Add("@dsrc_name", SqlDbType.NVarChar, 50).Value = DatasourceName;
         command.Parameters.Add("@field_name", SqlDbType.NVarChar, 50).Value = FieldName;

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
                        AND DSRC.DSRC_NAME = @dsrc_name
                        INNER JOIN TLK_DATASOURCES_FIELDS_UI DSFU
                        ON DSF.DSF_CODE=DSFU.DSF_CODE 
                        AND (DSFU.INST_CODE=@inst_code OR DSFU.INST_CODE IS NULL)
                        AND DSF.DSF_FIELDNAME=@field_name
                        AND DSFU.DSFU_UI_CAPTION = @field_caption";
         SqlCommand command = new SqlCommand(sql);

         command.Parameters.Add("@dsrc_name", SqlDbType.NVarChar, 50).Value = DatasourceName;
         command.Parameters.Add("@field_name", SqlDbType.NVarChar, 50).Value = FieldName;
         command.Parameters.Add("@inst_code", SqlDbType.Int).Value = InstallationCode;
         command.Parameters.Add("@field_caption", SqlDbType.NVarChar, 250).Value = FieldCaption;

         return command;
      }

      private SqlCommand GetLCYFieldCommand()
      {
         string sql = @"SELECT DSRC.DSRC_NAME, DSRC.DSRC_CODE, 
                        DSFU.DSF_CODE, DSFU.INST_CODE, DSFU.DSFU_UI_VISIBLE, DSFU.DSFU_UI_IN_QBE, DSFU.DSFU_UI_CAPTION, 
                        DSF.DSF_FIELDNAME, DSF.DSF_ACTIVE, DSF.DSF_INTERNAL 
                        FROM TLK_DATASOURCES_FIELDS DSF
                        INNER JOIN TLK_DATASOURCES DSRC
                        ON DSRC.DSRC_CODE=DSF.DSRC_CODE
                        AND DSRC.DSRC_NAME = @dsrc_name
                        INNER JOIN TLK_DATASOURCES_FIELDS_UI DSFU
                        ON DSF.DSF_CODE=DSFU.DSF_CODE 
                        AND (DSFU.INST_CODE=@inst_code OR DSFU.INST_CODE IS NULL)
                        AND DSF.DSF_FIELDNAME=@field_name";
         SqlCommand command = new SqlCommand(sql);

         command.Parameters.Add("@dsrc_name", SqlDbType.NVarChar, 50).Value = DatasourceName;
         command.Parameters.Add("@field_name", SqlDbType.NVarChar, 50).Value = FieldName;
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
            w.WriteAttributeString("installationcode", InstallationCode.ToString());
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
         bool result = base.Check();

         result = CheckRec() && result;
         NotifyPropertyChanged(nameof(CheckResultType));
         return result;

      }

      private bool CheckRec()
      {
         bool retval = false;
         if(fieldName.EndsWith("_LCY"))
         {
            retval = CheckRecLCYField();
         }
         else
         {
            retval = CheckRecNoLCYField();
         }
         return retval;
      }

      private bool CheckRecNoLCYField()
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
                  Description = string.Format("Add field \"{0}\" to datasource \"{1}\".", FieldName, DatasourceName),
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
                     Description = string.Format("The datasource \"{0}\" contains the field \"{1}\" for the default installation only.Override for \"{2}\"", DatasourceName, FieldName, InstallationCode),
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
            if (Actions.Count == 0)
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.WellImplemented,
                  ActionType = QCRActionType.NoActionNeeded,
                  Description = string.Format("Add field \"{0}\" to Datasource \"{1}\".", FieldName, DatasourceName),
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
               ActionType = QCRActionType.CheckDatasourceField,
               Description = string.Format(ex.Message),
               DatabaseName = this.DatabaseName
            };
            Actions.Add(check);

            retval = false;
         }
         return retval;
      }


      private bool CheckRecLCYField()
      {
         bool retval = true;
         try
         {
            QDatabase database = QInstance.Environments.GetDatabase(DatabaseName);
            // first check if the field ui record exists 
            DataTable tbRec = database.ExecuteCommand(GetLCYFieldCommand());
            if (tbRec.Rows.Count == 0)
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.NeedsAction,
                  ActionType = QCRActionType.CheckDatasourceField,
                  Description = string.Format("Add field \"{0}\" to datasource \"{1}\".", FieldName, DatasourceName),
                  DatabaseName = this.DatabaseName
               };
               Actions.Add(check);
               retval = false;
            }
            else if (tbRec.Rows.Count > 0)
            {
               // check if fields exists
               DataRow[] row = tbRec.Select(string.Format("INST_CODE = {0}", InstallationCode));
               if (row.Length == 0)
               {
                  row = tbRec.Select("INST_CODE IS NULL");
               }
               if (row.Length == 0)
               {
                  // field does not exist in default or in described installation
                  QCRAction check = new QCRAction()
                  {
                     State = QCRActionState.NeedsAction,
                     ActionType = QCRActionType.CheckDatasourceField,
                     Description = string.Format("Add field \"{0}\" to datasource \"{1}\".", FieldName, DatasourceName),
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
               }
            }
            // everything ok
            if (Actions.Count == 0)
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.WellImplemented,
                  ActionType = QCRActionType.NoActionNeeded,
                  Description = string.Format("Add field \"{0}\" to Datasource \"{1}\".", FieldName, DatasourceName),
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
               ActionType = QCRActionType.CheckDatasourceField,
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
