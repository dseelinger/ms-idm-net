using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Group - 
    /// </summary>
    public class Group : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public Group()
        {
            ObjectType = ForcedObjType = "Group";
        }

        /// <summary>
        /// Build a Group object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public Group(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "Group";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be Group)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of Group can only be 'Group'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Account Name - User's log on name
        /// </summary>
        public string AccountName
        {
            get { return GetAttrValue("AccountName"); }
            set {
                SetAttrValue("AccountName", value); 
            }
        }


        /// <summary>
        /// Computed Member - Resources in the set that are computed from the membership filter
        /// </summary>
        public List<IdmResource> ComputedMember
        {
            get { return GetMultiValuedAttr("ComputedMember", _theComputedMember); }
            set { SetMultiValuedAttr("ComputedMember", out _theComputedMember, value); }
        }
        private List<IdmResource> _theComputedMember;


        /// <summary>
        /// Deferred Evaluation - Determines when evaluation of the group happens with respect to request processing - real-time or deferred.
        /// </summary>
        public bool? msidmDeferredEvaluation
        {
            get { return AttrToNullableBool("msidmDeferredEvaluation"); }
            set { 
                SetAttrValue("msidmDeferredEvaluation", value.ToString());
            }
        }


        /// <summary>
        /// Displayed Owner - 
        /// </summary>
        public Person DisplayedOwner
        {
            get { return GetAttr("DisplayedOwner", _theDisplayedOwner); }
            set 
            { 
                _theDisplayedOwner = value;
                SetAttrValue("DisplayedOwner", ObjectIdOrNull(value)); 
            }
        }
        private Person _theDisplayedOwner;


        /// <summary>
        /// Domain - Choose the domain where you want to create the user account for this user
        /// </summary>
        [Required]
        public string Domain
        {
            get { return GetAttrValue("Domain"); }
            set {
                SetAttrValue("Domain", value); 
            }
        }


        /// <summary>
        /// Domain Configuration - A reference to a the parent Domain resource for this resource.
        /// </summary>
        public DomainConfiguration DomainConfiguration
        {
            get { return GetAttr("DomainConfiguration", _theDomainConfiguration); }
            set 
            { 
                _theDomainConfiguration = value;
                SetAttrValue("DomainConfiguration", ObjectIdOrNull(value)); 
            }
        }
        private DomainConfiguration _theDomainConfiguration;


        /// <summary>
        /// E-mail - Primary email address for the group.
        /// </summary>
        public string Email
        {
            get { return GetAttrValue("Email"); }
            set {
                SetAttrValue("Email", value); 
            }
        }


        /// <summary>
        /// E-mail Alias - E-mail alias. It is used to create the e-mail address
        /// </summary>
        public string MailNickname
        {
            get { return GetAttrValue("MailNickname"); }
            set {
                SetAttrValue("MailNickname", value); 
            }
        }


        /// <summary>
        /// Filter - A predicate defining a subset of the resources.
        /// </summary>
        public string Filter
        {
            get { return GetAttrValue("Filter"); }
            set {
                SetAttrValue("Filter", value); 
            }
        }


        /// <summary>
        /// Manually-managed Membership - Members in the group that are manually managed.
        /// </summary>
        public List<IdmResource> ExplicitMember
        {
            get { return GetMultiValuedAttr("ExplicitMember", _theExplicitMember); }
            set { SetMultiValuedAttr("ExplicitMember", out _theExplicitMember, value); }
        }
        private List<IdmResource> _theExplicitMember;


        /// <summary>
        /// Membership Add Workflow - 
        /// </summary>
        [Required]
        public string MembershipAddWorkflow
        {
            get { return GetAttrValue("MembershipAddWorkflow"); }
            set {
                SetAttrValue("MembershipAddWorkflow", value); 
            }
        }


        /// <summary>
        /// Membership Locked - 
        /// </summary>
        [Required]
        public bool MembershipLocked
        {
            get { return AttrToBool("MembershipLocked"); }
            set { 
                SetAttrValue("MembershipLocked", value.ToString());
            }
        }


        /// <summary>
        /// Owner - 
        /// </summary>
        public List<Person> Owner
        {
            get { return GetMultiValuedAttr("Owner", _theOwner); }
            set { SetMultiValuedAttr("Owner", out _theOwner, value); }
        }
        private List<Person> _theOwner;


        /// <summary>
        /// PAM Enabled - A boolean value that specifies if a Group is enabled for PAM.
        /// </summary>
        public bool? msidmPamEnabled
        {
            get { return AttrToNullableBool("msidmPamEnabled"); }
            set { 
                SetAttrValue("msidmPamEnabled", value.ToString());
            }
        }


        /// <summary>
        /// PAM Group Source Domain Name - The Source domain of a PAM group.
        /// </summary>
        public string msidmPamSourceDomainName
        {
            get { return GetAttrValue("msidmPamSourceDomainName"); }
            set {
                SetAttrValue("msidmPamSourceDomainName", value); 
            }
        }


        /// <summary>
        /// PAM Group Source SID - A binary value that specifies the Source security identifier (SID) of a PAM Group. The SID is a unique value used to identify the group as a security principal.
        /// </summary>
        public byte[] msidmPamSourceSid
        {
            get { return GetAttr("msidmPamSourceSid") == null ? null : GetAttr("msidmPamSourceSid").ToBinary(); }
            set { SetAttrValue("msidmPamSourceSid", value == null ? null : Convert.ToBase64String(value)); }
        }


        /// <summary>
        /// PAM Source Group Name - The name of the group that is shadowed by this group
        /// </summary>
        public string msidmPamSourceGroupName
        {
            get { return GetAttrValue("msidmPamSourceGroupName"); }
            set {
                SetAttrValue("msidmPamSourceGroupName", value); 
            }
        }


        /// <summary>
        /// Resource SID - A binary value that specifies the security identifier (SID) of the user. The SID is a unique value used to identify the user as a security principal.
        /// </summary>
        public byte[] ObjectSID
        {
            get { return GetAttr("ObjectSID") == null ? null : GetAttr("ObjectSID").ToBinary(); }
            set { SetAttrValue("ObjectSID", value == null ? null : Convert.ToBase64String(value)); }
        }


        /// <summary>
        /// Scope - 
        /// </summary>
        [Required]
        public string Scope
        {
            get { return GetAttrValue("Scope"); }
            set {
                SetAttrValue("Scope", value); 
            }
        }


        /// <summary>
        /// SID History - Contains previous SIDs used for the resource if the resource was moved from another domain.
        /// </summary>
        public List<byte[]> SIDHistory
        {
            get {
                IdmAttribute attr = GetAttr("SIDHistory");
                return (attr != null) ? attr.ToBinaries() : new List<byte[]>();
            }
            set { SetAttrValues("SIDHistory", value?.Select(Convert.ToBase64String).ToList()); }
        }


        /// <summary>
        /// Temporal - Defined by a filter that matches resources based on date and time attributes
        /// </summary>
        public bool? Temporal
        {
            get { return AttrToNullableBool("Temporal"); }
            set { 
                SetAttrValue("Temporal", value.ToString());
            }
        }


        /// <summary>
        /// Type - 
        /// </summary>
        [Required]
        public string Type
        {
            get { return GetAttrValue("Type"); }
            set {
                SetAttrValue("Type", value); 
            }
        }


        /// <summary>
        /// Uses SID history - Indicates if the PAM Group uses SID history.
        /// </summary>
        public bool? msidmPamUsesSIDHistory
        {
            get { return AttrToNullableBool("msidmPamUsesSIDHistory"); }
            set { 
                SetAttrValue("msidmPamUsesSIDHistory", value.ToString());
            }
        }


    }
}
