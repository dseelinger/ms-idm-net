using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// ObjectTypeDescription - This describes a resource type.
    /// </summary>
    public class ObjectTypeDescription : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ObjectTypeDescription()
        {
            ObjectType = ForcedObjType = "ObjectTypeDescription";
        }

        /// <summary>
        /// Build a ObjectTypeDescription object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public ObjectTypeDescription(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "ObjectTypeDescription";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be ObjectTypeDescription)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of ObjectTypeDescription can only be 'ObjectTypeDescription'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Name - 
        /// </summary>
        [Required]
        public string Name
        {
            get { return GetAttrValue("Name"); }
            set {
                SetAttrValue("Name", value); 
            }
        }


        /// <summary>
        /// Usage Keyword - 
        /// </summary>
        public List<string> UsageKeyword
        {
            get { return GetAttrValues("UsageKeyword"); }
            set {
                SetAttrValues("UsageKeyword", value); 
            }
        }


    }
}
