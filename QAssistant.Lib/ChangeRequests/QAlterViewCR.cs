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
   public class QAlterViewCR:QChangeRequest
   {
      #region fields
      private bool loadNeeded = true;
      private string viewName = "";
      private QDatabaseName databaseName = new QDatabaseName();
      private QDBTableSchema schema = null;
      #endregion


      #region properties
      [Category(QConsts.CategoryRequired)]
      [Editor(typeof(QDBViewsTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
      public string ViewName
      {
         get
         {
            return viewName;
         }
         set
         {
            if (value != this.viewName)
            {
               this.viewName = value;
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
            return string.Format("Alter view \"{0}\"", ViewName);
         }
      }
      
      #endregion


      public QAlterViewCR():base()
      {
         SetCompatibleChildren();
         needsChildren = true;
      }




      #region methods

      void SetCompatibleChildren()
      {
         compatibleChildren.Add(typeof(QAddColumnToViewCR));
      }

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(ViewName))
            errors.Add(nameof(ViewName), "View name is mandatory.");
         if (databaseName.IsInvalid())
            errors.Add(nameof(DatabaseName), "Check database name.");
         return errors.Count == 0;
      }

      public override void CopyState(object source)
      {
         if (source is QAlterViewCR)
         {
            QAlterViewCR cr = (QAlterViewCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }
      public override object Clone()
      {
         QAlterViewCR retval = new QAlterViewCR()
         {
            DatabaseName = this.databaseName,
            ViewName = this.viewName,
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
         if (propertyName == nameof(ViewName))
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
            if (schema.Load(dbObj, ViewName))
            {
               loadNeeded = false;
               retval = true;
            }
         }
         return retval;
      }

      public void AddColumnCR(string columnName)
      {
         if (!Children.Any(F => F.GetType().Equals(typeof(QAddColumnToViewCR)) && ((QAddColumnToViewCR)F).ColumnName == columnName))
         {
            QAddColumnToViewCR cr = AddNewChild<QAddColumnToViewCR>();
            cr.ColumnName = columnName;
         }
      }

      public void AddColumnsCR(List<string> columnNames)
      {
         foreach (string tmpColumnName in columnNames)
         {
            AddColumnCR(tmpColumnName);
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
            w.WriteAttributeString("viewname", ViewName);
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
         ViewName = Node.ReadString("viewname");
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

         result = ViewExists() && result;

         NotifyPropertyChanged(nameof(CheckResultType));
         return result;
      }


      private bool ViewExists()
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
                  Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.AddView, string.Format("Create view \"{0}\".", ViewName), databaseName));
               }
            }
            else
            {
               Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.CheckDatabase, string.Format("Check database \"{0}\" of view \"{1}\".", DatabaseName, ViewName), databaseName));
            }
         }
         catch (Exception ex)
         {
            Actions.Add(new QCRAction(QCRActionState.NeedsAction, QCRActionType.CheckDatabase, ex.Message, databaseName));
         }
         return retval;
      }

      #endregion

   }
}
