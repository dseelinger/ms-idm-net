using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// msidmPamRole - PAM Role Object
    /// </summary>
    public class msidmPamRole : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public msidmPamRole()
        {
            ObjectType = ForcedObjType = "msidmPamRole";
        }

        /// <summary>
        /// Build a msidmPamRole object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public msidmPamRole(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "msidmPamRole";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be msidmPamRole)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of msidmPamRole can only be 'msidmPamRole'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Approval required - Indicates if the elevation to this role has to be approved.
        /// </summary>
        public bool? msidmPamIsRoleApprovalNeeded
        {
            get { return AttrToNullableBool("msidmPamIsRoleApprovalNeeded"); }
            set { 
                SetAttrValue("msidmPamIsRoleApprovalNeeded", value.ToString());
            }
        }


        /// <summary>
        /// Availability Window Enabled - Indicates if availability window is enabled for a PAM role.
        /// </summary>
        public bool? msidmPamRoleAvailabilityWindowEnabled
        {
            get { return AttrToNullableBool("msidmPamRoleAvailabilityWindowEnabled"); }
            set { 
                SetAttrValue("msidmPamRoleAvailabilityWindowEnabled", value.ToString());
            }
        }


        /// <summary>
        /// Available From - Represents the lower bound of the availability time window of a PAM role.
        /// </summary>
        public DateTime? msidmPamRoleAvailableFrom
        {
            get { return AttrToNullableDateTime("msidmPamRoleAvailableFrom"); }
            set { SetAttrValue("msidmPamRoleAvailableFrom", value.ToString()); }
        }


        /// <summary>
        /// Available To - Represents the upper bound of the availability time window of a PAM role.
        /// </summary>
        public DateTime? msidmPamRoleAvailableTo
        {
            get { return AttrToNullableDateTime("msidmPamRoleAvailableTo"); }
            set { SetAttrValue("msidmPamRoleAvailableTo", value.ToString()); }
        }


        /// <summary>
        /// MFA Enabled - Indicates if MFA is enabled for a PAM role.
        /// </summary>
        public bool? msidmPamRoleMfaEnabled
        {
            get { return AttrToNullableBool("msidmPamRoleMfaEnabled"); }
            set { 
                SetAttrValue("msidmPamRoleMfaEnabled", value.ToString());
            }
        }


        /// <summary>
        /// Owners - Owners can approve or reject users who wish to elevate to this role.
        /// </summary>
        public List<Person> Owner
        {
            get { return GetMultiValuedAttr("Owner", _theOwner); }
            set { SetMultiValuedAttr("Owner", out _theOwner, value); }
        }
        private List<Person> _theOwner;


        /// <summary>
        /// PAM Candidates - PAM Candidates List
        /// </summary>
        public List<IdmResource> msidmPamCandidates
        {
            get { return GetMultiValuedAttr("msidmPamCandidates", _themsidmPamCandidates); }
            set { SetMultiValuedAttr("msidmPamCandidates", out _themsidmPamCandidates, value); }
        }
        private List<IdmResource> _themsidmPamCandidates;


        /// <summary>
        /// PAM Privileges - PAM Privilieges List
        /// </summary>
        public List<IdmResource> msidmPamPrivileges
        {
            get { return GetMultiValuedAttr("msidmPamPrivileges", _themsidmPamPrivileges); }
            set { SetMultiValuedAttr("msidmPamPrivileges", out _themsidmPamPrivileges, value); }
        }
        private List<IdmResource> _themsidmPamPrivileges;


        /// <summary>
        /// PAM Role TTL(sec) - The maximum time(sec) for a member to be in the role.
        /// </summary>
        [Required]
        public int msidmPamRoleTTL
        {
            get { return AttrToInteger("msidmPamRoleTTL"); }
            set { 
                SetAttrValue("msidmPamRoleTTL", value.ToString());
            }
        }


    }
}
