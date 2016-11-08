using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// SystemResourceRetentionConfiguration - This resource is used for controlling how long completed requests and workflow instances are retained before becoming available only through historical query.
    /// </summary>
    public class SystemResourceRetentionConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public SystemResourceRetentionConfiguration()
        {
            ObjectType = ForcedObjType = "SystemResourceRetentionConfiguration";
        }

        /// <summary>
        /// Build a SystemResourceRetentionConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public SystemResourceRetentionConfiguration(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "SystemResourceRetentionConfiguration";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be SystemResourceRetentionConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of SystemResourceRetentionConfiguration can only be 'SystemResourceRetentionConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Retention Period in Days - The number of days after completion a Request, Approval, Approval Response or Workflow Instance is retained before being deleted.
        /// </summary>
        [Required]
        public int RetentionPeriod
        {
            get { return AttrToInteger("RetentionPeriod"); }
            set { 
                SetAttrValue("RetentionPeriod", value.ToString());
            }
        }


    }
}
