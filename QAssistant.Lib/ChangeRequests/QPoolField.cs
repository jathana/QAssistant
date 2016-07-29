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
   public class QPoolField: QChangeRequest
   {

      #region fields
      private string fieldName = "";
      private string tableName = "";
      private string englishCaption = "";
      private string greekCaption = "";

      #endregion

      #region properties
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
      public string EnglishCaption
      {
         get
         {
            return englishCaption;
         }
         set
         {
            if (value != this.englishCaption)
            {
               this.englishCaption = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public string GreekCaption
      {
         get
         {
            return greekCaption;
         }
         set
         {
            if (value != this.greekCaption)
            {
               this.greekCaption = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryInherited)]
      public override string Description
      {
         get
         {
            return string.Format("Pool Field \"{0} - {1}\"", englishCaption, fieldName);
         }
      }
      #endregion


      public QPoolField()
      {
         TableName = "";
         FieldName = "";         
         englishCaption = "";
         greekCaption = "";
         needsChildren = false;
      }

      #region methods
      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(fieldName))
            errors.Add(nameof(FieldName), "Field name is mandatory.");
         if (string.IsNullOrEmpty(tableName))
            errors.Add(nameof(TableName), "Table name is mandatory.");
         if (string.IsNullOrEmpty(englishCaption))
            errors.Add(nameof(EnglishCaption), "English caption is mandatory.");
         return errors.Count == 0;
      }

      public override void CopyState(object source)
      {
         if (source is QPoolField)
         {
            QPoolField cr = (QPoolField)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }
      public override object Clone()
      {
         QPoolField retval = new QPoolField()
         {
            FieldName = this.fieldName,
            TableName = this.tableName,
            EnglishCaption= this.englishCaption,
            GreekCaption = this.greekCaption,
            Parent = this.Parent
         };
         
         return retval;

      }

      public override T AddNewChild<T>()
      {
         T retval = null;
         if (typeof(T) == typeof(QPoolField))
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
            w.WriteAttributeString("fieldname", FieldName);
            w.WriteAttributeString("tablename", TableName);
            w.WriteAttributeString("englishcaption", EnglishCaption);
            w.WriteAttributeString("greekcaption", GreekCaption);

            w.WriteEndElement();
            w.Flush();
         }
         return sb.ToString();

      }

      public override void Deserialize(XmlNode Node)
      {
         base.Deserialize(Node);
         FieldName = Node.ReadString("fieldname", "");
         TableName = Node.ReadString("tablename", "");
         EnglishCaption = Node.ReadString("englishcaption", "");
         GreekCaption = Node.ReadString("greekcaption", "");

      }

      #endregion

      #region Checks
      public override bool Check()
      {
         bool result = base.Check();
         Actions.Clear();
         // everything ok
            QCRAction check = new QCRAction()
            {
               State = QCRActionState.WellImplemented,
               ActionType = QCRActionType.NoActionNeeded,
               Description = string.Format("Add field \"{0}\" to pool.", FieldName)
            };
            Actions.Add(check);

         NotifyPropertyChanged(nameof(CheckResultType));
         return result;
      }
      #endregion
   }
}
