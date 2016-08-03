using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib.ChangeRequests
{
   [Description("Group CR")]
   public class QGroupCR:QChangeRequest
   {
      #region fields
      private string name = "";
      #endregion

      #region properties
      [Category(QConsts.CategoryRequired)]
      public string Name
      {
         get
         {
            return this.name;
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
      [Category(QConsts.CategoryInherited)]
      public override string Description
      {
         get
         {
            return string.Format("Group CR \"{0}\"", name);
         }
      }
      #endregion

      public QGroupCR():base()
      {
         SetCompatibleChildren();
      }

      #region methods


      void SetCompatibleChildren()
      {
         compatibleChildren.Add(typeof(QAlterTableCR));
         compatibleChildren.Add(typeof(QAlterViewCR));
         compatibleChildren.Add(typeof(QGroupCR));
         compatibleChildren.Add(typeof(QConfigureDatasourceCR));
         compatibleChildren.Add(typeof(QConfigureDUICR));
         compatibleChildren.Add(typeof(QConfigureDUIStackCR));
         compatibleChildren.Add(typeof(QAddCriterioCR));

      }

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(name))
            errors.Add(nameof(Name), "Empty Name");
         return errors.Count == 0;
      }


      public override object Clone()
      {
         QGroupCR retval = new QGroupCR()
         {
            Name = this.name,
            Parent = this.Parent,
            Id=this.Id
         };

         foreach (QChangeRequest child in this.Children)
         {
            retval.Children.Add((QChangeRequest)child.Clone());
         }
         return retval;

      }

      public override void CopyState(object source)
      {
         if (source is QGroupCR)
         {
            QGroupCR cr = (QGroupCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
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
