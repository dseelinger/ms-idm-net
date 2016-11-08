using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// msidmPamRequest - PAM Request Object
    /// </summary>
    public class msidmPamRequest : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public msidmPamRequest()
        {
            ObjectType = ForcedObjType = "msidmPamRequest";
        }

        /// <summary>
        /// Build a msidmPamRequest object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public msidmPamRequest(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "msidmPamRequest";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be msidmPamRequest)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of msidmPamRequest can only be 'msidmPamRequest'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// CreationMethod - Indicates the method that PAM Request was created: PowerShell or Rest API
        /// </summary>
        public string msidmPamRequestCreationMethod
        {
            get { return GetAttrValue("msidmPamRequestCreationMethod"); }
            set {
                SetAttrValue("msidmPamRequestCreationMethod", value); 
            }
        }


        /// <summary>
        /// ElevatedUserSid - The SID of the user account to which access was granted by this request
        /// </summary>
        public string msidmPamRequestElevatedUserSid
        {
            get { return GetAttrValue("msidmPamRequestElevatedUserSid"); }
            set {
                SetAttrValue("msidmPamRequestElevatedUserSid", value); 
            }
        }


        /// <summary>
        /// ExpirationProcessState - Indicates the state of the process that handled the request by the server
        /// </summary>
        public string msidmPamRequestExpirationProcessedState
        {
            get { return GetAttrValue("msidmPamRequestExpirationProcessedState"); }
            set {
                SetAttrValue("msidmPamRequestExpirationProcessedState", value); 
            }
        }


        /// <summary>
        /// ExpirationProcessStatusInfo - Provides additional information to the Expiration process of the PAM Request
        /// </summary>
        public string msidmPamRequestExpirationStatusInfo
        {
            get { return GetAttrValue("msidmPamRequestExpirationStatusInfo"); }
            set {
                SetAttrValue("msidmPamRequestExpirationStatusInfo", value); 
            }
        }


        /// <summary>
        /// GroupSidList - The list of AD groups to which access was granted by this request
        /// </summary>
        public List<string> msidmPamRequestGroupSidList
        {
            get { return GetAttrValues("msidmPamRequestGroupSidList"); }
            set {
                SetAttrValues("msidmPamRequestGroupSidList", value); 
            }
        }


        /// <summary>
        /// PAM Request Expiration Date - Expiration date and time of the PAM request. This is set automatically by system according to the configured TTL
        /// </summary>
        public DateTime? msidmPamRequestExpirationDate
        {
            get { return AttrToNullableDateTime("msidmPamRequestExpirationDate"); }
            set { SetAttrValue("msidmPamRequestExpirationDate", value.ToString()); }
        }


        /// <summary>
        /// PAM Request Role - PAM Request Role
        /// </summary>
        public IdmResource msidmPamRequestRole
        {
            get { return GetAttr("msidmPamRequestRole", _themsidmPamRequestRole); }
            set 
            { 
                _themsidmPamRequestRole = value;
                SetAttrValue("msidmPamRequestRole", ObjectIdOrNull(value)); 
            }
        }
        private IdmResource _themsidmPamRequestRole;


        /// <summary>
        /// PAM Request Time - The date and time that the PAM User requested
        /// </summary>
        public DateTime? msidmPamRequestTime
        {
            get { return AttrToNullableDateTime("msidmPamRequestTime"); }
            set { SetAttrValue("msidmPamRequestTime", value.ToString()); }
        }


        /// <summary>
        /// PAM Request Was Closed - Indicates whether the PAM request was closed
        /// </summary>
        public bool? msidmPamRequestWasClosed
        {
            get { return AttrToNullableBool("msidmPamRequestWasClosed"); }
            set { 
                SetAttrValue("msidmPamRequestWasClosed", value.ToString());
            }
        }


        /// <summary>
        /// PAMRequest TTL - The TTL that the PAM User requested. Must be smaller than the PAMRole's TTL.
        /// </summary>
        public int? msidmPamRequestTTL
        {
            get { return AttrToNullableInteger("msidmPamRequestTTL"); }
            set { 
                SetAttrValue("msidmPamRequestTTL", value.ToString());
            }
        }


    }
}
