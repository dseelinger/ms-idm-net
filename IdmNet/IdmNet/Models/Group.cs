using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    public class Group : SecurityIdentifierResource
    {
        private List<IdmResource> _computedMembers;
        private Person _displayedOwner;
        private List<IdmResource> _explicitMembers;
        private List<Person> _owners;

        public Group()
        {
            ObjectType = ForcedObjType = "Group";
        }

        public Group(SecurityIdentifierResource resource)
            : base(resource)
        {
            ObjectType = ForcedObjType = "Group";
            InitFromSecurityIdentifierResource(resource);
        }

        /// <summary>
        /// Construct a Group from an IdMResource
        /// </summary>
        /// <param name="resource">base class</param>
        public Group(IdmResource resource)
            : base(resource)
        {
            ObjectType = ForcedObjType = "Group";
            var identifierResource = resource as SecurityIdentifierResource;
            if (identifierResource != null)
                InitFromSecurityIdentifierResource(identifierResource);
        }


        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of Person can only be 'Person'");
                SetAttrValue("ObjectType", value);
            }
        }

        public List<Person> Owner
        {
            get { return GetMultiValuedAttr("Owner", _owners); }
            set { SetMultiValuedAttr("Owner", out _owners, value); }
        }

        public List<IdmResource> ComputedMember
        {
            get { return GetMultiValuedAttr("ComputedMember", _computedMembers); }
            set { SetMultiValuedAttr("ComputedMember", out _computedMembers, value); }
        }

        public bool? msidmDeferredEvaluation
        {
            get { return AttrToBool("msidmDeferredEvaluation"); }
            set { SetAttrValue("msidmDeferredEvaluation", value.ToString()); }
        }

        public Person DisplayedOwner
        {
            get { return GetAttr("DisplayedOwner", _displayedOwner); }
            set
            {
                _displayedOwner = value;
                SetAttrValue("DisplayedOwner", value.ObjectID);
            }
        }

        public string Filter
        {
            get { return GetAttrValue("Filter"); }
            set { SetAttrValue("Filter", value); }
        }

        public List<IdmResource> ExplicitMember
        {
            get { return GetMultiValuedAttr("ExplicitMember", _explicitMembers); }
            set { SetMultiValuedAttr("ExplicitMember", out _explicitMembers, value); }
        }

        [Required]
        public string MembershipAddWorkflow
        {
            get { return GetAttrValue("MembershipAddWorkflow"); }
            set { SetAttrValue("MembershipAddWorkflow", value); }
        }

        [Required]
        public bool? MembershipLocked
        {
            get { return AttrToBool("MembershipLocked"); }
            set { SetAttrValue("MembershipLocked", value.ToString()); }
        }

        [RegularExpression("^(DomainLocal|Global|Universal)$")]
        [Required]
        public string Scope
        {
            get { return GetAttrValue("Scope"); }
            set { SetAttrValue("Scope", value); }
        }

        public bool? Temporal
        {
            get { return AttrToBool("Temporal"); }
            set { SetAttrValue("Temporal", value.ToString()); }
        }
    }
}