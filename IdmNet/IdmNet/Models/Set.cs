using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Set - A collection of object references defined by a filter or selected manually.
    /// </summary>
    public class Set : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public Set()
        {
            ObjectType = ForcedObjType = "Set";
        }

        /// <summary>
        /// Build a Set object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public Set(IdmResource resource)
        {
            ObjectType = ForcedObjType = "Set";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be Set)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of Set can only be 'Set'");
                SetAttrValue("ObjectType", value);
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
        /// Manually-managed Membership - Members in the set that are manually managed.
        /// </summary>
        public List<IdmResource> ExplicitMember
        {
            get { return GetMultiValuedAttr("ExplicitMember", _theExplicitMember); }
            set { SetMultiValuedAttr("ExplicitMember", out _theExplicitMember, value); }
        }
        private List<IdmResource> _theExplicitMember;


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


    }
}
