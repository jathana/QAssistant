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
   public class QAddColumnToViewCR : QChangeRequest
   {
      #region fields
      private string columnName = "";
      #endregion
      #region properties
      [Category(QConsts.CategoryRequired)]
      public string ColumnName
      {
         get
         {
            return columnName;
         }
         set
         {
            if (value != this.columnName)
            {
               this.columnName = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string ViewName
      {
         get
         {
            string retval = "";
            if (Parent != null)
            {
               return ((QAlterViewCR)Parent).ViewName;
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
               retval = ((QAlterViewCR)Parent).DatabaseName;
            }
            return retval;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public override string Description
      {
         get
         {
            return string.Format("Add column \"{0}\" to view \"{1}\"", ColumnName, ViewName);
         }
      }

      #endregion

      public QAddColumnToViewCR()
      {         
      }

      #region methods

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(ColumnName))
            errors.Add(nameof(ColumnName), "Column name is mandatory.");
         return errors.Count == 0;
      }

      public override void CopyState(object source)
      {
         if (source is QAddColumnToViewCR)
         {
            QAddColumnToViewCR cr = (QAddColumnToViewCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }

      public override object Clone()
      {
         QAddColumnToViewCR retval = new QAddColumnToViewCR()
         {
            ColumnName = this.columnName,
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
         if(propertyName==nameof(ColumnName) || propertyName==nameof(ViewName))
         {
            NotifyPropertyChanged(nameof(Description));
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
            w.WriteAttributeString("columnname", ColumnName);
            w.WriteEndElement();
            w.Flush();
         }
         return sb.ToString();
         
      }

      public override void Deserialize(XmlNode Node)
      {
         base.Deserialize(Node);
         ColumnName = Node.ReadString("columnname", "");
      }

      #endregion

      #region Checks
      public override bool Check()
      {
         bool result = true;
         Actions.Clear();
         result = ColumnExists() && result;
         NotifyPropertyChanged(nameof(CheckResultType));
         return result;
      }

      private bool ColumnExists()
      {
         bool result = true;
         try
         {
            QDatabase database = QInstance.Environments.GetDatabase(DatabaseName);
            QDBTableSchema schema = ((QAlterViewCR)Parent).GetSchema(false);
            schema.Load(database, ViewName);
            if (schema.ContainsColumn(ColumnName))
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.WellImplemented,
                  ActionType = QCRActionType.NoAction,
                  Description = string.Format("Add field {0} in view {1}", ColumnName, ViewName),
                  DatabaseName = this.DatabaseName
               };
               Actions.Add(check);
            }
            else
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.NeedsAction,
                  ActionType = QCRActionType.AddColumn,
                  Description = string.Format("Add field {0} in view {1}", ColumnName, ViewName),
                  DatabaseName = this.DatabaseName
               };
               Actions.Add(check);
            }

         }
         catch(Exception ex)
         {
            QCRAction check = new QCRAction()
            {
               State = QCRActionState.NeedsAction,
               ActionType = QCRActionType.AddColumn,
               Description = string.Format(ex.Message),
               DatabaseName = this.DatabaseName
            };
            Actions.Add(check);
            result = false;
         }
         return result;
      }
      #endregion

   }
}
