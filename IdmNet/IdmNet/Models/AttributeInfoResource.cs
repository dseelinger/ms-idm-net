namespace IdmNet.Models
{
    public class AttributeInfoResource : KeywordedResource
    {
        public AttributeInfoResource()
        {
        }

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
        /// (aka AD User Cannot Change Password) Will sync from AD to track whether the user is locked out from changing their AD password
        /// </summary>
        public bool? Localizable 
        {
            get { return AttrToBool("Localizable"); }
            set { SetAttrValue("Localizable", value.ToString()); }
        }

        /// <summary>
        /// A predicate defining a subset of the resources.
        /// </summary>
        public string StringRegex 
        {
            get { return GetAttrValue("StringRegex"); }
            set { SetAttrValue("StringRegex", value); }
        }


    }
}
