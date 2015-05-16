using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// AttributeTypeDescription - This describes an attribute type.
    /// </summary>
    public class AttributeTypeDescription : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public AttributeTypeDescription()
        {
            ObjectType = ForcedObjType = "AttributeTypeDescription";
        }

        /// <summary>
        /// Build a AttributeTypeDescription object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public AttributeTypeDescription(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "AttributeTypeDescription";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be AttributeTypeDescription)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of AttributeTypeDescription can only be 'AttributeTypeDescription'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Data Type - 
        /// </summary>
        [Required]
        public string DataType
        {
            get { return GetAttrValue("DataType"); }
            set {
                SetAttrValue("DataType", value); 
            }
        }


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
        /// Multivalued - 
        /// </summary>
        [Required]
        public bool Multivalued
        {
            get { return AttrToBool("Multivalued"); }
            set { 
                SetAttrValue("Multivalued", value.ToString());
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
