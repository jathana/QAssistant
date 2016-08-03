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
   [Description("Configure DUI Stack Many")]
   public class QConfigureDUIStackManyCR : QGroupCR
   {
      #region fields
      private QDatabaseNames databaseNamesForDUI = new QDatabaseNames();
      private QDatabaseNames databaseNames = new QDatabaseNames();
      private int installationCode = 0;
      private string relatedDBObject = ""; // view/table/stored proc
      private string datasourceName="";
      private string dynamicUIName="";
      private string tableName="";
      private List<QPoolField> fieldsToAdd = new List<QPoolField>();
      private QDBObjectType dbObjectType = QDBObjectType.View;

      #endregion

      #region properties

      [Category(QConsts.CategoryRequired)]
      public List<QPoolField> FieldsToAdd
      {
         get
         {
            return fieldsToAdd;
         }
      }

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
      [Editor(typeof(QDatabaseNamesTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
      public QDatabaseNames DatabaseNamesForDUI
      {
         get
         {
            return databaseNamesForDUI;
         }
      }

      [Category(QConsts.CategoryRequired)]
      [Editor(typeof(QDatabaseNamesTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
      public QDatabaseNames DatabaseNames
      {
         get
         {
            return databaseNames;
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

      #endregion

      public QConfigureDUIStackManyCR():base()
      {
         databaseNamesForDUI.ListChanged += DatabaseNamesForDUI_ListChanged;
         databaseNames.ListChanged += DatabaseNames_ListChanged;
         //fieldsToAdd.ListChanged += FieldsToAdd_ListChanged;
      
         SetCompatibleChildren();
         needsChildren = true;
      }

      void SetCompatibleChildren()
      {
         compatibleChildren.Add(typeof(QConfigureDUIStackCR));
      }

      #region methods
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
         QConfigureDUIStackManyCR retval = new QConfigureDUIStackManyCR()
         {
            Name = this.Name,
            RelatedDBObject = this.relatedDBObject,
            InstallationCode = this.installationCode,
            Parent = this.Parent,
            DatasourceName = this.datasourceName,
            DynamicUIName = this.dynamicUIName,
            TableName = this.tableName,
         };
         foreach (QDatabaseName dbName in databaseNamesForDUI)
         {
            retval.databaseNamesForDUI.Add(new QDatabaseName(dbName.FullName));
         }

         foreach (QDatabaseName dbName in databaseNames)
         {
            retval.databaseNames.Add(new QDatabaseName(dbName.FullName));
         }

         foreach (QPoolField fld in fieldsToAdd)
         {
            retval.fieldsToAdd.Add(new QPoolField() { FieldName=fld.FieldName, EnglishCaption=fld.EnglishCaption });
         }
         foreach (QChangeRequest child in this.Children)
         {
            retval.Children.Add((QChangeRequest)child.Clone());
         }
         return retval;

      }
      private void FieldsToAdd_ListChanged(object sender, ListChangedEventArgs e)
      {
         try
         {
            switch (e.ListChangedType)
            {
               case ListChangedType.Reset:
                  UpdateChildren();
                  break;
            }
         }
         catch { }
      }

      private void DatabaseNames_ListChanged(object sender, ListChangedEventArgs e)
      {
         try
         {
            switch (e.ListChangedType)
            {
               case ListChangedType.Reset:
                  UpdateChildren();
                  break;
            }
         }
         catch { }
      }
      protected override void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
      {
         base.NotifyPropertyChanged(propertyName);
         UpdateChildren();
      }


      private void DatabaseNamesForDUI_ListChanged(object sender, ListChangedEventArgs e)
      {
         try
         {
            switch (e.ListChangedType)
            {
               case ListChangedType.Reset:
                  UpdateChildren();
                  break;
            }
         }
         catch { }
      }

      private void UpdateChildren()
      {
         
         try
         {
            Children.Clear();

            foreach (QDatabaseName dbName in databaseNames)
            {
               QAlterTableCR cr = AddNewChild<QAlterTableCR>();
               cr.DatabaseName = dbName;
               cr.TableName = tableName;
            }
            foreach (QDatabaseName dbName in databaseNamesForDUI)
            {
               QConfigureDUICR duiCR = AddNewChild<QConfigureDUICR>();
               duiCR.Name = dynamicUIName;
               duiCR.InstallationCode = installationCode;
               duiCR.DatabaseName = dbName;

               QConfigureDatasourceCR dsCR = AddNewChild<QConfigureDatasourceCR>();
               dsCR.Name = datasourceName;
               dsCR.InstallationCode = installationCode;
               dsCR.DatabaseName = dbName;
               if (dbObjectType == QDBObjectType.View)
               {
                  QAlterViewCR viewCR = AddNewChild<QAlterViewCR>();
                  viewCR.ViewName = relatedDBObject;
               }
               else if (dbObjectType == QDBObjectType.Table)
               {
                  QAlterTableCR tableCR = AddNewChild<QAlterTableCR>();
                  tableCR.TableName = relatedDBObject;
               }
            }
         }
         catch(Exception ex)
         {
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
         bool result = base.Check();
         
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
