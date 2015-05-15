using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// ActivityInformationConfiguration - This resource drives the appearance of an activity in FIM Portal.
    /// </summary>
    public class ActivityInformationConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ActivityInformationConfiguration()
        {
            ObjectType = ForcedObjType = "ActivityInformationConfiguration";
        }

        /// <summary>
        /// Build a ActivityInformationConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public ActivityInformationConfiguration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "ActivityInformationConfiguration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be ActivityInformationConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of ActivityInformationConfiguration can only be 'ActivityInformationConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Activity Name - The class name of the correspondent activity
        /// </summary>
        [Required]
        public string ActivityName
        {
            get { return GetAttrValue("ActivityName"); }
            set {
                SetAttrValue("ActivityName", value); 
            }
        }


        /// <summary>
        /// Assembly Name - The assembly where the activity settings part is defined
        /// </summary>
        [Required]
        public string AssemblyName
        {
            get { return GetAttrValue("AssemblyName"); }
            set {
                SetAttrValue("AssemblyName", value); 
            }
        }


        /// <summary>
        /// Is Action Activity - This is an indication that this activity could be put into an action process
        /// </summary>
        [Required]
        public bool? IsActionActivity
        {
            get { return AttrToBool("IsActionActivity"); }
            set { 
                SetAttrValue("IsActionActivity", value.ToString());
            }
        }


        /// <summary>
        /// Is Authentication Activity - This is an indication that this activity could be put into an authentication process
        /// </summary>
        [Required]
        public bool? IsAuthenticationActivity
        {
            get { return AttrToBool("IsAuthenticationActivity"); }
            set { 
                SetAttrValue("IsAuthenticationActivity", value.ToString());
            }
        }


        /// <summary>
        /// Is Authorization Activity - This is an indication that this activity could be put into an authorization process
        /// </summary>
        [Required]
        public bool? IsAuthorizationActivity
        {
            get { return AttrToBool("IsAuthorizationActivity"); }
            set { 
                SetAttrValue("IsAuthorizationActivity", value.ToString());
            }
        }


        /// <summary>
        /// Is Configuration Type - This is an indication that this resource is a configuration resource.
        /// </summary>
        [Required]
        public bool? IsConfigurationType
        {
            get { return AttrToBool("IsConfigurationType"); }
            set { 
                SetAttrValue("IsConfigurationType", value.ToString());
            }
        }


        /// <summary>
        /// Type Name - The class name of the activity settings part.
        /// </summary>
        [Required]
        public string TypeName
        {
            get { return GetAttrValue("TypeName"); }
            set {
                SetAttrValue("TypeName", value); 
            }
        }


    }
}
