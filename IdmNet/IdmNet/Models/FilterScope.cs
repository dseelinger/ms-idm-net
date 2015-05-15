using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// FilterScope - This resource identifies a list of attributes and members that are permitted to be included in the filter of a set or group. 
    /// </summary>
    public class FilterScope : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public FilterScope()
        {
            ObjectType = ForcedObjType = "FilterScope";
        }

        /// <summary>
        /// Build a FilterScope object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public FilterScope(IdmResource resource)
        {
            ObjectType = ForcedObjType = "FilterScope";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be FilterScope)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of FilterScope can only be 'FilterScope'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Allowed Attributes - Select the attributes permitted in the filter definition.
        /// </summary>
        public List<AttributeTypeDescription> AllowedAttributes
        {
            get { return GetMultiValuedAttr("AllowedAttributes", _theAllowedAttributes); }
            set { SetMultiValuedAttr("AllowedAttributes", out _theAllowedAttributes, value); }
        }
        private List<AttributeTypeDescription> _theAllowedAttributes;


        /// <summary>
        /// Allowed Membership References - Select a collection of groups or sets for which a filter may reference the members.
        /// </summary>
        public List<Set> AllowedMembershipReferences
        {
            get { return GetMultiValuedAttr("AllowedMembershipReferences", _theAllowedMembershipReferences); }
            set { SetMultiValuedAttr("AllowedMembershipReferences", out _theAllowedMembershipReferences, value); }
        }
        private List<Set> _theAllowedMembershipReferences;


    }
}
