using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Configuration - This is used for user to specify the configuration for each application.
    /// </summary>
    public class Configuration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public Configuration()
        {
            ObjectType = ForcedObjType = "Configuration";
        }

        /// <summary>
        /// Build a Configuration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public Configuration(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "Configuration";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be Configuration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of Configuration can only be 'Configuration'");
                SetAttrValue("ObjectType", value);
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


    }
}
