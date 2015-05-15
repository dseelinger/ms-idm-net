using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// PortalUIConfiguration - This resource is used to store global portal configuration and the branding apperance in FIM Portal.There exists only one instance of this resource type in each FIM Portal deployment. 
    /// </summary>
    public class PortalUIConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public PortalUIConfiguration()
        {
            ObjectType = ForcedObjType = "PortalUIConfiguration";
        }

        /// <summary>
        /// Build a PortalUIConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public PortalUIConfiguration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "PortalUIConfiguration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be PortalUIConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of PortalUIConfiguration can only be 'PortalUIConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Branding Center Text - The centered branding text that used by branding control
        /// </summary>
        public string BrandingCenterText
        {
            get { return GetAttrValue("BrandingCenterText"); }
            set {
                SetAttrValue("BrandingCenterText", value); 
            }
        }


        /// <summary>
        /// Branding Left Image - The left url image that is used by branding control
        /// </summary>
        [Required]
        public string BrandingLeftImage
        {
            get { return GetAttrValue("BrandingLeftImage"); }
            set {
                SetAttrValue("BrandingLeftImage", value); 
            }
        }


        /// <summary>
        /// Branding Right Image - The right url image that used by branding control
        /// </summary>
        [Required]
        public string BrandingRightImage
        {
            get { return GetAttrValue("BrandingRightImage"); }
            set {
                SetAttrValue("BrandingRightImage", value); 
            }
        }


        /// <summary>
        /// Global Cache Duration - This time how long the UI configuration element will be kept on the cache
        /// </summary>
        [Required]
        public int? UICacheTime
        {
            get { return AttrToInteger("UICacheTime"); }
            set { 
                SetAttrValue("UICacheTime", value.ToString());
            }
        }


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
        /// ListView Cache Time Out - Specify the amount of time for the ListView cache to time out and expire.
        /// </summary>
        [Required]
        public int? ListViewCacheTimeOut
        {
            get { return AttrToInteger("ListViewCacheTimeOut"); }
            set { 
                SetAttrValue("ListViewCacheTimeOut", value.ToString());
            }
        }


        /// <summary>
        /// ListView Items per Page - Specify the number of items to show per page in all ListViews.
        /// </summary>
        [Required]
        public int? ListViewPageSize
        {
            get { return AttrToInteger("ListViewPageSize"); }
            set { 
                SetAttrValue("ListViewPageSize", value.ToString());
            }
        }


        /// <summary>
        /// ListView Pages to Cache - Specify the number of pages to cache while retrieving ListView results.
        /// </summary>
        [Required]
        public int? ListViewPagesToCache
        {
            get { return AttrToInteger("ListViewPagesToCache"); }
            set { 
                SetAttrValue("ListViewPagesToCache", value.ToString());
            }
        }


        /// <summary>
        /// Navigation Bar Resource Count Cache Duration - This time how long the UI dynamic counts will stay on the cache before it expired
        /// </summary>
        [Required]
        public int? UICountCacheTime
        {
            get { return AttrToInteger("UICountCacheTime"); }
            set { 
                SetAttrValue("UICountCacheTime", value.ToString());
            }
        }


        /// <summary>
        /// Per User Cache Duration - This time for how long the UI user data will stay on the cache before it expired
        /// </summary>
        [Required]
        public int? UIUserCacheTime
        {
            get { return AttrToInteger("UIUserCacheTime"); }
            set { 
                SetAttrValue("UIUserCacheTime", value.ToString());
            }
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
