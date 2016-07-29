using QAssistant.Lib;
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

   

   public abstract class QChangeRequest:INotifyPropertyChanged, IStateHandler, ICloneable, IValidatable, IDisposable
   {

      #region fields
      protected List<Type> compatibleChildren = new List<Type>();
      protected bool needsChildren = false;
      #endregion

      #region properties

      [Browsable(false)]
      public string Id { get; set; }
      //[Category("Inherited")]
      //public QChangeRequestType ChangeRequestType { get; internal set; }

      [Browsable(false)]
      public QCRCheckResultType CheckResultType
      {
         get
         {
            QCRCheckResultType retval = QCRCheckResultType.NotChecked;
            if (Actions.Count > 0)
            {
               QCRAction action = Actions.FirstOrDefault(A => A.State == QCRActionState.NeedsAction);
               retval = (action == null ? QCRCheckResultType.WellImplemented : QCRCheckResultType.NeedsAttention);
            }
            return retval;
         }
      }

      public virtual string Description { get;  }
      [Browsable(false)]
      public List<QCRAction> Actions { get; set; }
      [Browsable(false)]
      public QChangeRequest Parent { get; set; }
      [Browsable(false)]
      public QChangeRequests Children { get; set; }
      [Browsable(false)]
      public List<Type> CompatibleChildren
      {
         get
         {
            return compatibleChildren;
         }
      }

      [Browsable(false)]
      protected bool NeedsChildren
      {
         get
         {
            return needsChildren;
         }
      }
      #endregion

      #region INotifyPropertyChanged
      public event PropertyChangedEventHandler PropertyChanged;
      // This method is called by the Set accessor of each property.
      // The CallerMemberName attribute that is applied to the optional propertyName
      // parameter causes the property name of the caller to be substituted as an argument.
      protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
      {
         if (PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
      }
      #endregion


      #region checks
      protected bool CheckHasChildren()
      {
         bool retval = true;
         if (Children.Count == 0)
         {
            QCRAction check = new QCRAction()
            {
               State = QCRActionState.NeedsAction,
               ActionType = QCRActionType.AddCRChildren,
               Description = "Add children change requests."
            };
            Actions.Add(check);
            retval = false;
         }
         return retval;
      }

      public virtual bool Check()
      {
         bool retval = true;

         Actions.Clear();
         if (needsChildren)
         {
            retval = CheckHasChildren() && retval; 
         }

         return retval;
      }
      #endregion

      #region methods

      public void Dispose()
      {
         Children.Clear();
      }

      public bool CanBeChildOf(QChangeRequest changeRequest)
      {
         bool retval = false;
         if (changeRequest != null)
         {
            retval = changeRequest.CompatibleChildren.Contains(GetType());
         }
         return retval;

      }

      protected bool IsCompatibleChild(Type childType)
      {
         return compatibleChildren.Contains(childType);
      }

      
      public abstract object Clone();
      public abstract bool Validate(out Dictionary<string, string> errors);
      public abstract void CopyState(object source);
      
      public virtual string Serialize() { return ""; }
      public virtual void Deserialize(XmlNode Node)
      {
         Id = Node.ReadString("id");
      }
      public virtual T AddNewChild<T>() where T : QChangeRequest,new()
      {
         T retval  = new T();
         retval.Parent = this;
         Children.Add(retval);
         return retval;
      }


      public virtual void AddChild<T>(T child) where T : QChangeRequest
      {
         child.Parent = this;
         Children.Add(child);
      }


      public QChangeRequest GetRoot()
      {
         QChangeRequest root = this;
         while (root.Parent!=null)
         {
            root = root.Parent;
         }
         return root;
      }


      public List<T> GetDescendants<T>() where T: QChangeRequest
      {
         var nodes = Children.Concat(Children.SelectMany(n=>n.GetDescendants<T>()))
                        .OfType<T>()
                        .ToList<T>();
         return nodes;
      }
      #endregion


      public static void Delete(QChangeRequest item)
      {
         DeleteInternal(item);
         if (item.GetType() != typeof(QDocumentCR))
         {
            item.Parent.Children.Remove(item);
         }
         item = null;
         
      }

      private static void DeleteInternal(QChangeRequest item)
      {
         if (item.Children != null && item.Children.Count > 0)
         {
            for(int i= item.Children.Count-1; i > 0; i--)
            {
               DeleteInternal(item.Children[0]);
            }
         }
         else
         {
            item.Children.Clear();
         }
      }


      public QChangeRequest()
      {
         Id = Guid.NewGuid().ToString("N");
         //ChangeRequestType = QChangeRequestType.None;
         Actions = new List<QCRAction>();
         Children = new QChangeRequests();
      }

      #region serialization
      protected void Serialize(XmlWriter w)
      {
         if (w != null)
         {
            w.WriteAttributeString("id", Id);
            //w.WriteAttributeString("changerequesttype", ChangeRequestType.ToString());
         }
      }

      









      #endregion

   }
}
