namespace IdmNet.Models
{
    /// <summary>
    /// Instatntiate just for testing - holds attributes common to AttributeTypeDescription and BindingDescription
    /// </summary>
    public class AttributeInfoResource : KeywordedResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public AttributeInfoResource()
        {
        }

        /// <summary>
        /// Base CTOR
        /// </summary>
        /// <param name="resource">Base class</param>
        public AttributeInfoResource(IdmResource resource) : base(resource)
        {
        }

        /// <summary>
        /// For an Integer attribute, this is the maximum value, inclusive
        /// </summary>
        public int? IntegerMaximum
        {
            get { return AttrToInteger("IntegerMaximum"); }
            set { SetAttrValue("IntegerMaximum", value.ToString()); }
        }

        /// <summary>
        /// For an Integer attribute, this is the minimum value, inclusive
        /// </summary>
        public int? IntegerMinimum
        {
            get { return AttrToInteger("IntegerMinimum"); }
            set { SetAttrValue("IntegerMinimum", value.ToString()); }
        }

        /// <summary>
        /// A true indicates this attribute can be localized.  Only allowed for String DataTypes
        /// </summary>
        public bool? Localizable 
        {
            get { return AttrToBool("Localizable"); }
            set { SetAttrValue("Localizable", value.ToString()); }
        }

        /// <summary>
        ///  String Regular Expression - This is a .Net Regex pattern that defines what string values are allowed.
        /// </summary>
        public string StringRegex 
        {
            get { return GetAttrValue("StringRegex"); }
            set { SetAttrValue("StringRegex", value); }
        }


    }
}
