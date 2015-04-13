using System.Collections.Generic;

namespace IdmNet
{
    public class SecurityIdentifierResource : IdmResource
    {
        protected string ForcedObjType = "Resource";
        private IdmResource _domainConfiguration;

        public string AccountName
        {
            get { return GetAttrValue("AccountName"); }
            set { SetAttrValue("AccountName", value); }
        }

        public string Domain
        {
            get { return GetAttrValue("Domain"); }
            set { SetAttrValue("Domain", value); }
        }

        public IdmResource DomainConfiguration
        {
            get { return GetAttributeAsComplexObject("DomainConfiguration", _domainConfiguration); }
            set
            {
                _domainConfiguration = value;
                SetAttrValue("DomainConfiguration", value.ObjectID);
            }
        }

        public string Email
        {
            get { return GetAttrValue("Email"); }
            set { SetAttrValue("Email", value); }
        }

        public string MailNickname
        {
            get { return GetAttrValue("MailNickname"); }
            set { SetAttrValue("MailNickname", value); }
        }

        public string ObjectSID
        {
            get { return GetAttrValue("ObjectSID"); }
            set { SetAttrValue("ObjectSID", value); }
        }

        public List<string> SIDHistory
        {
            get { return GetAttrValues("SIDHistory"); }
            set { SetAttrValues("SIDHistory", value); }
        }

        public SecurityIdentifierResource()
        {
        }

        public SecurityIdentifierResource(IdmResource resource)
        {
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }
    }
}
