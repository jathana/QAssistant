using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib.ChangeRequests
{
   public class QConfigureDUICR : QChangeRequest
   {
      #region fields
      private int code;
      private int datasourceCode;
      private string datasourceName;
      private string name;
      private QDatabaseName databaseName = new QDatabaseName();
      private string relatedDBObject = ""; // view/table/stored proc
      private int installationCode = 0;
      private string versionValue = "#BASE_VERSION#";
      #endregion

      #region properties

      [Category(QConsts.CategoryRequired)]
      public int InstallationCode
      {
         get
         {
            return installationCode;
         }
         set
         {
            if (value != this.installationCode)
            {
               this.installationCode = value;
               NotifyPropertyChanged();
            }
         }
      }

      [Category(QConsts.CategoryRequired)]
      public string RelatedDBObject
      {
         get
         {
            return relatedDBObject;
         }
         set
         {
            if (value != this.relatedDBObject)
            {
               this.relatedDBObject = value;
               NotifyPropertyChanged();
            }
         }
      }

      [Category(QConsts.CategoryRequired)]
      [Editor(typeof(QDatabaseNameTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
      public QDatabaseName DatabaseName
      {
         get
         {
            return databaseName;
         }
         set
         {
            if (value != this.databaseName)
            {
               this.databaseName = value;
               NotifyPropertyChanged();
            }
         }
      }

      [Category(QConsts.CategoryInherited)]
      public int Code
      {
         get
         {
            return code;
         }
      }

      [Category(QConsts.CategoryRequired)]
      public string Name
      {
         get
         {
            return name;
         }

         set
         {
            if (value != this.name)
            {
               this.name = value;
               NotifyPropertyChanged();
            }
         }
      }

      [Category(QConsts.CategoryRequired)]
      public string DatasourceName
      {
         get
         {
            return datasourceName;
         }
         set
         {
            if (value != this.datasourceName)
            {
               this.datasourceName = value;
               NotifyPropertyChanged();
            }
         }
      }

      [Category(QConsts.CategoryInherited)]
      public override string Description
      {
         get
         {
            return string.Format("Configure Dynamic UI \"{0}\"", Name);
         }
      }

      [Category(QConsts.CategoryRequired)]
      public string VersionValue
      {
         get
         {
            return versionValue;
         }

         set
         {
            if (value != this.versionValue)
            {
               this.versionValue = value;
               NotifyPropertyChanged();
            }
         }
      }

      #endregion

      public QConfigureDUICR()
      {
         name = "";
         code = 0;
         datasourceCode = 0;
      
         SetCompatibleChildren();
         needsChildren = true;
      }
      #region methods

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(datasourceName))
            errors.Add(nameof(DatasourceName), "DatasourceName is mandatory.");
         if (string.IsNullOrEmpty(Name))
            errors.Add(nameof(Name), "Name is mandatory.");
         if (string.IsNullOrEmpty(relatedDBObject))
            errors.Add(nameof(RelatedDBObject), "RelatedDBObject is mandatory.");
         if (databaseName.IsInvalid())
            errors.Add(nameof(DatabaseName), "Check DatabaseName.");
         if (string.IsNullOrEmpty(VersionValue))
            errors.Add(nameof(VersionValue), "VersionValue is mandatory.");

         return errors.Count == 0;
      }

      void SetCompatibleChildren()
      {
         compatibleChildren.Add(typeof(QAddDUIFieldCR));
      }

      public override void CopyState(object source)
      {
         if (source is QConfigureDUICR)
         {
            QConfigureDUICR cr = (QConfigureDUICR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }
      public override object Clone()
      {
         QConfigureDUICR retval = new QConfigureDUICR()
         {
            Name = this.name,
            RelatedDBObject = this.relatedDBObject,
            DatabaseName = new QDatabaseName(this.databaseName.FullName),
            InstallationCode = this.installationCode,
            DatasourceName = this.datasourceName,
            VersionValue = this.versionValue,
            Parent = this.Parent
         };

         foreach (QChangeRequest child in this.Children)
         {
            retval.Children.Add((QChangeRequest)child.Clone());
         }
         return retval;

      }

      public void AddFieldCR(string fieldName)
      {
         if (!Children.Any(F => F.GetType().Equals(typeof(QAddDUIFieldCR)) && ((QAddDUIFieldCR)F).FieldName == fieldName))
         {
            QAddDUIFieldCR cr = AddNewChild<QAddDUIFieldCR>();
            cr.FieldName = fieldName;
         }
      }

      public override T AddNewChild<T>()
      {
         T retval = null;
         if (IsCompatibleChild(typeof(T)))
         {
            retval = new T();
            retval.Parent = this;
            Children.Add(retval);
         }
         return retval;
      }

      private void ClearState()
      {
         code = 0;
         datasourceCode = 0;
      }


      private bool CheckInternal()
      {
         bool retval = false;
         try
         {
            // clear state
            ClearState();

            string sql = @"SELECT DUIP.INST_CODE, DUIV.DUIV_VERSION_VALUE, DUI.DUI_NAME, DUI.DUI_CODE, DSRC.DSRC_NAME, DSRC.DSRC_CODE, UIR.UIR_DESCRIPTION
                           FROM TLK_DYNAMICUI DUI
                           INNER JOIN TLK_DYNAMICUI_DEPL_PROP DUIP
                           ON DUIP.DUI_CODE = DUI.DUI_CODE AND DUIP.INST_CODE=@inst_code
                           INNER JOIN TLK_DYNAMICUI_VERSIONS DUIV
                           ON DUIV.DUIp_CODE=DUIP.DUIP_CODE
                           INNER JOIN TLK_DATASOURCES DSRC
                           ON DUI.DSRC_CODE = DSRC.DSRC_CODE
                           INNER JOIN TLK_UI_ROLES UIR
                           ON UIR.UIR_INTERNAL_DESC=DUIV.DUIV_VERSION_VALUE AND UIR.UIR_DESCRIPTION=@version_value
                           WHERE DUI.DUI_NAME=@dui_name";
            if (VersionValue.Equals("#BASE_VERSION#"))
            {
               sql = @"SELECT DUIP.INST_CODE, DUIV.DUIV_VERSION_VALUE, DUI.DUI_NAME, DUI.DUI_CODE, DSRC.DSRC_NAME, DSRC.DSRC_CODE
                           FROM TLK_DYNAMICUI DUI
                           INNER JOIN TLK_DYNAMICUI_DEPL_PROP DUIP
                           ON DUIP.DUI_CODE = DUI.DUI_CODE AND DUIP.INST_CODE=@inst_code
                           INNER JOIN TLK_DYNAMICUI_VERSIONS DUIV 
                           ON DUIV.DUIp_CODE=DUIP.DUIP_CODE AND DUIV.DUIV_VERSION_VALUE='#BASE_VERSION#'
                           INNER JOIN TLK_DATASOURCES DSRC
                           ON DUI.DSRC_CODE = DSRC.DSRC_CODE                           
                           WHERE DUI.DUI_NAME=@dui_name";
            }

               QDatabase database = QInstance.Environments.GetDatabase(DatabaseName);
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.Add("@dui_name", SqlDbType.NVarChar, 50).Value=name;
            command.Parameters.Add("@version_value", SqlDbType.NVarChar, 50).Value = versionValue;
            command.Parameters.Add("@inst_code", SqlDbType.Int, 50).Value = installationCode;
            try
            {
               DataTable dt = database.ExecuteCommand(command);

               if (dt != null && dt.Rows.Count > 0)
               {
                  code = Convert.ToInt32(dt.Rows[0]["DUI_CODE"].ToString());
                  datasourceCode = Convert.ToInt32(dt.Rows[0]["DSRC_CODE"].ToString());
                  string tmpDatasourceName = Convert.ToString(dt.Rows[0]["DSRC_NAME"].ToString());
                  if (tmpDatasourceName != datasourceName)
                  {
                     QCRAction check = new QCRAction()
                     {
                        State = QCRActionState.NeedsAction,
                        ActionType = QCRActionType.CheckDUI,
                        Description = string.Format("The DUI \"{0}\" is not connected to datasource \"{1}\" but to \"{2}\".", Name, DatasourceName, tmpDatasourceName),
                        DatabaseName = this.DatabaseName
                     };
                     Actions.Add(check);
                  }
                  retval = true;
               }
               else
               {
                  Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.ConfigureDatasource, string.Format("Add datasource \"{0}\".", Name), DatabaseName));
               }
            }
            catch(Exception ex)
            {
               Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.CheckDatabase, string.Format(ex.Message), DatabaseName));
            }
         }
         catch(Exception ex)
         {
            Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.CheckDatabase, string.Format(ex.Message), DatabaseName));
         }
         return retval;
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
            w.WriteAttributeString("code", code.ToString());
            w.WriteAttributeString("name", name);
            w.WriteAttributeString("datasourcecode", datasourceCode.ToString());
            w.WriteAttributeString("datasourcename", datasourceName);
            w.WriteAttributeString("databasename", DatabaseName.ToString());
            w.WriteAttributeString("installationcode", InstallationCode.ToString());
            w.WriteAttributeString("relateddbobject", RelatedDBObject);
            w.WriteAttributeString("versionvalue", VersionValue);

            foreach (QChangeRequest cr in Children)
            {
               w.WriteRaw(cr.Serialize());
            }

            w.WriteEndElement();
            w.Flush();
         }
         return sb.ToString();

      }

      public override void Deserialize(XmlNode Node)
      {
         base.Deserialize(Node);
         code = Node.ReadInt("code",0);
         Name = Node.ReadString("name");
         datasourceCode = Node.ReadInt("datasourcecode", 0);
         DatasourceName = Node.ReadString("datasourcename");
         DatabaseName.FromString(Node.ReadString("databasename"));
         InstallationCode = Node.ReadInt("installationcode", 0);
         RelatedDBObject = Node.ReadString("relateddbobject");
         versionValue = Node.ReadString("versionvalue");

         XmlNodeList children = Node.ChildNodes;
         Children.Clear();
         foreach (XmlNode child in children)
         {
            QChangeRequest childCR = QCRFactory.GetObject(GetType().Namespace, child.Name);
            childCR.Parent = this;
            childCR.Deserialize(child);
            Children.Add(childCR);
         }
      }

      #endregion

      #region checks
      public override bool Check()
      {
         bool result = base.Check();
         
         // check children
         foreach (QChangeRequest cr in Children)
         {
            result = cr.Check() && result;
            Actions.AddRange(cr.Actions);
         }

         result = CheckInternal() && result;

         NotifyPropertyChanged(nameof(CheckResultType));
         return result;
      }

      #endregion

   }
}
