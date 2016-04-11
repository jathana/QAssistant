using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib.ChangeRequests
{
   public class QConfigureDUIStackCR : QChangeRequest
   {
      #region fields
      private QDatabaseName databaseName = new QDatabaseName();
      private int installationCode = 0;
      private string relatedDBObject = ""; // view/table/stored proc
      private string datasourceName="";
      private string dynamicUIName="";
      private string tableName="";
      private string name = "";
      private QDBObjectType dbObjectType = QDBObjectType.View;

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
      public override string Description
      {
         get
         {
            return string.Format("Configure DUI Stack CR \"{0}\"", Name);
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

      [Category(QConsts.CategoryRequired)]
      public string DynamicUIName
      {
         get
         {
            return dynamicUIName;
         }
         set
         {
            if (value != this.dynamicUIName)
            {
               this.dynamicUIName = value;
               NotifyPropertyChanged();
            }
         }
      }

      [Category(QConsts.CategoryRequired)]
      public string TableName
      {
         get
         {
            return tableName;
         }
         set
         {
            if (value != this.tableName)
            {
               this.tableName = value;
               NotifyPropertyChanged();
            }
         }
      }

      [Category(QConsts.CategoryRequired)]
      public QDBObjectType DBObjectType
      {
         get
         {
            return dbObjectType;
         }

         set
         {
            if (value != this.dbObjectType)
            {
               this.dbObjectType = value;
               NotifyPropertyChanged();
            }
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

      #endregion

      public QConfigureDUIStackCR():base()
      {
         SetCompatibleChildren();
      }

      #region methods

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(datasourceName))
            errors.Add(nameof(DatasourceName), "DatasourceName is mandatory.");
         if (string.IsNullOrEmpty(tableName))
            errors.Add(nameof(TableName), "TableName is mandatory.");
         if (string.IsNullOrEmpty(name))
            errors.Add(nameof(Name), "Name is mandatory.");
         if (string.IsNullOrEmpty(dynamicUIName))
            errors.Add(nameof(DynamicUIName), "DynamicUI Name is mandatory.");
         if (string.IsNullOrEmpty(relatedDBObject))
            errors.Add(nameof(RelatedDBObject), "RelatedDBObject is mandatory.");
         if (databaseName.IsInvalid())
            errors.Add(nameof(DatabaseName), "Check DatabaseName.");

         return errors.Count == 0;
      }

      void SetCompatibleChildren()
      {
         compatibleChildren.Add(typeof(QAlterTableCR));
         compatibleChildren.Add(typeof(QAlterViewCR));
         compatibleChildren.Add(typeof(QGroupCR));
         compatibleChildren.Add(typeof(QConfigureDatasourceCR));
         compatibleChildren.Add(typeof(QConfigureDUICR));
      }

      public override void CopyState(object source)
      {
         if (source is QConfigureDUIStackCR)
         {
            QConfigureDUIStackCR cr = (QConfigureDUIStackCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }
      public override object Clone()
      {
         QConfigureDUIStackCR retval = new QConfigureDUIStackCR()
         {
            Name = this.Name,
            RelatedDBObject = this.relatedDBObject,
            InstallationCode = this.installationCode,
            Parent = this.Parent,
            DatasourceName = this.datasourceName,
            DynamicUIName = this.dynamicUIName,
            TableName = this.tableName,
            DatabaseName = this.databaseName
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
            w.WriteAttributeString("name", Name);
            w.WriteAttributeString("databasename", databaseName.ToString());
            w.WriteAttributeString("installationcode", installationCode.ToString());
            w.WriteAttributeString("relateddbobject", relatedDBObject);
            w.WriteAttributeString("datasourcename", datasourceName);
            w.WriteAttributeString("dynamicuiname", dynamicUIName);
            w.WriteAttributeString("tablename", tableName);
            w.WriteAttributeString("dbobjecttype", DBObjectType.ToString());

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
         Name = Node.ReadString("name");
         DatabaseName.FromString(Node.ReadString("databasename"));
         InstallationCode = Node.ReadInt("installationcode",0);
         RelatedDBObject = Node.ReadString("relateddbobject");
         DatasourceName = Node.ReadString("datasourcename");
         DynamicUIName = Node.ReadString("dynamicuiname");
         TableName = Node.ReadString("tablename");
         DBObjectType = Node.ReadEnum<QDBObjectType>("dbobjecttype");
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

      #region Checks
      public override bool Check()
      {
         bool result = true;
         Actions.Clear();
         // check children
         foreach (QChangeRequest cr in Children)
         {
            result = cr.Check() && result;
            Actions.AddRange(cr.Actions);
         }
         NotifyPropertyChanged(nameof(CheckResultType));
         return result;
      }
      #endregion
   }
}
