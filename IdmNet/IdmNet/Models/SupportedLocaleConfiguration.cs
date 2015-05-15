using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// SupportedLocaleConfiguration - This resource defines a list of supported languages in FIM Portal. There exists only one instance of this resource type in FIM Portal deployment.
    /// </summary>
    public class SupportedLocaleConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public SupportedLocaleConfiguration()
        {
            ObjectType = ForcedObjType = "SupportedLocaleConfiguration";
        }

        /// <summary>
        /// Build a SupportedLocaleConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public SupportedLocaleConfiguration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "SupportedLocaleConfiguration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be SupportedLocaleConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of SupportedLocaleConfiguration can only be 'SupportedLocaleConfiguration'");
                SetAttrValue("ObjectType", value);
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
        /// Supported Language Code - This attribute lists language codes for all supported locales in FIM Portal.
        /// </summary>
        [Required]
        public List<string> SupportedLanguageCode
        {
            get { return GetAttrValues("SupportedLanguageCode"); }
            set {
                SetAttrValues("SupportedLanguageCode", value); 
            }
        }


    }
}
