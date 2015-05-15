using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// msidmSystemConfiguration - Common configuration settings across all FIM Service instances.
    /// </summary>
    public class msidmSystemConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public msidmSystemConfiguration()
        {
            ObjectType = ForcedObjType = "msidmSystemConfiguration";
        }

        /// <summary>
        /// Build a msidmSystemConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public msidmSystemConfiguration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "msidmSystemConfiguration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be msidmSystemConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of msidmSystemConfiguration can only be 'msidmSystemConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Create Criteria-based Groups as Deferred By Default - If this setting is set to true then any criteria-based group that will be created in the system while it is true will be marked for deferred evaluation.
        /// </summary>
        public bool? msidmCreateCriteriaBasedGroupsAsDeferredByDefault
        {
            get { return AttrToBool("msidmCreateCriteriaBasedGroupsAsDeferredByDefault"); }
            set { 
                SetAttrValue("msidmCreateCriteriaBasedGroupsAsDeferredByDefault", value.ToString());
            }
        }


        /// <summary>
        /// Is Configuration Type - This value specified whether or not the resource is a configuration resource.
        /// </summary>
        [Required]
        public bool? IsConfigurationType
        {
            get { return AttrToBool("IsConfigurationType"); }
            set { 
                SetAttrValue("IsConfigurationType", value.ToString());
            }
        }


        /// <summary>
        /// Reporting Logging Enabled - This is a global setting that controls whether service activity is logged for reporting purposes.
        /// </summary>
        [Required]
        public bool? msidmReportingLoggingEnabled
        {
            get { return AttrToBool("msidmReportingLoggingEnabled"); }
            set { 
                SetAttrValue("msidmReportingLoggingEnabled", value.ToString());
            }
        }


        /// <summary>
        /// Request Maximum Active Duration - Requests that exceed this duration before reaching a final state will be automatically canceled by the system. Value defined in days.
        /// </summary>
        [Required]
        public int? msidmRequestMaximumActiveDuration
        {
            get { return AttrToInteger("msidmRequestMaximumActiveDuration"); }
            set { 
                SetAttrValue("msidmRequestMaximumActiveDuration", value.ToString());
            }
        }


        /// <summary>
        /// Request Maximum Canceling Duration - Maximum duration a request can be in the Canceling state before the system auto terminates it. Value defined in days.
        /// </summary>
        [Required]
        public int? msidmRequestMaximumCancelingDuration
        {
            get { return AttrToInteger("msidmRequestMaximumCancelingDuration"); }
            set { 
                SetAttrValue("msidmRequestMaximumCancelingDuration", value.ToString());
            }
        }


        /// <summary>
        /// System Throttle Level - Increasing this number will allocate more system resources to process outstanding workloads. Setting the value to -1 will disable the system resource throttling.
        /// </summary>
        [Required]
        public int? msidmSystemThrottleLevel
        {
            get { return AttrToInteger("msidmSystemThrottleLevel"); }
            set { 
                SetAttrValue("msidmSystemThrottleLevel", value.ToString());
            }
        }


    }
}
