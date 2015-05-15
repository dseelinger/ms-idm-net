using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// DomainConfiguration - Active Directory Domain configuration.
    /// </summary>
    public class DomainConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public DomainConfiguration()
        {
            ObjectType = ForcedObjType = "DomainConfiguration";
        }

        /// <summary>
        /// Build a DomainConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public DomainConfiguration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "DomainConfiguration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be DomainConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of DomainConfiguration can only be 'DomainConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

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
        /// Foreign Security Principal Set - A reference to a set of all security resources whose primary Active Directory resource does not reside in the Forest and therefore require a Foreign Security Principal in this Forest.
        /// </summary>
        public Set ForeignSecurityPrincipalSet
        {
            get { return GetAttr("ForeignSecurityPrincipalSet", _theForeignSecurityPrincipalSet); }
            set 
            { 
                _theForeignSecurityPrincipalSet = value;
                SetAttrValue("ForeignSecurityPrincipalSet", ObjectIdOrNull(value)); 
            }
        }
        private Set _theForeignSecurityPrincipalSet;


        /// <summary>
        /// Forest Configuration - A reference to a the parent Forest resource for this Domain.
        /// </summary>
        public ForestConfiguration ForestConfiguration
        {
            get { return GetAttr("ForestConfiguration", _theForestConfiguration); }
            set 
            { 
                _theForestConfiguration = value;
                SetAttrValue("ForestConfiguration", ObjectIdOrNull(value)); 
            }
        }
        private ForestConfiguration _theForestConfiguration;


        /// <summary>
        /// Is Configuration Type - This is an indication that this resource is a configuration resource.
        /// </summary>
        public bool? IsConfigurationType
        {
            get { return AttrToBool("IsConfigurationType"); }
            set { 
                SetAttrValue("IsConfigurationType", value.ToString());
            }
        }


    }
}
