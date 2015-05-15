using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// ObjectVisualizationConfiguration - This resource drives the detailed appearance of a resource in FIM Portal.
    /// </summary>
    public class ObjectVisualizationConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ObjectVisualizationConfiguration()
        {
            ObjectType = ForcedObjType = "ObjectVisualizationConfiguration";
        }

        /// <summary>
        /// Build a ObjectVisualizationConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public ObjectVisualizationConfiguration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "ObjectVisualizationConfiguration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be ObjectVisualizationConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of ObjectVisualizationConfiguration can only be 'ObjectVisualizationConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Applies to Create - The configuration applies to create mode of the target resource type
        /// </summary>
        [Required]
        public bool? AppliesToCreate
        {
            get { return AttrToBool("AppliesToCreate"); }
            set { 
                SetAttrValue("AppliesToCreate", value.ToString());
            }
        }


        /// <summary>
        /// Applies to Edit - The configuration applies to edit mode of the target resource type
        /// </summary>
        [Required]
        public bool? AppliesToEdit
        {
            get { return AttrToBool("AppliesToEdit"); }
            set { 
                SetAttrValue("AppliesToEdit", value.ToString());
            }
        }


        /// <summary>
        /// Applies to View - The configuration applies to view mode of the target resource type
        /// </summary>
        [Required]
        public bool? AppliesToView
        {
            get { return AttrToBool("AppliesToView"); }
            set { 
                SetAttrValue("AppliesToView", value.ToString());
            }
        }


        /// <summary>
        /// Configuration Data - It is a configurationData type.
        /// </summary>
        [Required]
        public string ConfigurationData
        {
            get { return GetAttrValue("ConfigurationData"); }
            set {
                SetAttrValue("ConfigurationData", value); 
            }
        }


        /// <summary>
        /// Is Configuration Type - This is an indication that this resource is a configuration resource.
        /// </summary>
        public bool? IsConfigurationType
        {
            get { return AttrToBool("IsConfigurationType"); }
            set { 
                SetAttrValue("IsConfigurationType", value.ToString());
            }
        }


        /// <summary>
        /// String Resources - This attribute contains the localized value of the string resources for the selected language.
        /// </summary>
        public string StringResources
        {
            get { return GetAttrValue("StringResources"); }
            set {
                SetAttrValue("StringResources", value); 
            }
        }


        /// <summary>
        /// Target Resource Type - Which resource type this configuration applies to
        /// </summary>
        [Required]
        public string TargetObjectType
        {
            get { return GetAttrValue("TargetObjectType"); }
            set {
                SetAttrValue("TargetObjectType", value); 
            }
        }


    }
}
