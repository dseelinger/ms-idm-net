using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Base class for Person and Group
    /// </summary>
    public class SecurityIdentifierResource : IdmResource
    {
        protected string ForcedObjType = "Resource";
        private IdmResource _domainConfiguration;


        protected void InitFromSecurityIdentifierResource(SecurityIdentifierResource resource)
        {
            if (resource.DomainConfiguration != null)
                DomainConfiguration = resource.DomainConfiguration;
        }


        /// <summary>
        /// (aka Account Name) Account name for the resource
        /// </summary>
        public string AccountName
        {
            get { return GetAttrValue("AccountName"); }
            set { SetAttrValue("AccountName", value); }
        }

        /// <summary>
        /// Domain name for the resource
        /// </summary>
        public string Domain
        {
            get { return GetAttrValue("Domain"); }
            set { SetAttrValue("Domain", value); }
        }

        /// <summary>
        /// Reference tot he Domain Name configuration object for the resource (if any)
        /// </summary>
        public IdmResource DomainConfiguration
        {
            get { return GetAttr("DomainConfiguration", _domainConfiguration); }
            set
            {
                _domainConfiguration = value;
                SetAttrValue("DomainConfiguration", value.ObjectID);
            }
        }

        /// <summary>
        /// Primary email address for the resource
        /// </summary>
        public string Email
        {
            get { return GetAttrValue("Email"); }
            set { SetAttrValue("Email", value); }
        }

        /// <summary>
        /// Email Alias for the resource
        /// </summary>
        public string MailNickname
        {
            get { return GetAttrValue("MailNickname"); }
            set { SetAttrValue("MailNickname", value); }
        }

        /// <summary>
        /// Security Identifier for the resource
        /// </summary>
        public string ObjectSID
        {
            get { return GetAttrValue("ObjectSID"); }
            set { SetAttrValue("ObjectSID", value); }
        }

        /// <summary>
        /// Contains previous SIDs used for the resource if the resource was moved from another domain.
        /// </summary>
        public List<string> SIDHistory
        {
            get { return GetAttrValues("SIDHistory"); }
            set { SetAttrValues("SIDHistory", value); }
        }

        /// <summary>
        /// Default/parameterless constructor
        /// </summary>
        public SecurityIdentifierResource()
        {
        }

        /// <summary>
        /// Create a Security Identifier Resource from a plain resource object
        /// </summary>
        /// <param name="resource"></param>
        public SecurityIdentifierResource(IdmResource resource)
        {
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }
    }
}
