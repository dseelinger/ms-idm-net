using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// SynchronizationFilter - This resource defines a list of properties that can be synced on a certain resource type.
    /// </summary>
    public class SynchronizationFilter : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public SynchronizationFilter()
        {
            ObjectType = ForcedObjType = "SynchronizationFilter";
        }

        /// <summary>
        /// Build a SynchronizationFilter object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public SynchronizationFilter(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "SynchronizationFilter";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be SynchronizationFilter)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of SynchronizationFilter can only be 'SynchronizationFilter'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Synchronize ObjectTypeDescription - The list of resource types that are allowed to be synced.
        /// </summary>
        public List<ObjectTypeDescription> SynchronizeObjectType
        {
            get { return GetMultiValuedAttr("SynchronizeObjectType", _theSynchronizeObjectType); }
            set { SetMultiValuedAttr("SynchronizeObjectType", out _theSynchronizeObjectType, value); }
        }
        private List<ObjectTypeDescription> _theSynchronizeObjectType;


    }
}
