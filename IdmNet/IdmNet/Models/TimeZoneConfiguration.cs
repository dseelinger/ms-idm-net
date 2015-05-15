using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// TimeZoneConfiguration - This resource defines a supported timezone in FIM Portal.
    /// </summary>
    public class TimeZoneConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public TimeZoneConfiguration()
        {
            ObjectType = ForcedObjType = "TimeZoneConfiguration";
        }

        /// <summary>
        /// Build a TimeZoneConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public TimeZoneConfiguration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "TimeZoneConfiguration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be TimeZoneConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of TimeZoneConfiguration can only be 'TimeZoneConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Time Zone Id - .Net equivalent timezone id
        /// </summary>
        [Required]
        public string TimeZoneId
        {
            get { return GetAttrValue("TimeZoneId"); }
            set {
                SetAttrValue("TimeZoneId", value); 
            }
        }


    }
}
