using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// DetectedRuleEntry - This resources is created and added to Detected Rules List of a resource when the existence flows for a Synchronization Rule are confirmed to exist within the external system. 
    /// </summary>
    public class DetectedRuleEntry : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public DetectedRuleEntry()
        {
            ObjectType = ForcedObjType = "DetectedRuleEntry";
        }

        /// <summary>
        /// Build a DetectedRuleEntry object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public DetectedRuleEntry(IdmResource resource)
        {
            ObjectType = ForcedObjType = "DetectedRuleEntry";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be DetectedRuleEntry)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of DetectedRuleEntry can only be 'DetectedRuleEntry'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Connector - The resource id of the connector space resource that this DRE was created for.
        /// </summary>
        [Required]
        public string Connector
        {
            get { return GetAttrValue("Connector"); }
            set {
                SetAttrValue("Connector", value); 
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


    }
}
