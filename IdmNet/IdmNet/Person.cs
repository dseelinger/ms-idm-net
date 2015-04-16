using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace IdmNet
{
    /// <summary>
    /// Person object
    /// </summary>
    public class Person : SecurityIdentifierResource
    {
        private Person _assistant;
        private Person _manager;

        /// <summary>
        /// For a Person object this can only be 'Person'
        /// </summary>
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

        /// <summary>
        /// (aka AD User Cannot Change Password) Will sync from AD to track whether the user is locked out from changing their AD password
        /// </summary>
        public bool? AD_UserCannotChangePassword
        {
            get { return GetAttr("AD_UserCannotChangePassword").ToBool(); }
            set { SetAttrValue("AD_UserCannotChangePassword", value.ToString()); }
        }

        /// <summary>
        /// Person's Address
        /// </summary>
        public string Address
        {
            get { return GetAttrValue("Address"); }
            set { SetAttrValue("Address", value); }
        }

        /// <summary>
        /// Person's Assistance - reference to another person
        /// </summary>
        public Person Assistant
        {
            get { return GetAttributeAsComplexObject("Assistant", _assistant); }
            set
            {
                _assistant = value;
                SetAttrValue("Assistant", value.ObjectID);
            }
        }

        /// <summary>
        /// Person's City
        /// </summary>
        public string City
        {
            get { return GetAttrValue("City"); }
            set { SetAttrValue("City", value); }
        }

        /// <summary>
        /// Person's Company
        /// </summary>
        public string Company
        {
            get { return GetAttrValue("Company"); }
            set { SetAttrValue("Company", value); }
        }

        /// <summary>
        /// Person's Cost Center
        /// </summary>
        public string CostCenter
        {
            get { return GetAttrValue("CostCenter"); }
            set { SetAttrValue("CostCenter", value); }
        }

        /// <summary>
        /// Person's Cost Center Name
        /// </summary>
        public string CostCenterName
        {
            get { return GetAttrValue("CostCenterName"); }
            set { SetAttrValue("CostCenterName", value); }
        }

        /// <summary>
        /// A Person's Country/Region
        /// </summary>
        public string Country
        {
            get { return GetAttrValue("Country"); }
            set { SetAttrValue("Country", value); }
        }

        /// <summary>
        /// A Person's Department
        /// </summary>
        public string Department
        {
            get { return GetAttrValue("Department"); }
            set { SetAttrValue("Department", value); }
        }

        /// <summary>
        /// A Person's end date as an employee
        /// </summary>
        public DateTime? EmployeeEndDate
        {
            get { return GetAttr("EmployeeEndDate").ToDateTime(); }
            set { SetAttrValue("EmployeeEndDate", value.ToString()); }
        }

        /// <summary>
        /// A Person's Employee ID (often some other unique ID)
        /// </summary>
        public string EmployeeID
        {
            get { return GetAttrValue("EmployeeID"); }
            set { SetAttrValue("EmployeeID", value); }
        }

        /// <summary>
        /// A Person's start date as an employee
        /// </summary>
        public DateTime? EmployeeStartDate
        {
            get { return GetAttr("EmployeeStartDate").ToDateTime(); }
            set { SetAttrValue("EmployeeStartDate", value.ToString()); }
        }

        /// <summary>
        /// A Person's employee type.  By default must be "Contractor", "Intern", or "Full Time Employee" unless 
        /// change in Identity Manager's Schema.
        /// </summary>
        public string EmployeeType
        {
            get { return GetAttrValue("EmployeeType"); }
            set { SetAttrValue("EmployeeType", value); }
        }

        /// <summary>
        /// A Person's Office Fax number
        /// </summary>
        public string OfficeFax
        {
            get { return GetAttrValue("OfficeFax"); }
            set { SetAttrValue("OfficeFax", value); }
        }

        /// <summary>
        /// A Person's first name (givenName in AD)
        /// </summary>
        public string FirstName
        {
            get { return GetAttrValue("FirstName"); }
            set { SetAttrValue("FirstName", value); }
        }

        ///// <summary>
        ///// A Person's first name (givenName in AD)
        ///// </summary>
        //public int? FreezeCount
        //{
        //    get { return GetAttr("FreezeCount") != null ? GetAttr("FreezeCount").ToInt() : null ; }
        //    set { SetAttrValue("FreezeCount", value); }
        //}



        /// <summary>
        /// A Person's job title
        /// </summary>
        public string JobTitle
        {
            get { return GetAttrValue("JobTitle"); }
            set { SetAttrValue("JobTitle", value); }
        }

        /// <summary>
        /// A Person's last name (sn in AD)
        /// </summary>
        public string LastName
        {
            get { return GetAttrValue("LastName"); }
            set { SetAttrValue("LastName", value); }
        }

        /// <summary>
        /// A Person's Country/Region
        /// </summary>
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
