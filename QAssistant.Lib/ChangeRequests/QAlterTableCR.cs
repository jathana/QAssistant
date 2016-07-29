using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.CompilerServices;

namespace QAssistant.Lib.ChangeRequests
{
   public class QAlterTableCR:QChangeRequest
   {
      #region fields
      private bool loadNeeded = true;
      private string tableName = "";
      private QDatabaseName databaseName = new QDatabaseName();
      private QDBTableSchema schema = null;
      #endregion


      #region properties
      [Category(QConsts.CategoryRequired)]
      [Editor(typeof(QPoolTablesTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
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
            return string.Format("Alter table \"{0}.{1}\" ", DatabaseName,TableName);
         }
      }
      #endregion


      public QAlterTableCR():base()
      {
         SetCompatibleChildren();
         needsChildren = true;
      }

      #region methods
      private void SetCompatibleChildren()
      {
         compatibleChildren.Add(typeof(QAddColumnToTableCR));
      }

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(TableName))
            errors.Add(nameof(TableName), "Table name is mandatory.");
         if(databaseName.IsInvalid())
            errors.Add(nameof(DatabaseName), "Check database name.");
         return errors.Count == 0;
      }

      public override void CopyState(object source)
      {
         if (source is QAlterTableCR)
         {
            QAlterTableCR cr = (QAlterTableCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }

      public override object Clone()
      {
         QAlterTableCR retval = new QAlterTableCR()
         {
            DatabaseName = this.databaseName,
            TableName = this.tableName,
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
         if (IsCompatibleChild(typeof(T)))
         {
            retval = new T();
            retval.Parent = this;
            Children.Add(retval);
         }
         return retval;
      }

      public QDBTableSchema GetSchema(bool freshSnapshot)
      {
         if (freshSnapshot || loadNeeded)
         {
            Load();
            loadNeeded = false;
         }
         return schema;
      }

      protected override void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
      {
         base.NotifyPropertyChanged(propertyName);
         if(propertyName == nameof(TableName))
         {
            NotifyPropertyChanged(nameof(Description));
         }
         else if (propertyName == nameof(DatabaseName))
         {
            NotifyPropertyChanged(nameof(Description));
         }
      }

      private bool Load()
      {
         bool retval = false;
         QDatabase dbObj = QInstance.Environments.GetDatabase(databaseName);
         if (dbObj != null)
         {
            schema = new QDBTableSchema();
            if (schema.Load(dbObj, tableName))
            {
               loadNeeded = false;
               retval = true;
            }
         }
         return retval;
      }

      public void AddColumnToTableCR(string columnName)
      {
         if (!Children.Any(F => F.GetType().Equals(typeof(QAddColumnToTableCR)) && ((QAddColumnToTableCR)F).ColumnName == columnName))
         {
            QAddColumnToTableCR cr = AddNewChild<QAddColumnToTableCR>();
            cr.ColumnName = columnName;
         }
      }


      public void AddColumnsToTableCR(List<string> columnNames)
      {
         foreach (string tmpColumnName in columnNames)
         {
            AddColumnToTableCR(tmpColumnName);
         }
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
            w.WriteAttributeString("tablename", TableName);
            w.WriteAttributeString("databasename", DatabaseName.ToString());

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
         TableName = Node.ReadString("tablename");
         DatabaseName.FromString(Node.ReadString("databasename"));
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
         foreach(QChangeRequest cr in Children)
         {
            result = cr.Check() && result;
            Actions.AddRange(cr.Actions);
         }

         result = TableExists() && result;
         NotifyPropertyChanged(nameof(CheckResultType));
         return result;
      }


      private bool TableExists()
      {
         bool retval = true;

         // always ensure loaded
         try
         {
            if (Load())
            {
               retval = schema != null && schema.ObjectExists();
               if (!retval)
               {
                  Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.AddTable, string.Format("Create table \"{0}\".", TableName), databaseName));
               }
            }
            else
            {
               Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.CheckDatabase, string.Format("Check database \"{0}\" of table \"{1}\".", DatabaseName, TableName), databaseName));
            }
         }
         catch(Exception ex)
         {
            Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.CheckDatabase, ex.Message, databaseName));
         }
         return retval;
      }

      #endregion

   }
}
