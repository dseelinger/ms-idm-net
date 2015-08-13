using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// Person - This resource defines applicable policies to manage incoming requests. 
    /// </summary>
    public class Person : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public Person()
        {
            ObjectType = ForcedObjType = "Person";
        }

        /// <summary>
        /// Build a Person object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public Person(IdmResource resource)
        {
            Attributes = resource.Attributes;
            ObjectType = ForcedObjType = "Person";
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be Person)
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
        /// Account Name - User's log on name
        /// </summary>
        public string AccountName
        {
            get { return GetAttrValue("AccountName"); }
            set {
                SetAttrValue("AccountName", value); 
            }
        }


        /// <summary>
        /// AD User Cannot Change Password - Will sync from AD to track whether the user is locked out from changing their AD password
        /// </summary>
        public bool? AD_UserCannotChangePassword
        {
            get { return AttrToNullableBool("AD_UserCannotChangePassword"); }
            set { 
                SetAttrValue("AD_UserCannotChangePassword", value.ToString());
            }
        }


        /// <summary>
        /// Address - 
        /// </summary>
        public string Address
        {
            get { return GetAttrValue("Address"); }
            set {
                SetAttrValue("Address", value); 
            }
        }


        /// <summary>
        /// Assistant - 
        /// </summary>
        public Person Assistant
        {
            get { return GetAttr("Assistant", _theAssistant); }
            set 
            { 
                _theAssistant = value;
                SetAttrValue("Assistant", ObjectIdOrNull(value)); 
            }
        }
        private Person _theAssistant;


        /// <summary>
        /// AuthN Workflow Locked Out - This is the list of AuthN Processes a user is locked out of
        /// </summary>
        public List<WorkflowDefinition> AuthNWFLockedOut
        {
            get { return GetMultiValuedAttr("AuthNWFLockedOut", _theAuthNWFLockedOut); }
            set { SetMultiValuedAttr("AuthNWFLockedOut", out _theAuthNWFLockedOut, value); }
        }
        private List<WorkflowDefinition> _theAuthNWFLockedOut;


        /// <summary>
        /// AuthN Workflow Registered - This is the list of AuthN Processes a user is registered for
        /// </summary>
        public List<WorkflowDefinition> AuthNWFRegistered
        {
            get { return GetMultiValuedAttr("AuthNWFRegistered", _theAuthNWFRegistered); }
            set { SetMultiValuedAttr("AuthNWFRegistered", out _theAuthNWFRegistered, value); }
        }
        private List<WorkflowDefinition> _theAuthNWFRegistered;


        /// <summary>
        /// City - 
        /// </summary>
        public string City
        {
            get { return GetAttrValue("City"); }
            set {
                SetAttrValue("City", value); 
            }
        }


        /// <summary>
        /// Company - 
        /// </summary>
        public string Company
        {
            get { return GetAttrValue("Company"); }
            set {
                SetAttrValue("Company", value); 
            }
        }


        /// <summary>
        /// Cost Center - 
        /// </summary>
        public string CostCenter
        {
            get { return GetAttrValue("CostCenter"); }
            set {
                SetAttrValue("CostCenter", value); 
            }
        }


        /// <summary>
        /// Cost Center Name - 
        /// </summary>
        public string CostCenterName
        {
            get { return GetAttrValue("CostCenterName"); }
            set {
                SetAttrValue("CostCenterName", value); 
            }
        }


        /// <summary>
        /// Country/Region - 
        /// </summary>
        public string Country
        {
            get { return GetAttrValue("Country"); }
            set {
                SetAttrValue("Country", value); 
            }
        }


        /// <summary>
        /// Department - 
        /// </summary>
        public string Department
        {
            get { return GetAttrValue("Department"); }
            set {
                SetAttrValue("Department", value); 
            }
        }


        /// <summary>
        /// Domain - Choose the domain where you want to create the user account for this user
        /// </summary>
        public string Domain
        {
            get { return GetAttrValue("Domain"); }
            set {
                SetAttrValue("Domain", value); 
            }
        }


        /// <summary>
        /// Domain Configuration - A reference to a the parent Domain resource for this resource.
        /// </summary>
        public DomainConfiguration DomainConfiguration
        {
            get { return GetAttr("DomainConfiguration", _theDomainConfiguration); }
            set 
            { 
                _theDomainConfiguration = value;
                SetAttrValue("DomainConfiguration", ObjectIdOrNull(value)); 
            }
        }
        private DomainConfiguration _theDomainConfiguration;


        /// <summary>
        /// E-mail - Primary e-mail address for the user
        /// </summary>
        public string Email
        {
            get { return GetAttrValue("Email"); }
            set {
                SetAttrValue("Email", value); 
            }
        }


        /// <summary>
        /// E-mail Alias - E-mail alias. It is used to create the e-mail address
        /// </summary>
        public string MailNickname
        {
            get { return GetAttrValue("MailNickname"); }
            set {
                SetAttrValue("MailNickname", value); 
            }
        }


        /// <summary>
        /// Employee End Date - 
        /// </summary>
        public DateTime? EmployeeEndDate
        {
            get { return AttrToNullableDateTime("EmployeeEndDate"); }
            set { SetAttrValue("EmployeeEndDate", value.ToString()); }
        }


        /// <summary>
        /// Employee ID - 
        /// </summary>
        public string EmployeeID
        {
            get { return GetAttrValue("EmployeeID"); }
            set {
                SetAttrValue("EmployeeID", value); 
            }
        }


        /// <summary>
        /// Employee Start Date - 
        /// </summary>
        public DateTime? EmployeeStartDate
        {
            get { return AttrToNullableDateTime("EmployeeStartDate"); }
            set { SetAttrValue("EmployeeStartDate", value.ToString()); }
        }


        /// <summary>
        /// Employee Type - 
        /// </summary>
        public string EmployeeType
        {
            get { return GetAttrValue("EmployeeType"); }
            set {
                SetAttrValue("EmployeeType", value); 
            }
        }


        /// <summary>
        /// Fax - 
        /// </summary>
        public string OfficeFax
        {
            get { return GetAttrValue("OfficeFax"); }
            set {
                SetAttrValue("OfficeFax", value); 
            }
        }


        /// <summary>
        /// First Name - 
        /// </summary>
        public string FirstName
        {
            get { return GetAttrValue("FirstName"); }
            set {
                SetAttrValue("FirstName", value); 
            }
        }


        /// <summary>
        /// Freeze Count - 
        /// </summary>
        public int? FreezeCount
        {
            get { return AttrToNullableInteger("FreezeCount"); }
            set { 
                SetAttrValue("FreezeCount", value.ToString());
            }
        }


        /// <summary>
        /// Freeze Level - Tracks the number of times the user has unsuccessfully attempted to run an AuthN WF
        /// </summary>
        public string FreezeLevel
        {
            get { return GetAttrValue("FreezeLevel"); }
            set {
                SetAttrValue("FreezeLevel", value); 
            }
        }


        /// <summary>
        /// Job Title - 
        /// </summary>
        public string JobTitle
        {
            get { return GetAttrValue("JobTitle"); }
            set {
                SetAttrValue("JobTitle", value); 
            }
        }


        /// <summary>
        /// Last Name - 
        /// </summary>
        public string LastName
        {
            get { return GetAttrValue("LastName"); }
            set {
                SetAttrValue("LastName", value); 
            }
        }


        /// <summary>
        /// Last Reset Attempt Time - 
        /// </summary>
        public DateTime? LastResetAttemptTime
        {
            get { return AttrToNullableDateTime("LastResetAttemptTime"); }
            set { SetAttrValue("LastResetAttemptTime", value.ToString()); }
        }


        /// <summary>
        /// Lockout Gate Registration Data Ids - This is the list of gate registration ids used by the lockout gate
        /// </summary>
        public List<GateRegistration> AuthNLockoutRegistrationID
        {
            get { return GetMultiValuedAttr("AuthNLockoutRegistrationID", _theAuthNLockoutRegistrationID); }
            set { SetMultiValuedAttr("AuthNLockoutRegistrationID", out _theAuthNLockoutRegistrationID, value); }
        }
        private List<GateRegistration> _theAuthNLockoutRegistrationID;


        /// <summary>
        /// Login Name - This is a combination for domain/Alias
        /// </summary>
        public string LoginName
        {
            get { return GetAttrValue("LoginName"); }
            set {
                SetAttrValue("LoginName", value); 
            }
        }


        /// <summary>
        /// Manager - 
        /// </summary>
        public Person Manager
        {
            get { return GetAttr("Manager", _theManager); }
            set 
            { 
                _theManager = value;
                SetAttrValue("Manager", ObjectIdOrNull(value)); 
            }
        }
        private Person _theManager;


        /// <summary>
        /// Middle Name - 
        /// </summary>
        public string MiddleName
        {
            get { return GetAttrValue("MiddleName"); }
            set {
                SetAttrValue("MiddleName", value); 
            }
        }


        /// <summary>
        /// Mobile Phone - 
        /// </summary>
        public string MobilePhone
        {
            get { return GetAttrValue("MobilePhone"); }
            set {
                SetAttrValue("MobilePhone", value); 
            }
        }


        /// <summary>
        /// Office Location - 
        /// </summary>
        public string OfficeLocation
        {
            get { return GetAttrValue("OfficeLocation"); }
            set {
                SetAttrValue("OfficeLocation", value); 
            }
        }


        /// <summary>
        /// Office Phone - 
        /// </summary>
        public string OfficePhone
        {
            get { return GetAttrValue("OfficePhone"); }
            set {
                SetAttrValue("OfficePhone", value); 
            }
        }


        /// <summary>
        /// One-Time Password Email Address - Email address used to deliver a one-time password to the user.
        /// </summary>
        public string msidmOneTimePasswordEmailAddress
        {
            get { return GetAttrValue("msidmOneTimePasswordEmailAddress"); }
            set {
                SetAttrValue("msidmOneTimePasswordEmailAddress", value); 
            }
        }


        /// <summary>
        /// One-Time Password Mobile Phone - Mobile phone number used to deliver a one-time password to the user.
        /// </summary>
        public string msidmOneTimePasswordMobilePhone
        {
            get { return GetAttrValue("msidmOneTimePasswordMobilePhone"); }
            set {
                SetAttrValue("msidmOneTimePasswordMobilePhone", value); 
            }
        }


        /// <summary>
        /// Photo - 
        /// </summary>
        public byte[] Photo
        {
            get { return GetAttr("Photo") == null ? null : GetAttr("Photo").ToBinary(); }
            set { SetAttrValue("Photo", value == null ? null : Convert.ToBase64String(value)); }
        }


        /// <summary>
        /// Postal Code - 
        /// </summary>
        public string PostalCode
        {
            get { return GetAttrValue("PostalCode"); }
            set {
                SetAttrValue("PostalCode", value); 
            }
        }


        /// <summary>
        /// Proxy Address Collection - 
        /// </summary>
        public List<string> ProxyAddressCollection
        {
            get { return GetAttrValues("ProxyAddressCollection"); }
            set {
                SetAttrValues("ProxyAddressCollection", value); 
            }
        }


        /// <summary>
        /// RAS Access Permission - 
        /// </summary>
        public bool? IsRASEnabled
        {
            get { return AttrToNullableBool("IsRASEnabled"); }
            set { 
                SetAttrValue("IsRASEnabled", value.ToString());
            }
        }


        /// <summary>
        /// Register - 
        /// </summary>
        public bool? Register
        {
            get { return AttrToNullableBool("Register"); }
            set { 
                SetAttrValue("Register", value.ToString());
            }
        }


        /// <summary>
        /// Registration Required - Tracks if the user must register for SSPR
        /// </summary>
        public bool? RegistrationRequired
        {
            get { return AttrToNullableBool("RegistrationRequired"); }
            set { 
                SetAttrValue("RegistrationRequired", value.ToString());
            }
        }


        /// <summary>
        /// Reset Password - This attribute is used to trigger a password reset process.
        /// </summary>
        public string ResetPassword
        {
            get { return GetAttrValue("ResetPassword"); }
            set {
                SetAttrValue("ResetPassword", value); 
            }
        }


        /// <summary>
        /// Resource SID - A binary value that specifies the security identifier (SID) of the user. The SID is a unique value used to identify the user as a security principal.
        /// </summary>
        public byte[] ObjectSID
        {
            get { return GetAttr("ObjectSID") == null ? null : GetAttr("ObjectSID").ToBinary(); }
            set { SetAttrValue("ObjectSID", value == null ? null : Convert.ToBase64String(value)); }
        }


        /// <summary>
        /// SID History - Contains previous SIDs used for the resource if the resource was moved from another domain.
        /// </summary>
        public List<byte[]> SIDHistory
        {
            get { return GetAttr("SIDHistory")?.ToBinaries(); }
            set { SetAttrValues("SIDHistory", value?.Select(Convert.ToBase64String).ToList()); }
        }


        /// <summary>
        /// Time Zone - Reference to timezone configuration
        /// </summary>
        public TimeZoneConfiguration TimeZone
        {
            get { return GetAttr("TimeZone", _theTimeZone); }
            set 
            { 
                _theTimeZone = value;
                SetAttrValue("TimeZone", ObjectIdOrNull(value)); 
            }
        }
        private TimeZoneConfiguration _theTimeZone;


    }
}
