using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// BindingDescription - This resource describes the relationship between a resource type and an attribute type.
    /// </summary>
    public class BindingDescription : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public BindingDescription()
        {
            ObjectType = ForcedObjType = "BindingDescription";
        }

        /// <summary>
        /// Build a BindingDescription object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public BindingDescription(IdmResource resource)
        {
            ObjectType = ForcedObjType = "BindingDescription";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be BindingDescription)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of BindingDescription can only be 'BindingDescription'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Attribute Is Required - 
        /// </summary>
        public bool? Required
        {
            get { return AttrToNullableBool("Required"); }
            set { 
                SetAttrValue("Required", value.ToString());
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
        /// Integer Maximum - For an Integer attribute, this is the maximum value, inclusive.
        /// </summary>
        public int? IntegerMaximum
        {
            get { return AttrToNullableInteger("IntegerMaximum"); }
            set { 
                SetAttrValue("IntegerMaximum", value.ToString());
            }
        }


        /// <summary>
        /// Integer Minimum - For an Integer attribute, this is the minimum value, inclusive.
        /// </summary>
        public int? IntegerMinimum
        {
            get { return AttrToNullableInteger("IntegerMinimum"); }
            set { 
                SetAttrValue("IntegerMinimum", value.ToString());
            }
        }


        /// <summary>
        /// Localizable - A true indicates this attribute can be localized.  Only allowed for String DataTypes.
        /// </summary>
        public bool? Localizable
        {
            get { return AttrToNullableBool("Localizable"); }
            set { 
                SetAttrValue("Localizable", value.ToString());
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


        /// <summary>
        /// String Regular Expression - This is a .Net Regex pattern that defines what string values are allowed.
        /// </summary>
        public string StringRegex
        {
            get { return GetAttrValue("StringRegex"); }
            set {
                SetAttrValue("StringRegex", value); 
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
