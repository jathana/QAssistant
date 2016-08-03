using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib.ChangeRequests
{
   [Description("Document CR")]
   public class QDocumentCR : QChangeRequest
   {
      #region fields
      private int version = 1;
      private string crName = "";
      private QChangeRequests crTree = new QChangeRequests();

      #endregion

      #region properties
      [Category(QConsts.CategoryRequired)]
      public int Version
      {
         get
         {
            return version;
         }

         set
         {
            if (value != this.version)
            {
               this.version = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public string CRName
      {
         get
         {
            return this.crName;
         }

         set
         {
            if (value != this.crName)
            {
               this.crName = value;
               NotifyPropertyChanged();
            }
         }
      }

      [Browsable(false)]
      public QChangeRequests CRTree
      {
         get
         {
            return crTree;
         }
      }

      [Category(QConsts.CategoryInherited)]
      public override string Description
      {
         get
         {
            return string.Format("CR Document [{0}]", crName);
         }
      }


      #endregion

      public QDocumentCR() : base()
      {
         //ChangeRequestType = QChangeRequestType.Document;         
         AddRootNode();
         SetCompatibleChildren();
         needsChildren = true;
         AddNewChild<QPoolFields>();
      }

      #region methods

      


      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(CRName))
            errors.Add(nameof(CRName), "CRName is mandatory.");

         return errors.Count == 0;
      }
      #endregion

      #region children

      void SetCompatibleChildren()
      {
         compatibleChildren.Add(typeof(QAlterTableCR));
         compatibleChildren.Add(typeof(QAlterViewCR));
         compatibleChildren.Add(typeof(QGroupCR));
         compatibleChildren.Add(typeof(QConfigureDatasourceCR));
         compatibleChildren.Add(typeof(QConfigureDUICR));
         compatibleChildren.Add(typeof(QConfigureDUIStackCR));
         compatibleChildren.Add(typeof(QAddCriterioCR));
         compatibleChildren.Add(typeof(QPoolFields));

      }



      public override void CopyState(object source)
      {
         if (source is QDocumentCR)
         {
            QDocumentCR cr = (QDocumentCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }
      public override object Clone()
      {
         QDocumentCR retval = new QDocumentCR()
         {
            CRName = this.crName,
            Version = this.version,
            //ChangeRequestType = this.ChangeRequestType,
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

      private void AddRootNode()
      {
         crTree = new QChangeRequests();        
         crTree.Add(this);
         
      }

      public QChangeRequest GetCR(string Id)
      {
         QChangeRequest retval = null;
         GetCRInternal(Id, this, ref retval);
         return retval;
      }

      private void GetCRInternal(string Id, QChangeRequest CR, ref QChangeRequest CRFound)
      {
         if (CRFound != null) return;
         if (CR != null)
         {
            if (CR.Id == Id)
            {
               CRFound = CR;
               return;
            }
            else
            {
               foreach (QChangeRequest child in CR.Children)
               {
                  GetCRInternal(Id, child, ref CRFound);
               }
            }
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
            w.WriteAttributeString("version", version.ToString());            
            w.WriteAttributeString("crname", CRName);

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
         Version = Node.ReadInt("version", 1);
         CRName = Node.ReadString("crname");

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
