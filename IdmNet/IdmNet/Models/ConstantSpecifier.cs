using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// ConstantSpecifier - This resource can be used by user to specify localized strings for FIM enumeration strings.
    /// </summary>
    public class ConstantSpecifier : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ConstantSpecifier()
        {
            ObjectType = ForcedObjType = "ConstantSpecifier";
        }

        /// <summary>
        /// Build a ConstantSpecifier object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public ConstantSpecifier(IdmResource resource)
        {
            ObjectType = ForcedObjType = "ConstantSpecifier";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be ConstantSpecifier)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of ConstantSpecifier can only be 'ConstantSpecifier'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Attribute Type - The binding's attribute type
        /// </summary>
        public AttributeTypeDescription BoundAttributeType
        {
            get { return GetAttr("BoundAttributeType", _theBoundAttributeType); }
            set 
            { 
                _theBoundAttributeType = value;
                SetAttrValue("BoundAttributeType", ObjectIdOrNull(value)); 
            }
        }
        private AttributeTypeDescription _theBoundAttributeType;


        /// <summary>
        /// Constant Value Key - It is a the constant key value.
        /// </summary>
        [Required]
        public string ConstantValueKey
        {
            get { return GetAttrValue("ConstantValueKey"); }
            set {
                SetAttrValue("ConstantValueKey", value); 
            }
        }


        /// <summary>
        /// Resource Type - The binding's resource type
        /// </summary>
        public ObjectTypeDescription BoundObjectType
        {
            get { return GetAttr("BoundObjectType", _theBoundObjectType); }
            set 
            { 
                _theBoundObjectType = value;
                SetAttrValue("BoundObjectType", ObjectIdOrNull(value)); 
            }
        }
        private ObjectTypeDescription _theBoundObjectType;


    }
}
