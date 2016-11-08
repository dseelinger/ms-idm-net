using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// msidmReportingJob - This resource describes a reporting job object type.  These objects are used to store data about Reporting ETL processes that are occurring between FIM and the System Center Management Server.
    /// </summary>
    public class msidmReportingJob : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public msidmReportingJob()
        {
            ObjectType = ForcedObjType = "msidmReportingJob";
        }

        /// <summary>
        /// Build a msidmReportingJob object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public msidmReportingJob(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "msidmReportingJob";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be msidmReportingJob)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of msidmReportingJob can only be 'msidmReportingJob'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Completed Time - The time at which an action has reached its final status.
        /// </summary>
        public DateTime? msidmCompletedTime
        {
            get { return AttrToNullableDateTime("msidmCompletedTime"); }
            set { SetAttrValue("msidmCompletedTime", value.ToString()); }
        }


        /// <summary>
        /// Reporting Job Details - This attribute defines the operational information associated with a reporting job.
        /// </summary>
        public string msidmReportingJobDetails
        {
            get { return GetAttrValue("msidmReportingJobDetails"); }
            set {
                SetAttrValue("msidmReportingJobDetails", value); 
            }
        }


        /// <summary>
        /// Reporting Job Status - This attribute defines the status of a reporting job.
        /// </summary>
        public string msidmReportingJobStatus
        {
            get { return GetAttrValue("msidmReportingJobStatus"); }
            set {
                SetAttrValue("msidmReportingJobStatus", value); 
            }
        }


        /// <summary>
        /// Reporting Job Type - This attribute defines the type of reporting job being represented by a reporting job object.
        /// </summary>
        [Required]
        public string msidmReportingJobType
        {
            get { return GetAttrValue("msidmReportingJobType"); }
            set {
                SetAttrValue("msidmReportingJobType", value); 
            }
        }


        /// <summary>
        /// Start Time - This attribute defines the start time and date of a reporting job object and is specified in UTC.
        /// </summary>
        public DateTime? msidmStartTime
        {
            get { return AttrToNullableDateTime("msidmStartTime"); }
            set { SetAttrValue("msidmStartTime", value.ToString()); }
        }


    }
}
