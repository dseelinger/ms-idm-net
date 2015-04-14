using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdmNet
{
    public class Person : SecurityIdentifierResource
    {
        private Person _assistant;
        private Person _manager;

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

        public bool? AD_UserCannotChangePassword
        {
            get { return AttributeToBool("AD_UserCannotChangePassword"); }
            set { SetAttrValue("AD_UserCannotChangePassword", value.ToString()); }
        }

        public string Address
        {
            get { return GetAttrValue("Address"); }
            set { SetAttrValue("Address", value); }
        }

        public Person Assistant
        {
            get { return GetAttributeAsComplexObject("Assistant", _assistant); }
            set
            {
                _assistant = value;
                SetAttrValue("Assistant", value.ObjectID);
            }
        }

        public string City
        {
            get { return GetAttrValue("City"); }
            set { SetAttrValue("City", value); }
        }

        public string Company
        {
            get { return GetAttrValue("Company"); }
            set { SetAttrValue("Company", value); }
        }

        public string CostCenter
        {
            get { return GetAttrValue("CostCenter"); }
            set { SetAttrValue("CostCenter", value); }
        }

        public string CostCenterName
        {
            get { return GetAttrValue("CostCenterName"); }
            set { SetAttrValue("CostCenterName", value); }
        }

        public string Department
        {
            get { return GetAttrValue("Department"); }
            set { SetAttrValue("Department", value); }
        }

        public DateTime? EmployeeEndDate
        {
            get { return AttributeToDateTime("EmployeeEndDate"); }
            set { SetAttrValue("EmployeeEndDate", value.ToString()); }
        }

        public string EmployeeID
        {
            get { return GetAttrValue("EmployeeID"); }
            set { SetAttrValue("EmployeeID", value); }
        }

        public DateTime? EmployeeStartDate
        {
            get { return AttributeToDateTime("EmployeeStartDate"); }
            set { SetAttrValue("EmployeeStartDate", value.ToString()); }
        }

        public string EmployeeType
        {
            get { return GetAttrValue("EmployeeType"); }
            set { SetAttrValue("EmployeeType", value); }
        }

        public string OfficeFax
        {
            get { return GetAttrValue("OfficeFax"); }
            set { SetAttrValue("OfficeFax", value); }
        }

        public string FirstName
        {
            get { return GetAttrValue("FirstName"); }
            set { SetAttrValue("FirstName", value); }
        }

        public string JobTitle
        {
            get { return GetAttrValue("JobTitle"); }
            set { SetAttrValue("JobTitle", value); }
        }

        public string LastName
        {
            get { return GetAttrValue("LastName"); }
            set { SetAttrValue("LastName", value); }
        }

        public string LoginName
        {
            get { return GetAttrValue("LoginName"); }
            set { SetAttrValue("LoginName", value); }
        }

        public Person Manager
        {
            get { return GetAttributeAsComplexObject("Manager", _manager); }
            set
            {
                _manager = value;
                SetAttrValue("Manager", value.ObjectID);
            }
        }

        public string MiddleName
        {
            get { return GetAttrValue("MiddleName"); }
            set { SetAttrValue("MiddleName", value); }
        }

        public string MobilePhone
        {
            get { return GetAttrValue("MobilePhone"); }
            set { SetAttrValue("MobilePhone", value); }
        }

        public string OfficeLocation
        {
            get { return GetAttrValue("OfficeLocation"); }
            set { SetAttrValue("OfficeLocation", value); }
        }

        public string OfficePhone
        {
            get { return GetAttrValue("OfficePhone"); }
            set { SetAttrValue("OfficePhone", value); }
        }

        public string PostalCode
        {
            get { return GetAttrValue("PostalCode"); }
            set { SetAttrValue("PostalCode", value); }
        }

        public List<string> ProxyAddressCollection
        {
            get { return GetAttrValues("PostalCode"); }
            set { SetAttrValues("PostalCode", value); }
        }

        public Person()
        {
            ObjectType = ForcedObjType = "Person";
        }

        public Person(SecurityIdentifierResource resource)
            : base(resource)
        {
            ObjectType = ForcedObjType = "Person";
            if (resource.DomainConfiguration == null)
                return;
            DomainConfiguration = resource.DomainConfiguration;
        }
    }
}
