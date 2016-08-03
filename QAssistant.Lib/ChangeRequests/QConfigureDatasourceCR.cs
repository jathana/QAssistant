using QAssistant.Lib.TypeEditors;
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
   [Description("Configure Datasource CR")]
   public class QConfigureDatasourceCR : QChangeRequest
   {
      #region fields
      private int code=0;
      private string name="";
      private string definition="";
      private string relatedDBObject=""; // view/table/stored proc
      private QDatabaseName databaseName = new QDatabaseName();
      private int installationCode = 0;
      #endregion

      #region properties

      [Category(QConsts.CategoryRequired)]
      [Editor(typeof(QInstallationCodeTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
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
      [Editor(typeof(QDBTablesViewsSPsTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
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

      [Category(QConsts.CategoryInherited)]
      public string Definition
      {
         get
         {
            return definition;
         }
      }

      [Category(QConsts.CategoryInherited)]
      public override string Description
      {
         get
         {
            return string.Format("Configure datasource \"{0}\" (\"{1}\")", Name, RelatedDBObject);
         }
      }
      #endregion

      public QConfigureDatasourceCR()
      {
         SetCompatibleChildren();
         needsChildren = true;
      }


      #region methods

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(name))
            errors.Add(nameof(Name), "Name is mandatory.");
         if (string.IsNullOrEmpty(relatedDBObject))
            errors.Add(nameof(RelatedDBObject), "RelatedDBObject is mandatory.");
         if (databaseName.IsInvalid())
            errors.Add(nameof(DatabaseName), "Check DatabaseName.");

         return errors.Count == 0;
      }


      void SetCompatibleChildren()
      {
         compatibleChildren.Add(typeof(QAddDatasourceFieldCR));
      }

      public override void CopyState(object source)
      {
         if (source is QConfigureDatasourceCR)
         {
            QConfigureDatasourceCR cr = (QConfigureDatasourceCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }

      public override object Clone()
      {
         QConfigureDatasourceCR retval = new QConfigureDatasourceCR()
         {
            Name = this.name,
            RelatedDBObject = this.relatedDBObject,
            DatabaseName = new QDatabaseName(this.databaseName.FullName),
            InstallationCode = this.installationCode,
            Parent = this.Parent
         };

         foreach (QChangeRequest child in this.Children)
         {
            retval.Children.Add((QChangeRequest)child.Clone());
         }
         return retval;

      }

      protected override void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
      {
         base.NotifyPropertyChanged(propertyName);

         if (propertyName == nameof(Name) || propertyName == nameof(RelatedDBObject))
         {
            NotifyPropertyChanged(nameof(Description));
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


      public void ConfigureDatasourceFieldCR(QPoolField field)
      {
            if (!Children.Any(F => F.GetType().Equals(typeof(QAddDatasourceFieldCR)) &&
                                   ((QAddDatasourceFieldCR)F).FieldName == field.FieldName &&
                                   ((QAddDatasourceFieldCR)F).FieldCaption == field.EnglishCaption &&
                                   ((QAddDatasourceFieldCR)F).InstallationCode == InstallationCode)
               )
            {
               QAddDatasourceFieldCR cr = AddNewChild<QAddDatasourceFieldCR>();
               cr.FieldName = field.FieldName;
               cr.FieldCaption = field.EnglishCaption;
            }
      }

      public void ConfigureDatasourceFieldsCR(List<QPoolField> fields)
      {
         foreach (QPoolField fld in fields)
         {
            ConfigureDatasourceFieldCR(fld);
         }
      }

      private void ClearState()
      {
         code = 0;
         definition = "";
      }

      private bool Load()
      {
         bool retval = false;
         try
         {
            // clear state
            ClearState();

            QDatabase database = QInstance.Environments.GetDatabase(DatabaseName);
            SqlCommand command = new SqlCommand("SELECT DSRC_CODE, DSRC_DEFINITION FROM TLK_DATASOURCES WHERE DSRC_NAME = @name");
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value=name;
            DataTable dt = database.ExecuteCommand(command);
            if(dt != null)
            {
               code = Convert.ToInt32(dt.Rows[0]["DSRC_CODE"].ToString());
               definition = dt.Rows[0]["DSRC_DEFINITION"].ToString();
               retval = true;
            }
         }
         catch(Exception ex)
         {
            QCRAction check = new QCRAction()
            {
               State = QCRActionState.NeedsAction,
               ActionType = QCRActionType.ConfigureDatasource,
               Description = ex.Message,
               DatabaseName = this.DatabaseName
            };
            Actions.Add(check);
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
            w.WriteAttributeString("definition", definition);
            w.WriteAttributeString("databasename", DatabaseName.ToString());
            w.WriteAttributeString("relateddbobject", relatedDBObject);
            w.WriteAttributeString("installationcode", installationCode.ToString());



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
         definition = Node.ReadString("definition");
         RelatedDBObject = Node.ReadString("relateddbobject");
         DatabaseName.FromString(Node.ReadString("databasename"));
         InstallationCode = Node.ReadInt("installationcode", 0);
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

         result = DatasourceExists() && result;

         NotifyPropertyChanged(nameof(CheckResultType));

         return result;
      }

      private bool DatasourceExists()
      {
         bool retval = false;
         // always ensure loaded
         if (Load())
         {
            if (code==0)
            {
               Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.ConfigureDatasource, string.Format("Add datasource \"{0}\".", Name), DatabaseName));
            }
         }
         else
         {
            Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.CheckDatabase, string.Format("Check database \"{0}\" of datasource \"{1}\".", DatabaseName, Name), DatabaseName));
         }
         return retval;
      }
      #endregion

   }
}
