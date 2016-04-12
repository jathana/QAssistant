using QAssistant.Lib.TypeEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QAssistant.Lib.ChangeRequests
{
   public class QAddCriterioCR : QChangeRequest
   {
      #region internal fields
      private StringBuilder connectionMsg = new StringBuilder();
      #endregion
      #region input fields
      private QDatabaseName databaseName = new QDatabaseName();
      private string name = "";
      private QCriterioType criterioType = QCriterioType.Unspecified;
      private bool queues = true;
      private bool dynamicQueues = true;
      private bool worklist = true;
      private bool revocation = true;
      private bool strategy = true;
      private bool decisionTree = true;
      private string categoryDesc = "";
      private bool isCustomerLevel = false;
      private bool closedCases = false;
      private int installationCode = 0;
      #endregion

      #region output fields
      private string criUniqueId = "";
      private string criTable = "";
      private string criFields = "";
      private string criWhere = "";
      private string crjCode = "";
      private string crjJoin = "";
      private string criWhereTable = "";
      private string criWhereField = "";
      private string criWhereShow = "";
      private string criWhereFieldSqlType = "";
      #endregion


      #region properties

     

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
            return string.Format("Add criterio \"{0}\"", Name);
         }
      }

      [Category(QConsts.CategoryRequired)]
      public QCriterioType CriterioType
      {
         get
         {
            return criterioType;
         }

         set
         {
            if (value != this.criterioType)
            {
               this.criterioType = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public bool Queues
      {
         get
         {
            return queues;
         }

         set
         {
            if (value != this.queues)
            {
               this.queues = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public bool DynamicQueues
      {
         get
         {
            return dynamicQueues;
         }
         set
         {
            if (value != this.dynamicQueues)
            {
               this.dynamicQueues = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public bool Worklist
      {
         get
         {
            return worklist;
         }
         
         set
         {
            if (value != this.worklist)
            {
               this.worklist = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public bool Revocation
      {
         get
         {
            return revocation;
         }

         set
         {
            if (value != this.revocation)
            {
               this.revocation = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public bool Strategy
      {
         get
         {
            return strategy;
         }
         
         set
         {
            if (value != this.strategy)
            {
               this.strategy = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public bool DecisionTree
      {
         get
         {
            return decisionTree;
         }
         
         set
         {
            if (value != this.decisionTree)
            {
               this.decisionTree = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public string CategoryDesc
      {
         get
         {
            return categoryDesc;
         }
         
         set
         {
            if (value != this.categoryDesc)
            {
               this.categoryDesc = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public bool IsCustomerLevel
      {
         get
         {
            return isCustomerLevel;
         }
         
         set
         {
            if (value != this.isCustomerLevel)
            {
               this.isCustomerLevel = value;
               NotifyPropertyChanged();
            }
         }
      }
      [Category(QConsts.CategoryRequired)]
      public bool ClosedCases
      {
         get
         {
            return closedCases;
         }
         
         set
         {
            if (value != this.closedCases)
            {
               this.closedCases = value;
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

      [Category(QConsts.CategoryInherited)]
      public string CriUniqueId
      {
         get
         {
            return criUniqueId;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string CriTable
      {
         get
         {
            return criTable;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string CriFields
      {
         get
         {
            return criFields;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string CriWhere
      {
         get
         {
            return criWhere;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string CrjCode
      {
         get
         {
            return crjCode;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string CrjJoin
      {
         get
         {
            return crjJoin;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string CriWhereTable
      {
         get
         {
            return criWhereTable;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string CriWhereField
      {
         get
         {
            return criWhereField;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string CriWhereShow
      {
         get
         {
            return criWhereShow;
         }
      }
      [Category(QConsts.CategoryInherited)]
      public string CriWhereFieldSqlType
      {
         get
         {
            return criWhereFieldSqlType;
         }
      }

      

      #endregion



      public QAddCriterioCR()
      {
         
      }

      #region methods
      public bool CanBeScripted()
      {
         return CheckResultType == QCRCheckResultType.WellImplemented;
      }

      public string GetScripted()
      {
         string retval = "";
         if(string.IsNullOrEmpty(name))
         {
            throw new Exception("Name is empty!");
         }
         if(databaseName.IsInvalid())
         {
            throw new Exception("Invalid database name!");
         }
         if(!CanBeScripted())
         {
            throw new Exception("Criterio cannot be scripted!Run Check.");
         }
         QDatabase db = QInstance.Environments.GetDatabase(DatabaseName);
         try
         {
            SqlCommand command = new SqlCommand("Man_ScriptCriterion_PerInstallation");
            db.Connection.InfoMessage += Connection_InfoMessage;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@cri_unique_id", SqlDbType.NVarChar, 255).Value = CriUniqueId;
            command.Parameters.Add("@inst_codes", SqlDbType.NVarChar, 1000).Value = InstallationCode;
            connectionMsg.Clear();
            object ret = db.ExecuteScalar(command);
         }
         finally
         {
            db.Connection.InfoMessage -= Connection_InfoMessage;
         }

         return connectionMsg.ToString();

      }

      private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
      {
         connectionMsg.AppendLine(e.Message);
      }

      private void SetFlags(bool value)
      {
         queues = value;
         dynamicQueues = value;
         worklist = value;
         revocation = value;
         strategy = value;
         decisionTree = value;
   }

      public override bool Validate(out Dictionary<string, string> errors)
      {
         errors = new Dictionary<string, string>();
         if (string.IsNullOrEmpty(Name))
            errors.Add(nameof(Name), "Criterio name is mandatory.");
         if (criterioType==QCriterioType.Unspecified)
            errors.Add(nameof(CriterioType), "Criterio type is mandatory.");
         if (string.IsNullOrEmpty(categoryDesc))
            errors.Add(nameof(CategoryDesc), "Category is mandatory.");
         if (DatabaseName.IsInvalid())
            errors.Add(nameof(DatabaseName), "Check DatabaseName.");

         return errors.Count == 0;
      }

      public override void CopyState(object source)
      {
         if (source is QAddCriterioCR)
         {
            QAddCriterioCR cr = (QAddCriterioCR)source;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cr.Serialize());
            Deserialize(doc.DocumentElement);
         }

      }
      public override object Clone()
      {
         QAddCriterioCR retval = new QAddCriterioCR()
         {
            // input fields
            InstallationCode = this.installationCode,
            DatabaseName = this.databaseName,
            Name = this.name,
            CriterioType = this.criterioType,
            Queues = this.queues,
            DynamicQueues = this.dynamicQueues,
            Worklist = this.worklist,
            Revocation = this.revocation,
            Strategy=this.strategy,
            DecisionTree = this.decisionTree,
            CategoryDesc =  this.categoryDesc,
            IsCustomerLevel = this.isCustomerLevel,
            ClosedCases = this.closedCases,
            Parent = this.Parent,

            // output fields
            criUniqueId = this.criUniqueId,
            criTable = this.criTable,
            criFields = this.criFields,
            criWhere = this.criWhere,
            crjCode = this.crjCode,
            crjJoin = this.crjJoin,
            criWhereTable = this.criWhereTable,
            criWhereField = this.criWhereField,
            criWhereShow = this.criWhereShow,
            criWhereFieldSqlType = this.criWhereFieldSqlType
         };
         return retval;

      }

      protected override void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
      {
         base.NotifyPropertyChanged(propertyName);
         if (propertyName == nameof(Name))
         {
            NotifyPropertyChanged(nameof(Description));
         }
      }

      
      private SqlCommand GetCriterioCommand()
      {
         string sql = @"SELECT LOV.LOV_DESC CATEGORY_DESC, CRJ.CRJ_JOIN, CRI.* FROM AT_CRITERIA CRI 
                        LEFT JOIN VW_AT_LST_OF_VAL LOV 
                        ON CRI.CRI_CATEGORY = LOV.LOV_CODE AND LOV.LOV_TYPE ='CRITERIA_CATEGORIES' AND LOV.LOV_CODE=CRI.CRI_CATEGORY
                        LEFT JOIN AT_CRITERIA_JOINS CRJ 
                        ON CRJ.CRJ_CODE = CRI.CRJ_CODE
                        WHERE CRI.CRI_DESC = @name";
         SqlCommand command = new SqlCommand(sql);

         command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;

         return command;
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
            w.WriteAttributeString("installationcode", installationCode.ToString());
            w.WriteAttributeString("databasename", databaseName.ToString());
            w.WriteAttributeString("name", name);
            w.WriteAttributeString("criteriotype", criterioType.ToString());
            w.WriteAttributeString("queues", queues.ToString());
            w.WriteAttributeString("dynamicqueues", dynamicQueues.ToString());
            w.WriteAttributeString("worklist", worklist.ToString());
            w.WriteAttributeString("revocation", revocation.ToString());
            w.WriteAttributeString("strategy", strategy.ToString());
            w.WriteAttributeString("decisiontree", decisionTree.ToString());
            w.WriteAttributeString("categorydesc", categoryDesc.ToString());
            w.WriteAttributeString("iscustomerlevel", isCustomerLevel.ToString());
            w.WriteAttributeString("closedcases", closedCases.ToString());

            w.WriteEndElement();
            w.Flush();
         }
         return sb.ToString();

      }

      public override void Deserialize(XmlNode Node)
      {
         base.Deserialize(Node);
         InstallationCode = Node.ReadInt("installationcode", 0);
         DatabaseName.FromString(Node.ReadString("databasename", ""));
         Name = Node.ReadString("name");
         CriterioType = Node.ReadEnum<QCriterioType>("criteriotype");
         Queues = Node.ReadBool("queues");
         DynamicQueues = Node.ReadBool("dynamicqueues");
         Worklist = Node.ReadBool("worklist");
         Revocation = Node.ReadBool("revocation");
         Strategy = Node.ReadBool("strategy");
         DecisionTree = Node.ReadBool("decisiontree");
         CategoryDesc = Node.ReadString("categorydesc");
         IsCustomerLevel = Node.ReadBool("iscustomerlevel");
         closedCases = Node.ReadBool("closedcases");

      }

      #endregion

      #region checks
      public override bool Check()
      {
         bool result = true;
         Actions.Clear();

         result = CheckRec() && result;
         NotifyPropertyChanged(nameof(CheckResultType));
         return result;

      }

      private bool CheckSpecValue(object specValue, object dbValue, string valueName) 
      {
         bool retval = true;
         if (!specValue.Equals(dbValue))
         {
            QCRAction check = new QCRAction()
            {
               State = QCRActionState.NeedsAction,
               ActionType = QCRActionType.CheckCriterio,
               Description = string.Format("Specification mismatch: Specification of \"{0}\" \"{1}\" does not match to implemented \"{2}\"", valueName, specValue, dbValue),
               DatabaseName = this.DatabaseName
            };
            Actions.Add(check);
            retval = false;
         }
         return retval;

      }

      private bool CheckRec()
      {
         bool retval = true;
         try
         {
            QDatabase database = QInstance.Environments.GetDatabase(DatabaseName);
            // first check if the field ui record exists 
            DataTable tbRec = database.ExecuteCommand(GetCriterioCommand());
            if (tbRec.Rows.Count == 0)
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.NeedsAction,
                  ActionType = QCRActionType.AddCriterio,
                  Description = string.Format("Add criterio \"{0}\".", Name),
                  DatabaseName = this.DatabaseName
               };
               Actions.Add(check);
               retval = false;
            }
            else if (tbRec.Rows.Count == 1)
            {
               QCriterioType tmpCriterioType = (QCriterioType)Convert.ToInt32(tbRec.Rows[0]["CRI_TYPE"]);
               bool tmpQueues = (bool)tbRec.Rows[0]["CRI_QUEUE"];
               bool tmpDynamicQueues = (bool)tbRec.Rows[0]["CRI_DYNAMIC_QUEUE"];
               bool tmpWorklist = (bool)tbRec.Rows[0]["CRI_WORKLIST"];
               bool tmpRevocation = (bool)tbRec.Rows[0]["CRI_REVOCATION"];
               bool tmpStrategy = (bool)tbRec.Rows[0]["CRI_STRATEGY"];
               bool tmpDecisionTree = (bool)tbRec.Rows[0]["CRI_DECISION_TREE"];
               string tmpCategoryDesc = (string)tbRec.Rows[0]["CATEGORY_DESC"]; 
               bool tmpIsCustomerLevel = (bool)tbRec.Rows[0]["CRI_IS_CUSTOMER_LEVEL"];
               bool tmpClosedCases = (bool)tbRec.Rows[0]["CRI_CLOSED_CASES"];
               retval = CheckSpecValue(CriterioType, tmpCriterioType, "Criterio Type") && retval;
               retval = CheckSpecValue(Queues, tmpQueues, "Queues") && retval;
               retval = CheckSpecValue(DynamicQueues, tmpDynamicQueues, "DynamicQueues") && retval;
               retval = CheckSpecValue(Revocation, tmpRevocation, "Revocation") && retval;
               retval = CheckSpecValue(Strategy, tmpStrategy, "Strategy") && retval;
               retval = CheckSpecValue(DecisionTree, tmpDecisionTree, "DecisionTree") && retval;
               retval = CheckSpecValue(CategoryDesc, tmpCategoryDesc, "CategoryDesc") && retval;
               retval = CheckSpecValue(IsCustomerLevel, tmpIsCustomerLevel, "IsCustomerLevel") && retval;
               retval = CheckSpecValue(ClosedCases, tmpClosedCases, "ClosedCases") && retval;

               // set output fields
               criUniqueId= (string)tbRec.Rows[0]["CRI_UNIQUE_ID"];
               criTable = (string)tbRec.Rows[0]["CRI_TABLE"];
               criFields = (string)tbRec.Rows[0]["CRI_FIELDS"];
               criWhere = (string)tbRec.Rows[0]["CRI_WHERE"];
               crjCode = Convert.ToString(tbRec.Rows[0]["CRJ_CODE"]);
               crjJoin = (string)tbRec.Rows[0]["CRJ_JOIN"];
               criWhereTable = (string)tbRec.Rows[0]["CRI_WHERE_TABLE"];
               criWhereField = (string)tbRec.Rows[0]["CRI_WHERE_FIELD"];
               criWhereShow = (string)tbRec.Rows[0]["CRI_WHERE_SHOW"];
               criWhereFieldSqlType = (string)tbRec.Rows[0]["CRI_WHERE_FIELD_SQL_TYPE"];
            }
            else if (tbRec.Rows.Count > 1)
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.NeedsAction,
                  ActionType = QCRActionType.AddCriterio,
                  Description = string.Format("Found more than one criteria \"{0}\".", Name),
                  DatabaseName = this.DatabaseName
               };
               Actions.Add(check);
               retval = false;
            }
            
            // everything ok
            if (Actions.Count==0)
            {
               QCRAction check = new QCRAction()
               {
                  State = QCRActionState.WellImplemented,
                  ActionType = QCRActionType.AddCriterio,
                  Description = string.Format("Add criterio \"{0}\".", Name),
                  DatabaseName = this.DatabaseName
               };
               Actions.Add(check);
               retval = true;
            }


         }
         catch (Exception ex)
         {
            QCRAction check = new QCRAction()
            {
               State = QCRActionState.NeedsAction,
               ActionType = QCRActionType.AddCriterio,
               Description = string.Format(ex.Message),
               DatabaseName = this.DatabaseName
            };
            Actions.Add(check);
            retval = false;
         }
         return retval;
      }
   }

      #endregion
   }
