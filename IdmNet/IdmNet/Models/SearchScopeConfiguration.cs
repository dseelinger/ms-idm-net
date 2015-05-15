using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet.Models
{
    /// <summary>
    /// SearchScopeConfiguration - This resource describes the scope within which a user look for a resource.
    /// </summary>
    public class SearchScopeConfiguration : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public SearchScopeConfiguration()
        {
            ObjectType = ForcedObjType = "SearchScopeConfiguration";
        }

        /// <summary>
        /// Build a SearchScopeConfiguration object from a IdmResource object
        /// </summary>
        /// <param name="resource">base class</param>
        public SearchScopeConfiguration(IdmResource resource)
        {
            ObjectType = ForcedObjType = "SearchScopeConfiguration";
            Attributes = resource.Attributes;
            if (resource.Creator == null)
                return;
            Creator = resource.Creator;
        }

        readonly string ForcedObjType;

        /// <summary>
        /// Object Type (can only be SearchScopeConfiguration)
        /// </summary>
        [Required]
        public override sealed string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set
            {
                if (value != ForcedObjType)
                    throw new InvalidOperationException("Object Type of SearchScopeConfiguration can only be 'SearchScopeConfiguration'");
                SetAttrValue("ObjectType", value);
            }
        }

        /// <summary>
        /// Advanced Filter - A fully-formed search string with search term tokens that the search scope will execute.
        /// </summary>
        public string msidmSearchScopeAdvancedFilter
        {
            get { return GetAttrValue("msidmSearchScopeAdvancedFilter"); }
            set {
                SetAttrValue("msidmSearchScopeAdvancedFilter", value); 
            }
        }


        /// <summary>
        /// Attribute - System name (case sensitive) of the type of attribute to be shown in search results.
        /// </summary>
        public string SearchScopeColumn
        {
            get { return GetAttrValue("SearchScopeColumn"); }
            set {
                SetAttrValue("SearchScopeColumn", value); 
            }
        }


        /// <summary>
        /// Attribute Searched - System name (case sensitive) of the attributes that will be used to match against the search string supplied by the user.
        /// </summary>
        [Required]
        public List<string> SearchScopeContext
        {
            get { return GetAttrValues("SearchScopeContext"); }
            set {
                SetAttrValues("SearchScopeContext", value); 
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
        /// Navigation Page - 
        /// </summary>
        public string NavigationPage
        {
            get { return GetAttrValue("NavigationPage"); }
            set {
                SetAttrValue("NavigationPage", value); 
            }
        }


        /// <summary>
        /// Order - Precedence of this item within a parent grouping
        /// </summary>
        [Required]
        public int? Order
        {
            get { return AttrToInteger("Order"); }
            set { 
                SetAttrValue("Order", value.ToString());
            }
        }


        /// <summary>
        /// Redirecting URL - Relative path for the page where search results are to be show for searches from the home page.
        /// </summary>
        public string SearchScopeTargetURL
        {
            get { return GetAttrValue("SearchScopeTargetURL"); }
            set {
                SetAttrValue("SearchScopeTargetURL", value); 
            }
        }


        /// <summary>
        /// Resource Type - System name of the type of resource that the search scope returns.
        /// </summary>
        public string SearchScopeResultObjectType
        {
            get { return GetAttrValue("SearchScopeResultObjectType"); }
            set {
                SetAttrValue("SearchScopeResultObjectType", value); 
            }
        }


        /// <summary>
        /// Search Scope Filter - XPath expression of which resources are to be returned by the search scope.
        /// </summary>
        [Required]
        public string SearchScope
        {
            get { return GetAttrValue("SearchScope"); }
            set {
                SetAttrValue("SearchScope", value); 
            }
        }


        /// <summary>
        /// Usage Keyword - 
        /// </summary>
        [Required]
        public List<string> UsageKeyword
        {
            get { return GetAttrValues("UsageKeyword"); }
            set {
                SetAttrValues("UsageKeyword", value); 
            }
        }


    }
}
