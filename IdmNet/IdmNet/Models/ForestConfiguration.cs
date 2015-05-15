using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// ForestConfiguration - Active Directory Forest and Trust configuration.
    /// </summary>
    public class ForestConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ForestConfiguration()
        {
            ObjectType = ForcedObjType = "ForestConfiguration";
        }

        /// <summary>
        /// Build a ForestConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public ForestConfiguration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "ForestConfiguration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be ForestConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of ForestConfiguration can only be 'ForestConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Contact Set - A reference to a set of all mail-enabled resources whose primary Active Directory resource does not reside in the Forest and therefore require a Contact in this Forest.
        /// </summary>
        public Set ContactSet
        {
            get { return GetAttr("ContactSet", _theContactSet); }
            set 
            { 
                _theContactSet = value;
                SetAttrValue("ContactSet", ObjectIdOrNull(value)); 
            }
        }
        private Set _theContactSet;


        /// <summary>
        /// Distribution Group Domain - Specifies the domain in which a DG will be created, for DGs created by users in that forest.
        /// </summary>
        public DomainConfiguration DistributionListDomain
        {
            get { return GetAttr("DistributionListDomain", _theDistributionListDomain); }
            set 
            { 
                _theDistributionListDomain = value;
                SetAttrValue("DistributionListDomain", ObjectIdOrNull(value)); 
            }
        }
        private DomainConfiguration _theDistributionListDomain;


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


        /// <summary>
        /// Trusted Forest - The list of Forest resources which are trusted by this Forest and for which an Incoming Trust for this Forest has been configured in Active Directory.
        /// </summary>
        public List<ForestConfiguration> TrustedForest
        {
            get { return GetMultiValuedAttr("TrustedForest", _theTrustedForest); }
            set { SetMultiValuedAttr("TrustedForest", out _theTrustedForest, value); }
        }
        private List<ForestConfiguration> _theTrustedForest;


    }
}
