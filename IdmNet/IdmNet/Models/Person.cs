using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Person object
    /// </summary>
    public class Person : SecurityIdentifierResource
    {
        private Person _assistant;
        private Person _manager;
        private List<IdmResource> _authNLockoutRegistrationID;
        private IdmResource _timeZone;


        /// <summary>
        /// Person's parmeterless constructor
        /// </summary>
        public Person()
        {
            ObjectType = ForcedObjType = "Person";
        }

        /// <summary>
        /// Construct a Person from a SecurityIdentifierResource
        /// </summary>
        /// <param name="resource">base class</param>
        public Person(SecurityIdentifierResource resource)
            : base(resource)
        {
            ObjectType = ForcedObjType = "Person";
            Clone(resource);
        }

        /// <summary>
        /// Construct a Person from an IdMResource
        /// </summary>
        /// <param name="resource">base class</param>
        public Person(IdmResource resource) : base(resource)
        {
            ObjectType = ForcedObjType = "Person";
            var identifierResource = resource as SecurityIdentifierResource;
            if (identifierResource != null)
                Clone(identifierResource);
        }

        
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
            get { return AttrToBool("AD_UserCannotChangePassword"); }
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
            get { return GetAttr("Assistant", _assistant); }
            set
            {
                _assistant = value;
                SetAttrValue("Assistant", ObjectIdOrNull(value));
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
            get { return GetAttr("EmployeeEndDate") == null ? null : GetAttr("EmployeeEndDate").ToDateTime(); }
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
            get { return GetAttr("EmployeeStartDate") == null ? null : GetAttr("EmployeeStartDate").ToDateTime(); }
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

        /// <summary>
        /// Tracks the number of times the user has unsuccessfully attempted to run an AuthN WF
        /// </summary>
        public int? FreezeCount
        {
            get { return AttrToInteger("FreezeCount"); }
            set { SetAttrValue("FreezeCount", value.ToString()); }
        }

        /// <summary>
        /// Defines the amount of functionality that is disabled due to unsuccessful AuthN WF attempts
        /// </summary>
        public string FreezeLevel
        {
            get { return GetAttrValue("FreezeLevel"); }
            set { SetAttrValue("FreezeLevel", value); }
        }


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
        /// The Last time the person attempted a reset (to be used in conjunction with Freeze Time and Freeze Level)
        /// </summary>
        public DateTime? LastResetAttemptTime
        {
            get { return GetAttr("LastResetAttemptTime") == null ? null : GetAttr("LastResetAttemptTime").ToDateTime(); }
            set { SetAttrValue("LastResetAttemptTime", value.ToString()); }
        }


        /// <summary>
        /// This is the list of gate registration ids used by the lockout gate
        /// </summary>
        public List<IdmResource> AuthNLockoutRegistrationID
        {
            get { return GetMultiValuedAttr("AuthNLockoutRegistrationID", _authNLockoutRegistrationID); }
            set { SetMultiValuedAttr("AuthNLockoutRegistrationID", out _authNLockoutRegistrationID, value); }
        }



        /// <summary>
        /// A Person's Country/Region
        /// </summary>
        public string LoginName
        {
            get { return GetAttrValue("LoginName"); }
            set { SetAttrValue("LoginName", value); }
        }

        /// <summary>
        /// A Person's Manager
        /// </summary>
        public Person Manager
        {
            get { return GetAttr("Manager", _manager); }
            set
            {
                _manager = value;
                SetAttrValue("Manager", ObjectIdOrNull(value));
            }
        }

        /// <summary>
        /// The person's middle name
        /// </summary>
        public string MiddleName
        {
            get { return GetAttrValue("MiddleName"); }
            set { SetAttrValue("MiddleName", value); }
        }

        /// <summary>
        /// The person's mobile phone number
        /// </summary>
        public string MobilePhone
        {
            get { return GetAttrValue("MobilePhone"); }
            set { SetAttrValue("MobilePhone", value); }
        }

        /// <summary>
        /// The person's office location
        /// </summary>
        public string OfficeLocation
        {
            get { return GetAttrValue("OfficeLocation"); }
            set { SetAttrValue("OfficeLocation", value); }
        }

        /// <summary>
        /// The person's office phone number
        /// </summary>
        public string OfficePhone
        {
            get { return GetAttrValue("OfficePhone"); }
            set { SetAttrValue("OfficePhone", value); }
        }


        /// <summary>
        /// One-Time Password Email Address - Email address used to deliver a one-time password to the user.
        /// </summary>
        public string msidmOneTimePasswordEmailAddress
        {
            get { return GetAttrValue("msidmOneTimePasswordEmailAddress"); }
            set { SetAttrValue("msidmOneTimePasswordEmailAddress", value); }
        }

        /// <summary>
        /// One-Time Password Mobile Phone - Mobile phone number used to deliver a one-time password to the user.
        /// </summary>
        public string msidmOneTimePasswordMobilePhone
        {
            get { return GetAttrValue("msidmOneTimePasswordMobilePhone"); }
            set { SetAttrValue("msidmOneTimePasswordMobilePhone", value); }
        }

        /// <summary>
        /// A photograph of the person
        /// </summary>
        public byte[] Photo
        {
            get { return GetAttr("Photo") == null ? null : GetAttr("Photo").ToBinary(); }
            set { SetAttrValue("Photo", Convert.ToBase64String(value)); }
        }

        /// <summary>
        /// The person's postal/zip code
        /// </summary>
        public string PostalCode
        {
            get { return GetAttrValue("PostalCode"); }
            set { SetAttrValue("PostalCode", value); }
        }

        /// <summary>
        /// List of alternate email addresses for the person (used by AD/Exchange)
        /// </summary>
        public List<string> ProxyAddressCollection
        {
            get { return GetAttrValues("ProxyAddressCollection"); }
            set { SetAttrValues("ProxyAddressCollection", value); }
        }


        /// <summary>
        /// True if the person has RAS Access Permission
        /// </summary>
        public bool? IsRASEnabled
        {
            get { return GetAttr("IsRASEnabled") == null ? null : GetAttr("IsRASEnabled").ToBool(); }
            set { SetAttrValue("IsRASEnabled", value.ToString()); }
        }

        /// <summary>
        /// True if the person is registered for self-service password reset
        /// </summary>
        public bool? Register
        {
            get { return GetAttr("Register") == null ? null : GetAttr("Register").ToBool(); }
            set { SetAttrValue("Register", value.ToString()); }
        }

        /// <summary>
        /// Tracks if the user must register for SSPR
        /// </summary>
        public bool? RegistrationRequired
        {
            get { return GetAttr("RegistrationRequired") == null ? null : GetAttr("RegistrationRequired").ToBool(); }
            set { SetAttrValue("RegistrationRequired", value.ToString()); }
        }

        /// <summary>
        /// This attribute is used to trigger a password reset process.
        /// </summary>
        public string ResetPassword
        {
            get { return GetAttrValue("ResetPassword"); }
            set { SetAttrValue("ResetPassword", value); }
        }

        /// <summary>
        /// Reference tot he Domain Name configuration object for the resource (if any)
        /// </summary>
        public IdmResource TimeZone
        {
            get { return GetAttr("TimeZone", _timeZone); }
            set
            {
                _timeZone = value;
                SetAttrValue("TimeZone", ObjectIdOrNull(value));
            }
        }
    }
}
