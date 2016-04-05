using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// msidmPamConfiguration - PAM Configuration Object
    /// </summary>
    public class msidmPamConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public msidmPamConfiguration()
        {
            ObjectType = ForcedObjType = "msidmPamConfiguration";
        }

        /// <summary>
        /// Build a msidmPamConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public msidmPamConfiguration(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "msidmPamConfiguration";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be msidmPamConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of msidmPamConfiguration can only be 'msidmPamConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// PAM Default Active Directory Container - PAM Default Active Directory Container
        /// </summary>
        [Required]
        public string msidmDefaultADContainer
        {
            get { return GetAttrValue("msidmDefaultADContainer"); }
            set {
                SetAttrValue("msidmDefaultADContainer", value); 
            }
        }


        /// <summary>
        /// PAM Forest Functionality - PAM Forest Functionality
        /// </summary>
        [Required]
        public string msidmPamForestFunctionality
        {
            get { return GetAttrValue("msidmPamForestFunctionality"); }
            set {
                SetAttrValue("msidmPamForestFunctionality", value); 
            }
        }


        /// <summary>
        /// PAM Priv User Prefix - PAM Priv User Prefix
        /// </summary>
        [Required]
        public string msidmPamPrivUserPrefix
        {
            get { return GetAttrValue("msidmPamPrivUserPrefix"); }
            set {
                SetAttrValue("msidmPamPrivUserPrefix", value); 
            }
        }


        /// <summary>
        /// PAM Request Experation In Days - PAM Request Experation In Days
        /// </summary>
        [Required]
        public int msidmPamRequestExpirationInDays
        {
            get { return AttrToInteger("msidmPamRequestExpirationInDays"); }
            set { 
                SetAttrValue("msidmPamRequestExpirationInDays", value.ToString());
            }
        }


        /// <summary>
        /// PAM Role Default Duration In Seconds - PAM Role Default Duration In Seconds
        /// </summary>
        [Required]
        public int msidmPamRoleDefaultDurationInSeconds
        {
            get { return AttrToInteger("msidmPamRoleDefaultDurationInSeconds"); }
            set { 
                SetAttrValue("msidmPamRoleDefaultDurationInSeconds", value.ToString());
            }
        }


        /// <summary>
        /// PAM Role Maximal Duration In Seconds - PAM Role Maximal Duration In Seconds
        /// </summary>
        [Required]
        public int msidmPamRoleMaximalDurationInSeconds
        {
            get { return AttrToInteger("msidmPamRoleMaximalDurationInSeconds"); }
            set { 
                SetAttrValue("msidmPamRoleMaximalDurationInSeconds", value.ToString());
            }
        }


        /// <summary>
        /// PAM Role Minimal Duration In Seconds - PAM Role Minimal Duration In Seconds
        /// </summary>
        [Required]
        public int msidmPamRoleMinimalDurationInSeconds
        {
            get { return AttrToInteger("msidmPamRoleMinimalDurationInSeconds"); }
            set { 
                SetAttrValue("msidmPamRoleMinimalDurationInSeconds", value.ToString());
            }
        }


        /// <summary>
        /// PAM User Admin Password Length - PAM User Admin Password Length
        /// </summary>
        [Required]
        public int msidmPamUserAdminPasswordLength
        {
            get { return AttrToInteger("msidmPamUserAdminPasswordLength"); }
            set { 
                SetAttrValue("msidmPamUserAdminPasswordLength", value.ToString());
            }
        }


    }
}
