using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Resource - This is the base resource type. The attributes bound to this resource type appears in all resources.
    /// </summary>
    public class Resource : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public Resource()
        {
            ObjectType = ForcedObjType = "Resource";
        }

        /// <summary>
        /// Build a Resource object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public Resource(IdmResource resource)
        {
            ObjectType = ForcedObjType = "Resource";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be Resource)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of Resource can only be 'Resource'");
                SetAttrValue("ObjectType", value);
            }
        }

    }
}
