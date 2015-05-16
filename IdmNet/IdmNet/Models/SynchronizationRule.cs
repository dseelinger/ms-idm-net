using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// SynchronizationRule - This resource defines synchronization behavior between FIM resources and resources in external systems.
    /// </summary>
    public class SynchronizationRule : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public SynchronizationRule()
        {
            ObjectType = ForcedObjType = "SynchronizationRule";
        }

        /// <summary>
        /// Build a SynchronizationRule object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public SynchronizationRule(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "SynchronizationRule";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be SynchronizationRule)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of SynchronizationRule can only be 'SynchronizationRule'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Create External System Resource - Indicates if an external system resource is created if the relationship criteria is not met.
        /// </summary>
        [Required]
        public bool CreateConnectedSystemObject
        {
            get { return AttrToBool("CreateConnectedSystemObject"); }
            set { 
                SetAttrValue("CreateConnectedSystemObject", value.ToString());
            }
        }


        /// <summary>
        /// Create FIM Resource - Indicates if a resource should be created in FIM if the relationship criteria is not met.
        /// </summary>
        [Required]
        public bool CreateILMObject
        {
            get { return AttrToBool("CreateILMObject"); }
            set { 
                SetAttrValue("CreateILMObject", value.ToString());
            }
        }


        /// <summary>
        /// Data Flow Direction - A Synchronization Rule can be defined as inbound (0), outbound (1) or bi-directional (2).
        /// </summary>
        [Required]
        public int FlowType
        {
            get { return AttrToInteger("FlowType"); }
            set { 
                SetAttrValue("FlowType", value.ToString());
            }
        }


        /// <summary>
        /// Dependency - A Synchronization Rule that must be applied to a resource before this Synchronization Rule can be applied.
        /// </summary>
        public SynchronizationRule Dependency
        {
            get { return GetAttr("Dependency", _theDependency); }
            set 
            { 
                _theDependency = value;
                SetAttrValue("Dependency", ObjectIdOrNull(value)); 
            }
        }
        private SynchronizationRule _theDependency;


        /// <summary>
        /// Disconnect External System Resource - This option applies when this Synchronization Rule is removed from a resource in FIM.
        /// </summary>
        [Required]
        public bool DisconnectConnectedSystemObject
        {
            get { return AttrToBool("DisconnectConnectedSystemObject"); }
            set { 
                SetAttrValue("DisconnectConnectedSystemObject", value.ToString());
            }
        }


        /// <summary>
        /// Existence Test - Outbound attribute flows within a transformation marked as an existence tests for the Synchronization Rule.
        /// </summary>
        public List<string> ExistenceTest
        {
            get { return GetAttrValues("ExistenceTest"); }
            set {
                SetAttrValues("ExistenceTest", value); 
            }
        }


        /// <summary>
        /// External System - The Management Agent identifying the external system this Synchronization Rule will operate on.
        /// </summary>
        [Required]
        public string ConnectedSystem
        {
            get { return GetAttrValue("ConnectedSystem"); }
            set {
                SetAttrValue("ConnectedSystem", value); 
            }
        }


        /// <summary>
        /// External System Resource Type - The resource type in the external system that this Synchronization Rule applies to.
        /// </summary>
        [Required]
        public string ConnectedObjectType
        {
            get { return GetAttrValue("ConnectedObjectType"); }
            set {
                SetAttrValue("ConnectedObjectType", value); 
            }
        }


        /// <summary>
        /// External System Scoping Filter - A filter representing the resources on the external system that the rule applies to.
        /// </summary>
        public string ConnectedSystemScope
        {
            get { return GetAttrValue("ConnectedSystemScope"); }
            set {
                SetAttrValue("ConnectedSystemScope", value); 
            }
        }


        /// <summary>
        /// FIM Resource Type - The resource type in the FIM Metaverse that this Synchronization Rule applies to.
        /// </summary>
        [Required]
        public string ILMObjectType
        {
            get { return GetAttrValue("ILMObjectType"); }
            set {
                SetAttrValue("ILMObjectType", value); 
            }
        }


        /// <summary>
        /// Initial Flow - A series of outbound flows between FIM and external systems.  These flows are only executed upon creation of a new resource.
        /// </summary>
        public List<string> InitialFlow
        {
            get { return GetAttrValues("InitialFlow"); }
            set {
                SetAttrValues("InitialFlow", value); 
            }
        }


        /// <summary>
        /// Management Agent ID - Description:  The Management Agent identifying the external system this Synchronization Rule will operate on.
        /// </summary>
        public ma_data ManagementAgentID
        {
            get { return GetAttr("ManagementAgentID", _theManagementAgentID); }
            set 
            { 
                _theManagementAgentID = value;
                SetAttrValue("ManagementAgentID", ObjectIdOrNull(value)); 
            }
        }
        private ma_data _theManagementAgentID;


        /// <summary>
        /// Outbound Scope Filter Based - Determines how the synchronization rule is applied to existing resources.
        /// </summary>
        public bool? msidmOutboundIsFilterBased
        {
            get { return AttrToNullableBool("msidmOutboundIsFilterBased"); }
            set { 
                SetAttrValue("msidmOutboundIsFilterBased", value.ToString());
            }
        }


        /// <summary>
        /// Outbound Scoping Filters - A filter representing the resources on the FIM metaverse that the rule applies to.
        /// </summary>
        public string msidmOutboundScopingFilters
        {
            get { return GetAttrValue("msidmOutboundScopingFilters"); }
            set {
                SetAttrValue("msidmOutboundScopingFilters", value); 
            }
        }


        /// <summary>
        /// Persistent Flow - A series of attribute flow definitions.
        /// </summary>
        public List<string> PersistentFlow
        {
            get { return GetAttrValues("PersistentFlow"); }
            set {
                SetAttrValues("PersistentFlow", value); 
            }
        }


        /// <summary>
        /// Precedence - A number indicating the Synchronization Rule's precedence relative to all other Synchronization Rules that apply to the same external system.  A smaller number represents a higher precedence.
        /// </summary>
        public int? Precedence
        {
            get { return AttrToNullableInteger("Precedence"); }
            set { 
                SetAttrValue("Precedence", value.ToString());
            }
        }


        /// <summary>
        /// Relationship Criteria - Defines how a relationship between a resource in FIM and a resource in an external system is detected.
        /// </summary>
        [Required]
        public string RelationshipCriteria
        {
            get { return GetAttrValue("RelationshipCriteria"); }
            set {
                SetAttrValue("RelationshipCriteria", value); 
            }
        }


        /// <summary>
        /// Synchronization Rule Parameters - These are parameters which require values to be provided from the workflow that adds the Synchronization Rule to a resource.
        /// </summary>
        public List<string> SynchronizationRuleParameters
        {
            get { return GetAttrValues("SynchronizationRuleParameters"); }
            set {
                SetAttrValues("SynchronizationRuleParameters", value); 
            }
        }


    }
}
