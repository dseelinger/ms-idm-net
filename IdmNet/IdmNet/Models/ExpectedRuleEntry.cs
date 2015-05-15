using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// ExpectedRuleEntry - This resource is created by the Synchronization Rule Activity, and represents a specific Synchronization Rule that is to be added to or removed from a target resource.
    /// </summary>
    public class ExpectedRuleEntry : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ExpectedRuleEntry()
        {
            ObjectType = ForcedObjType = "ExpectedRuleEntry";
        }

        /// <summary>
        /// Build a ExpectedRuleEntry object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public ExpectedRuleEntry(IdmResource resource)
        {
            ObjectType = ForcedObjType = "ExpectedRuleEntry";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be ExpectedRuleEntry)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of ExpectedRuleEntry can only be 'ExpectedRuleEntry'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Expected Rule Entry Action - Indicates whether to apply or stop applying a sync rule.
        /// </summary>
        [Required]
        public string ExpectedRuleEntryAction
        {
            get { return GetAttrValue("ExpectedRuleEntryAction"); }
            set {
                SetAttrValue("ExpectedRuleEntryAction", value); 
            }
        }


        /// <summary>
        /// Resource Parent - This is a reference to the container resource.
        /// </summary>
        public IdmResource ResourceParent
        {
            get { return GetAttr("ResourceParent", _theResourceParent); }
            set 
            { 
                _theResourceParent = value;
                SetAttrValue("ResourceParent", ObjectIdOrNull(value)); 
            }
        }
        private IdmResource _theResourceParent;


        /// <summary>
        /// Status Error - Sync rule error details upon failure.
        /// </summary>
        public string StatusError
        {
            get { return GetAttrValue("StatusError"); }
            set {
                SetAttrValue("StatusError", value); 
            }
        }


        /// <summary>
        /// Synchronization Rule Data - Xml describing the values of workflow parameters.
        /// </summary>
        public List<string> SynchronizationRuleData
        {
            get { return GetAttrValues("SynchronizationRuleData"); }
            set {
                SetAttrValues("SynchronizationRuleData", value); 
            }
        }


        /// <summary>
        /// Synchronization Rule ID - This is a reference to a SynchronizationRule resource.
        /// </summary>
        public SynchronizationRule SynchronizationRuleID
        {
            get { return GetAttr("SynchronizationRuleID", _theSynchronizationRuleID); }
            set 
            { 
                _theSynchronizationRuleID = value;
                SetAttrValue("SynchronizationRuleID", ObjectIdOrNull(value)); 
            }
        }
        private SynchronizationRule _theSynchronizationRuleID;


        /// <summary>
        /// Synchronization Rule Name - This is the name of a SynchronizationRule
        /// </summary>
        [Required]
        public string SynchronizationRuleName
        {
            get { return GetAttrValue("SynchronizationRuleName"); }
            set {
                SetAttrValue("SynchronizationRuleName", value); 
            }
        }


        /// <summary>
        /// Synchronization Rule Status - Indicates Applied, Not Applied, or Pending.
        /// </summary>
        [Required]
        public string SynchronizationRuleStatus
        {
            get { return GetAttrValue("SynchronizationRuleStatus"); }
            set {
                SetAttrValue("SynchronizationRuleStatus", value); 
            }
        }


    }
}
