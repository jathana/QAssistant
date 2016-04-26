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
   public class QAddColumnToTableCR : QChangeRequest
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
      public string TableName
      {
         get
         {
            string retval = "";
            if (Parent != null)
            {
               retval = ((QAlterTableCR)Parent).TableName;
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
               retval = ((QAlterTableCR)Parent).DatabaseName;
            }
            return retval;
         }
      }

      [Category(QConsts.CategoryInherited)]
      public override string Description
      {
         get
         {
            return string.Format("Add column \"{0}\" to table \"{1}\".", ColumnName, TableName);
         }
      }


      #endregion

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
         if (source is QAddColumnToTableCR)
         {
            QAddColumnToTableCR cr = (QAddColumnToTableCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }

      public override object Clone()
      {
         QAddColumnToTableCR retval = new QAddColumnToTableCR()
         {
            ColumnName = this.columnName,
            Parent = this.Parent,
            Id = this.Id
         };
         foreach(QChangeRequest child in this.Children)
         {
            retval.Children.Add((QChangeRequest)child.Clone());
         }
         return retval;
         
      }

      protected override void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
      {
         base.NotifyPropertyChanged(propertyName);
         if(propertyName == nameof(TableName) || propertyName == nameof(ColumnName))
         {
            NotifyPropertyChanged(nameof(Description));
         }
      }
      public QAddColumnToTableCR()
      {         
         ColumnName = "";
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
         bool result = base.Check();
         result = CheckFieldInTable() && result;
         NotifyPropertyChanged(nameof(CheckResultType));
         return result;
      }

      private bool CheckFieldInTable()
      {
         bool result = true;
         try
         {
            QDatabase database = QInstance.Environments.GetDatabase(DatabaseName);
            QDBTableSchema schema = ((QAlterTableCR)Parent).GetSchema(false);
            schema.Load(database, TableName);
            if (schema.ContainsColumn(ColumnName))
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.WellImplemented,
                  ActionType = QCRActionType.NoActionNeeded,
                  Description = this.Description,
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
                  Description = this.Description,
                  DatabaseName = this.DatabaseName
               };
               Actions.Add(check);
            }

         }
         catch (Exception ex)
         {
            QCRAction check = new QCRAction()
            {
               State = QCRActionState.NeedsAction,
               ActionType = QCRActionType.AddColumn,
               Description = ex.Message,
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
